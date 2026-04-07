/* using Articulos_Frontend.Client;
using MTCore_AC.Entidades;
using Articulos_Frontend.LogConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Articulos_Frontend
{
    public partial class PedidoForm : Form
    {
        public PedidoForm()
        {
            InitializeComponent();
        }
        private void ClienteForm_Load(object sender, EventArgs e)
        {
            Log.Info("Cargando clientes en el formulario.");
            buscarClientes(null);
            RegistrarClicks(this);
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
            Log.Info($"Buscando clientes: '{nombreFiltro}'");
            IEnumerable<Cliente> clientes;
            if (string.IsNullOrWhiteSpace(nombreFiltro))
            {
                clientes = await ClienteApiClient.ObtenerClientes();
            }
            else
            {
                clientes = await ClienteApiClient.BuscarPorNombre(nombreFiltro);
            }
            clientes = clientes.Where(c => c.FechaCreacion.Date >= FechaDesde.Value.Date);
            clientes = clientes.Where(c => c.FechaCreacion.Date <= FechaHasta.Value.Date);
            dgvCliente.DataSource = clientes.ToList();
            listaActual = clientes.ToList();
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

                    WindowManager.ShowForm(
                        $"{cliente.Dni}_Actualizar",
                        this,
                        () => new ClienteUpdateForm(cliente));
                }
            };
            WindowManager.ShowForm(
                "Cliente_Nuevo",
                this,
                () => formNuevo);
        }

        private async void BotonMenosC_Click(object sender, EventArgs e)
        {
            Log.Info("Pulsa el botón de eliminar");
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Warning, new Exception("¿Confirma que desea eliminar este cliente?"));
            alerta.ShowDialog();
            if (alerta.resultado)
            {
                Log.Info($"Eliminando cliente con DNI: {dgvCliente.CurrentRow.Cells["Dni"].Value.ToString()}");
                await ClienteApiClient.Eliminar(dgvCliente.CurrentRow.Cells["Dni"].Value.ToString());
            }
            else
            {
                Log.Info("Eliminación cancelada por el usuario.");
            }
            buscarClientes(textBoxCliente.Text);
        }

        private async void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Log.Info("Doble clic en cliente para editar la información.");
            if (e.RowIndex >= 0)
            {
                string dni = dgvCliente.Rows[e.RowIndex].Cells["Dni"].Value.ToString();
                Cliente cliente = await ClienteApiClient.ObtenerPorDni(dni);
                var formActualizado = new ClienteUpdateForm(cliente);

                formActualizado.ClienteActualizadoCorrectamente += async cliente =>
                {
                    if (!string.IsNullOrEmpty(cliente.Dni) && !string.IsNullOrEmpty(cliente.Nombre) && !string.IsNullOrEmpty(cliente.Apellidos) && !string.IsNullOrEmpty(cliente.Email))
                    {
                        buscarClientes(textBoxCliente.Text);
                    }
                };
                WindowManager.ShowForm(
                        $"{dni}_Actualizar",
                        this,
                        () => formActualizado);

            }
        }
        private async Task SeleccionarCliente(string dni)
        {
            for (int i = 0; i < dgvCliente.Rows.Count; i++)
            {
                if (dgvCliente.Rows[i].Cells["Dni"].Value?.ToString() == dni)
                {
                    dgvCliente.ClearSelection();
                    dgvCliente.Rows[i].Selected = true;
                    dgvCliente.CurrentCell = dgvCliente.Rows[i].Cells[0];
                    dgvCliente.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
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
            /*if (!panelFiltros.Visible)
            {
                animAbriendo = true;
                panelFiltros.Visible = true;
                panelFiltros.Width = 0;
                Filtros.Text = "◀ Cerrar Filtros";
                animTimer.Start();
            }
            else
            {
                animAbriendo = false;
                Filtros.Text = "▼  Abrir Filtros";
                animTimer.Start();
            }

            Filtros.Focus();
            panelFiltros.Visible = !panelFiltros.Visible;

            if (panelFiltros.Visible)
            {
                Log.Info("Abriendo panel de filtros.");
                Filtros.Text = "◀ Cerrar Filtros";
            }
            else
            {
                Log.Info("Cerrando panel de filtros.");
                Filtros.Text = "▼  Abrir Filtros";
            }
        }
        private void RegistrarClicks(Control parent)
        {
            /*foreach (Control c in parent.Controls)
            {
                if (c == panelFiltros || c == Filtros)
                    continue;
                c.Click += CerrarPanelClickFuera;
                if (c.HasChildren)
                    RegistrarClicks(c);
            }
            parent.Click += CerrarPanelClickFuera;
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
            /*if (!panelFiltros.Visible)
                return;

            if (animTimer.Enabled)
                return;

            Point mousePos = this.PointToClient(Cursor.Position);

            if (!panelFiltros.Bounds.Contains(mousePos))
            {
                animAbriendo = false;
                animTimer.Start();
                Filtros.Text = "▼  Abrir Filtros";
            }
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
*/