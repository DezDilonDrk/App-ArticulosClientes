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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Articulos_Frontend
{
    public partial class PedidoForm : Form
    {
        private PedidoApiClient PedidoApiClient;
        private string state;
        private ErrorProvider errorProvider;
        private List<Pedido> listaActual;
        private List<Pedido> listaFiltrada;
        private StringValuesSP stringValuesSP = new StringValuesSP();
        public PedidoForm(string state)
        {
            this.state = state;
            InitializeComponent();
            string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
            PedidoApiClient = new PedidoApiClient();
            StyleManager.StyleForm(this);
            this.ActiveControl = textBoxCliente;
            if (state == "Pedidos")
            {
                checkAbiertos.Checked = true;
                checkCerrados.Checked = true;
                checkCancelados.Checked = true;
                this.Text = stringValuesSP.listaPedidos;
            }
            if (state == "Envios")
            {
                checkAbiertos.Checked = true;
                checkCerrados.Checked = false;
                checkCancelados.Checked = false;
                FiltroEstadoPedido.Enabled = false;
                this.Text = stringValuesSP.listaEnvios;
            }
            dgvPedido.DataSource = PedidoApiClient.ObtenerPedidos();
            Log.Info("Formulario de pedidos iniciado.");
        }
        private void PedidosForm_Load(object sender, EventArgs e)
        {
            Log.Info("Cargando pedidos en el formulario.");
            RegistrarClicks(this);
            buscarPedidos(null);
        }
        private void VerifyStateAndApply(object sender, EventArgs e)
        {
            if (sender as CheckBox != null)
            {
                CheckBox checkBox = sender as CheckBox;
                if (!checkAbiertos.Checked && !checkCerrados.Checked && !checkCancelados.Checked)
                {
                    checkBox.Checked = !checkBox.Checked;
                    return;
                }
            }
            AplicarFiltros();
        }
        private void AplicarFiltros(object sender, EventArgs e)
        {
            AplicarFiltros();
        }
        private void AplicarFiltros() {
            if (listaActual == null) return;
            var pedidosFiltrados = listaActual;
            if (FechaHasta.Value.Date < FechaDesde.Value.Date)
            {
                MessageBox.Show("La fecha máxima no puede ser anterior a la fecha mínima. Por favor, ajusta las fechas.", "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FechaHasta.Value = FechaDesde.Value.Date;
                return;
            } else {
                pedidosFiltrados = pedidosFiltrados.Where(c => c.fecha_creacion <= FechaHasta.Value.Date && c.fecha_creacion >= FechaDesde.Value.Date).ToList();
            }
            if (dtpHasta2.Value.Date < dtpDesde2.Value.Date)
            {
                MessageBox.Show("La fecha máxima no puede ser anterior a la fecha mínima. Por favor, ajusta las fechas.", "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpHasta2.Value = dtpDesde2.Value.Date;
                return;
            } else {
                pedidosFiltrados = pedidosFiltrados.Where(p => p.fecha_envio >= dtpDesde2.Value.Date && p.fecha_envio <= dtpHasta2.Value.Date).ToList();
            }
            var estados = new List<string>();
            if (checkAbiertos.Checked) estados.Add("Abierto");
            if (checkCerrados.Checked) estados.Add("Cerrado");
            if (checkCancelados.Checked) estados.Add("Cancelado");
            pedidosFiltrados = pedidosFiltrados.Where(p => estados.Contains(p.estado)).ToList();
            listaFiltrada = pedidosFiltrados.ToList();
            dgvPedido.DataSource = listaFiltrada;
        }
        private async void buscarPedidos(string nombreFiltro)
        {
            Log.Info($"Buscando pedidos: '{nombreFiltro}'");
            IEnumerable<Pedido> pedidos;
            if (string.IsNullOrEmpty(nombreFiltro))
            {
                pedidos = await PedidoApiClient.ObtenerPedidos();
            }
            else
            {
                pedidos = await PedidoApiClient.ObtenerPedidosPorNombreCliente(nombreFiltro);
            }
            listaActual = pedidos.ToList();
            AplicarFiltros();
            if (dgvPedido.Columns["dni_cliente"] != null)
            {
                dgvPedido.Columns["dni_cliente"].HeaderText = "DNI del Cliente";
                dgvPedido.Columns["dni_cliente"].Width = 80;
                dgvPedido.Columns["dni_cliente"].Resizable = DataGridViewTriState.False;
            }
            if (dgvPedido.Columns["porcentaje_impuestos"] != null)
            {
                //dgvCliente.Columns["porcentaje"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvCliente.Columns["porcentaje"].FillWeight = 30;
                dgvPedido.Columns["porcentaje_impuestos"].MinimumWidth = 10;
                dgvPedido.Columns["porcentaje_impuestos"].HeaderText = "Porcentaje de Impuestos";
            }
            if (dgvPedido.Columns["nombre_cliente"] != null)
            {
                dgvPedido.Columns["nombre_cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPedido.Columns["nombre_cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvPedido.Columns["nombre_cliente"].HeaderText = "Nombre del Cliente";
            }
            if (dgvPedido.Columns["id_pedido"] != null)
            {
                //dgvCliente.Columns["id_pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvCliente.Columns["id_pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvCliente.Columns["id_pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvCliente.Columns["id_pedido"].FillWeight = 30;
                dgvPedido.Columns["id_pedido"].Resizable = DataGridViewTriState.False;
                dgvPedido.Columns["id_pedido"].MinimumWidth = 270;
                dgvPedido.Columns["id_pedido"].HeaderText = "Id del Pedido";
            }
            if (dgvPedido.Columns["id_cliente"] != null)
            {
                dgvPedido.Columns["id_cliente"].Resizable = DataGridViewTriState.False;
                dgvPedido.Columns["id_cliente"].MinimumWidth = 270;
                dgvPedido.Columns["id_cliente"].HeaderText = "Id del Cliente";
            }
            if (dgvPedido.Columns["estado"] != null)
            {
                //dgvCliente.Columns["estado"].Width = 250;
                //dgvCliente.Columns["estado"].Resizable = DataGridViewTriState.False;
                //dgvCliente.Columns["estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvCliente.Columns["estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvCliente.Columns["estado"].FillWeight = 40;
                dgvPedido.Columns["estado"].Width = 150;
                dgvPedido.Columns["estado"].HeaderText = "Estado";
                dgvPedido.Columns["estado"].Resizable = DataGridViewTriState.False;
            }
            if (dgvPedido.Columns["metodo_pago"] != null)
            {
                //dgvCliente.Columns["metodo_pago"].Width = 250;
                //dgvCliente.Columns["metodo_pago"].Resizable = DataGridViewTriState.False;
                //dgvCliente.Columns["metodo_pago"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvCliente.Columns["metodo_pago"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvCliente.Columns["metodo_pago"].FillWeight = 40;
                dgvPedido.Columns["metodo_pago"].Width = 150;
                dgvPedido.Columns["metodo_pago"].Resizable = DataGridViewTriState.False;
                dgvPedido.Columns["metodo_pago"].HeaderText = "Método de Pago";
                dgvPedido.Columns["metodo_pago"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
                if (dgvPedido.Columns["fecha_creacion"] != null)
            {
                dgvPedido.Columns["fecha_creacion"].Width = 120;
                dgvPedido.Columns["fecha_creacion"].Resizable = DataGridViewTriState.False;
                dgvPedido.Columns["fecha_creacion"].HeaderText = "Fecha de Creación";
            }
            if (dgvPedido.Columns["fecha_rectificacion"] != null) {
                dgvPedido.Columns["fecha_rectificacion"].Width = 130;
                dgvPedido.Columns["fecha_rectificacion"].Resizable = DataGridViewTriState.False;
                dgvPedido.Columns["fecha_rectificacion"].HeaderText = "Fecha de Rectificación";
            }
            if (dgvPedido.Columns["fecha_envio"] != null)
            {
                dgvPedido.Columns["fecha_envio"].Width = 130;
                dgvPedido.Columns["fecha_envio"].Resizable = DataGridViewTriState.False;
                dgvPedido.Columns["fecha_envio"].HeaderText = "Fecha de Envio";
            }
            if (dgvPedido.Columns["nombre"] != null)
            {
                dgvPedido.Columns["nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPedido.Columns["nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvPedido.Columns["nombre"].Resizable = DataGridViewTriState.False;
                dgvPedido.Columns["nombre"].HeaderText = "Nombre";
            }
        }
        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            buscarPedidos(textBoxCliente.Text);
        }

        private async void BotonMasC_Click(object sender, EventArgs e)
        {
            Log.Info("Abriendo formulario para crear un nuevo pedido.");
            var formNuevo = new PedidoDetailForm("Create");

            formNuevo.PedidoModificadoCorrectamente += async pedido =>
            {
                if (pedido.id_pedido != null)
                {
                    var actualizarForm = new PedidoDetailForm("Update");
                    Log.Warn("Si entra por aquí");
                    WindowManager.ShowForm(
                    $"{pedido.id_pedido}_Actualizar",
                    this,
                    () => actualizarForm);
                    actualizarForm.PedidoModificadoCorrectamente += async p => {
                        buscarPedidos(textBoxCliente.Text);
                    };
                }
            };
            var pedidoDetailForm = new PedidoDetailForm("Create");
            WindowManager.ShowForm(
                "Pedido_Nuevo",
                this,
                () => pedidoDetailForm);
                pedidoDetailForm.PedidoModificadoCorrectamente += async p =>
                {
                    buscarPedidos(textBoxCliente.Text); 
                };
        }

        private async void BotonMenosC_Click(object sender, EventArgs e)
        {
            Log.Info("Pulsa el botón de eliminar");
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Warning, new Exception("¿Confirma que desea eliminar este pedido?"));
            alerta.ShowDialog();
            if (alerta.resultado)
            {
                Log.Info($"Eliminando pedido con ID: {dgvPedido.CurrentRow.Cells["id_pedido"].Value.ToString()}");
                await PedidoApiClient.Eliminar(dgvPedido.CurrentRow.Cells["id_pedido"].Value.ToString());
            }
            else
            {
                Log.Info("Eliminación cancelada por el usuario.");
            }
            buscarPedidos(textBoxCliente.Text);
        }

        private async void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Log.Info("Doble clic en cliente para editar la información.");
            if (e.RowIndex >= 0)
            {
                string id = dgvPedido.Rows[e.RowIndex].Cells["id_pedido"].Value.ToString();
                Pedido pedido = await PedidoApiClient.BuscarPorIdPedido(id);
                var formActualizado = new PedidoDetailForm("Update", pedido);
                WindowManager.ShowForm(
                        $"{id}_Actualizar",
                        this,
                       () => formActualizado);
                formActualizado.PedidoModificadoCorrectamente += async p => {
                    buscarPedidos(textBoxCliente.Text);
                };
            }
        }
        private void Boton_MouseEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(255, 59, 48);
                btn.ForeColor = Color.White;
            }
        }
        private void Boton_MouseLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
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
                buscarPedidos(textBoxCliente.Text);
            }
        }
        private void BotonHelpC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En esta sección puedes gestionar los clientes. Usa el botón '+' para agregar un nuevo cliente, el botón '-' para eliminar el cliente seleccionado, y haz doble clic en un cliente para editar su información.", "Ayuda - Gestión de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Filtros_Click(object sender, EventArgs e)
        {   Filtros.Focus();
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
            foreach (Control c in parent.Controls)
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
