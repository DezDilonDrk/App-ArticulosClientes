using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Articulos_Frontend.Client;
using Articulos_Frontend.LogConfig;
using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;

namespace Articulos_Frontend;

public partial class ArticuloForm : Form
{
    //private ArticuloRepository repo;
    private ArticuloApiClient api;
    private Usuario user;
    private bool admin = true;
    public string ModoInvocacion;
    public Articulo articuloSeleccionado;

    public ArticuloForm(Usuario usuario)
    {
        InitializeComponent();
        string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
        //repo = new ArticuloRepository(connStr);
        api = new ArticuloApiClient();
        StyleManager.StyleForm(this);
        user = usuario;
        usuarioActual.Text = $"Usuario: {user.CorreoElectronico}";
        var categorias = new[] { "Electrónica", "Perifericos", "Mobiliario" };
        comboBoxCategoria.DataSource = categorias.ToList();
        comboBoxCategoria.SelectedIndex = -1;
        Log.Info("Formulario de artículos iniciado.");
    }
    public ArticuloForm()
    {
        InitializeComponent();
        string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
        //repo = new ArticuloRepository(connStr);
        api = new ArticuloApiClient();
        StyleManager.StyleForm(this);
        user = new Usuario("Guest Mode ON", "Guest", "Guest2026");
        usuarioActual.Text = $"Usuario: {user.CorreoElectronico}";
        var categorias = new[] { "Electrónica", "Perifericos", "Mobiliario" };
        comboBoxCategoria.DataSource = categorias.ToList();
        comboBoxCategoria.SelectedIndex = -1;
        Log.Info("Formulario de artículos iniciado en modo Guest");
    }

    private void ArticuloForm_Load(object sender, EventArgs e)
    {
        try
        {
            Log.Info("Cargando artículos en el formulario.");
            cargarArticulos(null);
            panelFiltros.Visible = false;
            if (!AppState.Roles.Contains(Roles.AdminAlmacen))
            {
                BotonAdd.Enabled = false;
                BotonDel.Enabled = false;
                admin = false;
            }
            else
            {
                admin = true;
            }
        } catch (Exception ex)
        {
            Log.Error("Error al cargar artículos en el formulario.", ex);
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
            alerta.ShowDialog();
            return;
        }
        
    }

    private void botonAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Log.Info("Abriendo formulario de detalle para nuevo artículo.");
            WindowManager.ShowForm(
            "Articulo_Nuevo",
            this,
            () =>
            {
                var form = new ArticuloDetailForm(api, null, user);
                form.FormClosed += (s, e) => cargarArticulos(null);
                return form;
            });
        } catch (Exception ex)
        {
            Log.Error("Error al abrir formulario de detalle para nuevo artículo.", ex);
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
            alerta.ShowDialog();
            return;
        }
        
    }

    private async void botonDel_Click(object sender, EventArgs e)
    {
        try
        {
            Log.Info($"Eliminando artículo con ID {dataGridView1.CurrentRow?.Cells["Id"].Value}.");
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Warning, new Exception("¿Confirma que desea eliminar este artículo?"));
            alerta.ShowDialog();
            if (alerta.resultado)
            {
                await api.Eliminar(dataGridView1.CurrentRow?.Cells["Id"].Value as int? ?? 0);
            }
            cargarArticulos(null);
        }
        catch (Exception ex)
        {
            Log.Error("Error al eliminar artículo.", ex);
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
            alerta.ShowDialog();
            return;
        }
    }

    private async void cargarArticulos(string nombre)
    {
        try
        {
            var articulos = await api.ObtenerArticulos();
            var dateDesde = fechaDesde.Value.Date;
            var dateHasta = fechaHasta.Value.Date.AddDays(1);
            var categoria = comboBoxCategoria.SelectedItem as string;
            var espacio = " ";
            if (textBoxMinimo.Text == "" || textBoxMinimo.Text.Contains(espacio))
            {
                textBoxMinimo.Text = "0";
            }
            if (textBoxMaximo.Text == "" || textBoxMaximo.Text.Contains(espacio))
            {
                textBoxMaximo.Text = "1000000";
            }
            if (!decimal.TryParse(textBoxMinimo.Text, out var PrecioMin) || PrecioMin < 0)
            {
                MessageBox.Show("Precio mínimo inválido (no es un número o no es negativo)");
                return;
            }
            if (!decimal.TryParse(textBoxMaximo.Text, out var PrecioMax) || PrecioMax < 0)
            {
                MessageBox.Show("Precio máximo inválido (no es un número o no es negativo)");
                return;
            }


            if (!string.IsNullOrWhiteSpace(nombre))
            {
                articulos = articulos
                    .Where(a => a.nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            if (panelFiltros.Visible)
            {
                if (checkBoxDesde.Checked)
                {
                    articulos = articulos
                    .Where(a => a.FechaCreacion >= dateDesde)
                    .ToList();
                }
                if (checkBoxHasta.Checked)
                {
                    articulos = articulos
                    .Where(a => a.FechaCreacion < dateHasta)
                    .ToList();
                }
                if (!string.IsNullOrWhiteSpace(categoria))
                {
                    articulos = articulos
                        .Where(a => a.categoria == categoria)
                        .ToList();
                }

                articulos = articulos
                .Where(a => a.precio >= PrecioMin)
                .Where(a => a.precio <= PrecioMax)
                .ToList();
            }


            dataGridView1.DataSource = articulos;
        }
        catch (Exception ex)
        {
            Log.Error("Error al cargar artículos.", ex);
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
            alerta.ShowDialog();
            return;


        }
    }

    private void BotonBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Log.Info("Realizando búsqueda de artículos: " + TextoNombre.Text);
            cargarArticulos(TextoNombre.Text);
        } catch (Exception ex)
        {
            Log.Error("Error al realizar búsqueda de artículos.", ex);
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
            alerta.ShowDialog();
            if (alerta.resultado)
            {
                return;
            }
            else
            {
                return;
            }
        }
        
    }

    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (ModoInvocacion == "CrearPedido")
        {
            articuloSeleccionado = new Articulo
            {
                id = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value,
                nombre = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString(),
                precio = (decimal)dataGridView1.Rows[e.RowIndex].Cells["Precio"].Value,
                categoria = dataGridView1.Rows[e.RowIndex].Cells["Categoria"].Value.ToString(),
                FechaCreacion = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["FechaCreacion"].Value,
                FechaActualizacion = dataGridView1.Rows[e.RowIndex].Cells["FechaActualizacion"].Value as DateTime?
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
            return;
        }
        if (!admin)
        {
            MessageBox.Show("No tienes permisos para editar artículos.");
            return;
        }
        if (e.RowIndex >= 0)
        {
            try
            {
                var articulo = dataGridView1.Rows[e.RowIndex].DataBoundItem as Articulo;

                if (articulo != null)
                {
                    Log.Info($"Abriendo formulario de detalle para artículo ID {articulo.id}.");
                    WindowManager.ShowForm(
                        $"{nameof(ArticuloForm)}_{articulo.id}",
                        this,
                        () =>
                        {
                            var form = new ArticuloDetailForm(api, articulo, user);
                            form.FormClosed += (s, e) => cargarArticulos(null);
                            return form;
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                alerta.ShowDialog();
                return;

            }
        }
    }



    private void EtiquetaNombre_Click(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {

    }

    private void checkBoxDesde_CheckedChanged(object sender, EventArgs e)
    {

    }
    private void checkBoxHasta_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void BotonFiltros_Click(object sender, EventArgs e)
    {
        if (panelFiltros.Visible)
        {
            panelFiltros.Visible = false;
            MinimumSize = new Size((MinimumSize.Width - panelFiltros.Width), MinimumSize.Height);

            BotonFiltros.Text = "Mostrar filtros";
        }
        else
        {
            panelFiltros.Visible = true;
            MinimumSize = new Size((MinimumSize.Width + panelFiltros.Width), MinimumSize.Height);
            BotonFiltros.Text = "Ocultar filtros";
        }
    }

    private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        if (dataGridView1.Columns.Contains("colVacia"))
        {
            dataGridView1.Columns.Remove("colVacia");
        }
        if (dataGridView1.Columns.Count == 0) return;

        dataGridView1.Columns[0].Width = 40;
        dataGridView1.Columns[1].Width = 120;
        dataGridView1.Columns[2].Width = 80;
        dataGridView1.Columns[3].Width = 80;
        dataGridView1.Columns[4].Width = 110;
        dataGridView1.Columns[5].Width = 140;
        DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
        col.Name = "colVacia";
        col.HeaderText = "";
        dataGridView1.Columns.Add(col);
        dataGridView1.Columns["colVacia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    }
}
