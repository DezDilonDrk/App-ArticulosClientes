using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;

namespace Articulos_Frontend;

public partial class ArticuloForm : Form
{
    //private ArticuloRepository repo;
    private ArticuloApiClient api;

    public ArticuloForm()
    {
        InitializeComponent();
        string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
        //repo = new ArticuloRepository(connStr);
        api = new ArticuloApiClient();
        StyleManager.StyleForm(this);
        var categorias = new[] { "Electrónica", "Perifericos", "Mobiliario" };
        comboBoxCategoria.DataSource = categorias.ToList();
        comboBoxCategoria.SelectedIndex = -1;
    }

    private void ArticuloForm_Load(object sender, EventArgs e)
    {
        cargarArticulos(null);
        panelFiltros.Visible = false;
        MinimumSize = new Size((MinimumSize.Width - panelFiltros.Width), MinimumSize.Height);
    }

    private void botonAdd_Click(object sender, EventArgs e)
    {
        WindowManager.ShowForm(
        "Articulo_Nuevo",
        this,
        () =>
        {
            var form = new ArticuloDetailForm(api, null);
            form.FormClosed += (s, e) => cargarArticulos(null);
            return form;
        }

    );
    }

    private async void botonDel_Click(object sender, EventArgs e)
    {
        await api.Eliminar(dataGridView1.CurrentRow?.Cells["Id"].Value as int? ?? 0);
        cargarArticulos(null);
    }

    private async void cargarArticulos(string nombre)
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

    private void BotonBuscar_Click(object sender, EventArgs e)
    {
        cargarArticulos(TextoNombre.Text);
    }

    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            var articulo = dataGridView1.Rows[e.RowIndex].DataBoundItem as Articulo;

            if (articulo != null)
            {
                WindowManager.ShowForm(
                    $"{nameof(ArticuloForm)}_{articulo.id}",
                    this,
                    () =>
                    {
                        var form = new ArticuloDetailForm(api, articulo);
                        form.FormClosed += (s, e) => cargarArticulos(null);
                        return form;
                    }
                );
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
        if (dataGridView1.Columns.Count == 0) return;

        dataGridView1.Columns[0].Width = 40;
        dataGridView1.Columns[1].Width = 120;
        dataGridView1.Columns[2].Width = 80;
        dataGridView1.Columns[3].Width = 80;
        dataGridView1.Columns[4].Width = 110;
        dataGridView1.Columns[5].Width = 140;
    }
}
