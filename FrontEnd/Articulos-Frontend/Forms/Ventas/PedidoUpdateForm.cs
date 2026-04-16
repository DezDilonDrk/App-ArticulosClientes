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

namespace Articulos_Frontend
{
    public partial class PedidoUpdateForm : Form
    {
        private PedidoApiClient pedidoApiClient;
        private ClienteApiClient clienteApiClient = new ClienteApiClient();
        private Pedido pedido;
        public event Action<Pedido> PedidoActualizadoCorrectamente;
        private StringValuesSP stringValuesSP = new StringValuesSP();
        public PedidoUpdateForm(Pedido pedido)
        {
            InitializeComponent();
            this.pedido = pedido;
            string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
            pedidoApiClient = new PedidoApiClient();
            StyleManager.StyleForm(this);
            var estados = new[] { "Abierto", "Cerrado", "Cancelado" };
            var impuestos = new[] { "21", "10", "4", "0" };
            var metodosPago = new List<string> { "Tarjeta de Crédito", "PayPal", "Transferencia Bancaria", "Contra Reembolso" };
            comboBoxEstado.DataSource = estados.ToList();
            comboBoxEstado.SelectedIndex = -1;
            comboBoxImpuestos.DataSource = impuestos.ToList();
            comboBoxImpuestos.SelectedIndex = -1;
            comboBoxMetodoPago.DataSource = metodosPago;
            comboBoxMetodoPago.SelectedIndex = -1;
            textBoxId.Text = pedido.id_pedido.ToString();
            textBoxDniCliente.Text = pedido.dni_cliente;
            comboBoxMetodoPago.Text = pedido.metodo_pago;
            comboBoxEstado.Text = pedido.estado;
            comboBoxImpuestos.Text = pedido.porcentaje_impuestos.ToString();
        }
        private void InitializeComponent()
        {
            textBoxDniCliente = new TextBox();
            LabelIdPedido = new Label();
            LabelDniCliente = new Label();
            LabelMetodoPago = new Label();
            LabelEstado = new Label();
            BotonCrearC = new Button();
            LabelTitulo = new Label();
            textBoxId = new TextBox();
            LabelImpuestos = new Label();
            comboBoxEstado = new ComboBox();
            comboBoxImpuestos = new ComboBox();
            comboBoxMetodoPago = new ComboBox();
            dataGridViewArticulos = new DataGridView();
            ((ISupportInitialize)dataGridViewArticulos).BeginInit();
            SuspendLayout();
            // 
            // textBoxDniCliente
            // 
            textBoxDniCliente.Location = new Point(237, 111);
            textBoxDniCliente.Name = "textBoxDniCliente";
            textBoxDniCliente.PlaceholderText = "Introduzca el dni del cliente";
            textBoxDniCliente.Size = new Size(247, 23);
            textBoxDniCliente.TabIndex = 0;
            textBoxDniCliente.DoubleClick += textBoxDniCliente_DoubleClick;
            // 
            // LabelIdPedido
            // 
            LabelIdPedido.BackColor = Color.Transparent;
            LabelIdPedido.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelIdPedido.Location = new Point(69, 84);
            LabelIdPedido.Name = "LabelIdPedido";
            LabelIdPedido.Size = new Size(162, 21);
            LabelIdPedido.TabIndex = 4;
            LabelIdPedido.Tag = "normalText";
            LabelIdPedido.Text = "Id del Pedido: ";
            LabelIdPedido.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelDniCliente
            // 
            LabelDniCliente.BackColor = Color.Transparent;
            LabelDniCliente.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelDniCliente.Location = new Point(69, 113);
            LabelDniCliente.Name = "LabelDniCliente";
            LabelDniCliente.Size = new Size(162, 21);
            LabelDniCliente.TabIndex = 5;
            LabelDniCliente.Tag = "normalText";
            LabelDniCliente.Text = "Dni del Cliente: ";
            LabelDniCliente.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelMetodoPago
            // 
            LabelMetodoPago.BackColor = Color.Transparent;
            LabelMetodoPago.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelMetodoPago.Location = new Point(69, 142);
            LabelMetodoPago.Name = "LabelMetodoPago";
            LabelMetodoPago.Size = new Size(162, 21);
            LabelMetodoPago.TabIndex = 6;
            LabelMetodoPago.Tag = "normalText";
            LabelMetodoPago.Text = "Método de Pago: ";
            LabelMetodoPago.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelEstado
            // 
            LabelEstado.BackColor = Color.Transparent;
            LabelEstado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelEstado.Location = new Point(69, 171);
            LabelEstado.Name = "LabelEstado";
            LabelEstado.Size = new Size(162, 21);
            LabelEstado.TabIndex = 7;
            LabelEstado.Tag = "normalText";
            LabelEstado.Text = "Estado: ";
            LabelEstado.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BotonCrearC
            // 
            BotonCrearC.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BotonCrearC.AutoSize = true;
            BotonCrearC.BackColor = SystemColors.MenuHighlight;
            BotonCrearC.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BotonCrearC.ForeColor = SystemColors.ControlLightLight;
            BotonCrearC.Location = new Point(418, 392);
            BotonCrearC.Name = "BotonCrearC";
            BotonCrearC.Size = new Size(150, 30);
            BotonCrearC.TabIndex = 5;
            BotonCrearC.Text = "Actualizar";
            BotonCrearC.UseVisualStyleBackColor = false;
            BotonCrearC.Click += BotonActualizarC_Click;
            // 
            // LabelTitulo
            // 
            LabelTitulo.BackColor = Color.Transparent;
            LabelTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            LabelTitulo.Location = new Point(190, 9);
            LabelTitulo.Name = "LabelTitulo";
            LabelTitulo.Size = new Size(316, 36);
            LabelTitulo.TabIndex = 0;
            LabelTitulo.Tag = "title";
            LabelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(237, 82);
            textBoxId.Name = "textBoxId";
            textBoxId.PlaceholderText = "Introduzca el id";
            textBoxId.ReadOnly = true;
            textBoxId.Size = new Size(247, 23);
            textBoxId.TabIndex = 10;
            // 
            // LabelImpuestos
            // 
            LabelImpuestos.BackColor = Color.Transparent;
            LabelImpuestos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelImpuestos.Location = new Point(69, 200);
            LabelImpuestos.Name = "LabelImpuestos";
            LabelImpuestos.Size = new Size(162, 21);
            LabelImpuestos.TabIndex = 11;
            LabelImpuestos.Tag = "normalText";
            LabelImpuestos.Text = "Impuestos (%): ";
            LabelImpuestos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxEstado
            // 
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstado.FlatStyle = FlatStyle.Flat;
            comboBoxEstado.FormattingEnabled = true;
            comboBoxEstado.Location = new Point(237, 169);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(247, 23);
            comboBoxEstado.TabIndex = 12;
            comboBoxEstado.Tag = "comboBox";
            // 
            // comboBoxImpuestos
            // 
            comboBoxImpuestos.FormattingEnabled = true;
            comboBoxImpuestos.Location = new Point(237, 198);
            comboBoxImpuestos.Name = "comboBoxImpuestos";
            comboBoxImpuestos.Size = new Size(247, 23);
            comboBoxImpuestos.TabIndex = 13;
            comboBoxImpuestos.Tag = "comboBox";
            // 
            // comboBoxMetodoPago
            // 
            comboBoxMetodoPago.FormattingEnabled = true;
            comboBoxMetodoPago.Location = new Point(237, 140);
            comboBoxMetodoPago.Name = "comboBoxMetodoPago";
            comboBoxMetodoPago.Size = new Size(247, 23);
            comboBoxMetodoPago.TabIndex = 14;
            comboBoxMetodoPago.Tag = "comboBox";
            // 
            // dgvPedido
            // 
            dataGridViewArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewArticulos.Location = new Point(12, 236);
            dataGridViewArticulos.Name = "dgvPedido";
            dataGridViewArticulos.Size = new Size(556, 150);
            dataGridViewArticulos.TabIndex = 15;
            // 
            // PedidoUpdateForm
            // 
            ClientSize = new Size(704, 434);
            Controls.Add(dataGridViewArticulos);
            Controls.Add(comboBoxMetodoPago);
            Controls.Add(comboBoxImpuestos);
            Controls.Add(comboBoxEstado);
            Controls.Add(LabelImpuestos);
            Controls.Add(textBoxId);
            Controls.Add(LabelTitulo);
            Controls.Add(BotonCrearC);
            Controls.Add(LabelEstado);
            Controls.Add(LabelMetodoPago);
            Controls.Add(LabelDniCliente);
            Controls.Add(LabelIdPedido);
            Controls.Add(textBoxDniCliente);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimumSize = new Size(596, 402);
            Name = "PedidoUpdateForm";
            StartPosition = FormStartPosition.CenterParent;
            ((ISupportInitialize)dataGridViewArticulos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private async void BotonActualizarC_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxDniCliente.Text) && !string.IsNullOrEmpty(comboBoxImpuestos.Text) && !string.IsNullOrEmpty(textBoxId.Text) && !string.IsNullOrEmpty(comboBoxMetodoPago.Text))
            {
                Log.Info("Intento de actualización de pedido con Id: " + textBoxId.Text);
                if (!await ValidarDni(textBoxDniCliente.Text))
                {
                    MessageBox.Show("El Dni introducido no corresponde a ningún cliente registrado. Por favor, introduzca un Dni válido o cree un nuevo cliente.", "Dni no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Log.Error($"No se encontró ningún cliente con Dni: {textBoxDniCliente.Text}. Id del pedido donde se produjo este error: {textBoxId.Text}");
                    return;
                }
                try
                {
                    pedido.ActualizarPedido(textBoxDniCliente.Text, comboBoxMetodoPago.Text,double.Parse(comboBoxImpuestos.Text), comboBoxEstado.Text,pedido.articulos);
                    await pedidoApiClient.Actualizar(pedido.id_pedido, pedido);
                    MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PedidoActualizadoCorrectamente?.Invoke(pedido);
                    Log.Info("Pedido actualizado correctamente: " + pedido.id_pedido);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al crear el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error("Error al actualizar el cliente: " + ex.Message);
                }
            }
            else
            {
                Log.Warn("Intento de actualizar cliente con campos incompletos.");
                MessageBox.Show("Por favor, rellene todos los campos para crear el cliente.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async Task<bool> ValidarDni(string dni)
        {
            IEnumerable<Cliente> clientes = await clienteApiClient.ObtenerClientes();
            if (!clientes.Any(c => c.Dni == dni))
            {
                Log.Warn("Dni no encontrado en la base de datos: " + dni);
                MessageBox.Show("El Dni introducido no corresponde a ningún cliente registrado. Por favor, introduzca un Dni válido o cree un nuevo cliente.", "Dni no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void textBoxDniCliente_DoubleClick(object sender, EventArgs e)
        {
           using (var form = new ClienteForm())
            {
                form.ModoInvocacion = "ActualizarPedido";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    textBoxDniCliente.Text = form.DniSeleccionado;
                    Log.Info($"Cliente seleccionado para actualizar pedido con Dni: {form.DniSeleccionado}");
                }
            }
        }
    }
}
