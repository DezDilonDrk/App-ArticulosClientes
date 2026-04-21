using Articulos_Frontend.Client;
using Articulos_Frontend.LogConfig;
using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Articulos_Frontend.Forms.main
{
    public partial class AjustesForm : Form
    {
        StringValuesSP stringValuesSP = new StringValuesSP();
        private ErrorProvider errorProvider;
        private List<Cliente> listaActual;
        private bool admin = true;
        public string DniSeleccionado;
        public string ModoInvocacion;
        public AjustesForm()
        {
            InitializeComponent();
            string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
            StyleManager.StyleForm(this);
            this.ActiveControl = textBoxCliente;
            Log.Info("Formulario de Ajustes iniciado.");
        }
        private void ClienteForm_Load(object sender, EventArgs e)
        {
            Log.Info("Cargando clientes en el formulario.");
            buscarClientes(null);
            RegistrarClicks(this);
            if (!AppState.Roles.Contains(Roles.AdminVentas))
            {
                BotonMasC.Enabled = false;
                BotonMenosC.Enabled = false;
                admin = false;
            }
            else
            {
                admin = true;
            }
        }
        private void FiltrarPorFecha(object sender, EventArgs e)
        {
            List<Cliente> clientesFiltrados = listaActual;
            clientesFiltrados = clientesFiltrados.Where(c => c.FechaCreacion.Date >= FechaDesde.Value.Date).ToList();
            if (FechaHasta.Value.Date < FechaDesde.Value.Date)
            {
                MessageBox.Show("La fecha máxima no puede ser anterior a la fecha mínima. Por favor, ajusta las fechas.", "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FechaHasta.Value = FechaDesde.Value.Date;
                return;
            }
            clientesFiltrados = clientesFiltrados.Where(c => c.FechaCreacion.Date <= FechaHasta.Value.Date).ToList();
            dgvCliente.DataSource = clientesFiltrados;
        }
        private async void buscarClientes(string nombreFiltro)
        {
           //Lo que sea
            if (dgvCliente.Columns["Dni"] != null)
            {
                dgvCliente.Columns["Dni"].Width = 80;
                dgvCliente.Columns["Dni"].Resizable = DataGridViewTriState.False;
            }
            if (dgvCliente.Columns["Nombre"] != null)
            {
                //dgvCliente.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCliente.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCliente.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCliente.Columns["Nombre"].FillWeight = 30;
                dgvCliente.Columns["Nombre"].MinimumWidth = 100;
            }
            if (dgvCliente.Columns["Apellidos"] != null)
            {
                //dgvCliente.Columns["Apellidos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCliente.Columns["Apellidos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCliente.Columns["Apellidos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCliente.Columns["Apellidos"].FillWeight = 30;
                dgvCliente.Columns["Apellidos"].MinimumWidth = 120;
            }
            if (dgvCliente.Columns["Email"] != null)
            {
                //dgvCliente.Columns["Email"].Width = 250;
                //dgvCliente.Columns["Email"].Resizable = DataGridViewTriState.False;
                dgvCliente.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCliente.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCliente.Columns["Email"].FillWeight = 40;
                dgvCliente.Columns["Email"].MinimumWidth = 150;
            }
            if (dgvCliente.Columns["FechaCreacion"] != null)
            {
                dgvCliente.Columns["FechaCreacion"].Width = 120;
                dgvCliente.Columns["FechaCreacion"].Resizable = DataGridViewTriState.False;
            }
            if (dgvCliente.Columns["FechaModificacion"] != null)
            {
                dgvCliente.Columns["FechaModificacion"].Width = 130;
                dgvCliente.Columns["FechaModificacion"].Resizable = DataGridViewTriState.False;
            }
        }
        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            buscarClientes(textBoxCliente.Text);
        }

        private async void BotonMasC_Click(object sender, EventArgs e)
        {
            Log.Info("Abriendo formulario para crear un nuevo cliente.");
            Cliente nuevoCliente = new Cliente();
            var formNuevo = new ClienteDetailForm(nuevoCliente);

            formNuevo.ClienteCreadoCorrectamente += async cliente =>
            {
                if (!string.IsNullOrEmpty(cliente.Dni))
                {
                    buscarClientes(textBoxCliente.Text);

                    var actualizarClienteForm = new ClienteDetailForm(cliente);
                    WindowManager.ShowForm(
                        $"{cliente.Dni}_Actualizar",
                        this,
                        () => actualizarClienteForm);

                    actualizarClienteForm.ClienteCreadoCorrectamente += async updatedCliente =>
                    {
                        if (!string.IsNullOrEmpty(updatedCliente.Dni) && !string.IsNullOrEmpty(updatedCliente.Nombre) && !string.IsNullOrEmpty(updatedCliente.Apellidos) && !string.IsNullOrEmpty(updatedCliente.Email))
                        {
                            buscarClientes(textBoxCliente.Text);
                        }
                    };
                }
            };
            WindowManager.ShowForm(
                "Cliente_Nuevo",
                this,
                () => formNuevo);
        }

        private async void BotonMenosC_Click(object sender, EventArgs e)
        {
            
        }

        private async void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private async Task SeleccionarCliente(string dni)
        {
            
        }
        private void Boton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(255, 59, 48);
                btn.ForeColor = Color.White;
            }
        }
        private void Boton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(225, 6, 0);
                btn.ForeColor = SystemColors.ControlLightLight;
            }
        }
        private void textBoxNombreCliente_EnterClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarClientes(textBoxCliente.Text);
            }
        }
        private void BotonHelpC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En esta sección puedes gestionar los clientes. Usa el botón '+' para agregar un nuevo cliente, el botón '-' para eliminar el cliente seleccionado, y haz doble clic en un cliente para editar su información.", "Ayuda - Gestión de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Filtros_Click(object sender, EventArgs e)
        {
            
        }
        private void RegistrarClicks(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c == panelFiltros || c == Filtros)
                    continue;

                c.Click += CerrarPanelClickFuera;

                if (c.HasChildren)
                    RegistrarClicks(c);
            }

            parent.Click += CerrarPanelClickFuera;
        }
        private void CerrarPanelClickFuera(object sender, EventArgs e)
        {
            if (panelFiltros.Visible)
            {
                Point mousePos = this.PointToClient(Cursor.Position);

                if (!panelFiltros.Bounds.Contains(mousePos))
                {
                    panelFiltros.Visible = false;
                    Log.Info("Cerrando panel de filtros al hacer clic fuera del panel.");
                    Filtros.Text = "▼  Abrir Filtros";
                }
            }
        }
    }
}
