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
            comboBoxEstado.DataSource = estados.ToList();
            comboBoxEstado.SelectedIndex = -1;
            textBoxId.Text = pedido.id_pedido.ToString();
            textBoxDniCliente.Text = pedido.dni_cliente;
            textBoxMetodoPago.Text = pedido.metodo_pago;
            comboBoxEstado.Text = pedido.estado;
            textBoxImpuestos.Text = pedido.porcentaje_impuestos.ToString();
        }
        private void InitializeComponent()
        {
            textBoxDniCliente = new TextBox();
            textBoxMetodoPago = new TextBox();
            textBoxImpuestos = new TextBox();
            LabelIdPedido = new Label();
            LabelDniCliente = new Label();
            LabelMetodoPago = new Label();
            LabelEstado = new Label();
            BotonCrearC = new Button();
            LabelTitulo = new Label();
            textBoxId = new TextBox();
            LabelImpuestos = new Label();
            comboBoxEstado = new ComboBox();
            SuspendLayout();
            // 
            // textBoxDniCliente
            // 
            textBoxDniCliente.Location = new Point(237, 116);
            textBoxDniCliente.Name = "textBoxDniCliente";
            textBoxDniCliente.PlaceholderText = "Introduzca el dni del cliente";
            textBoxDniCliente.Size = new Size(247, 23);
            textBoxDniCliente.TabIndex = 0;
            textBoxDniCliente.DoubleClick += textBoxDniCliente_DoubleClick;
            // 
            // textBoxMetodoPago
            // 
            textBoxMetodoPago.Location = new Point(237, 145);
            textBoxMetodoPago.Name = "textBoxMetodoPago";
            textBoxMetodoPago.PlaceholderText = "Introduzca el método de pago";
            textBoxMetodoPago.Size = new Size(247, 23);
            textBoxMetodoPago.TabIndex = 1;
            // 
            // textBoxImpuestos
            // 
            textBoxImpuestos.Location = new Point(237, 203);
            textBoxImpuestos.Name = "textBoxImpuestos";
            textBoxImpuestos.PlaceholderText = "Introduzca el porcentaje de impuestos";
            textBoxImpuestos.Size = new Size(247, 23);
            textBoxImpuestos.TabIndex = 3;
            // 
            // LabelIdPedido
            // 
            LabelIdPedido.BackColor = Color.Transparent;
            LabelIdPedido.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelIdPedido.Location = new Point(69, 89);
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
            LabelDniCliente.Location = new Point(69, 118);
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
            LabelMetodoPago.Location = new Point(69, 147);
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
            LabelEstado.Location = new Point(69, 176);
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
            BotonCrearC.Location = new Point(301, 247);
            BotonCrearC.Name = "BotonCrearC";
            BotonCrearC.Size = new Size(150, 30);
            BotonCrearC.TabIndex = 5;
            BotonCrearC.Text = "Actualizar";//Es el "Crear" de este UpdateForm de Pedidos
            BotonCrearC.UseVisualStyleBackColor = false;
            BotonCrearC.Click += BotonActualizarC_Click;
            // 
            // LabelTitulo
            // 
            LabelTitulo.BackColor = Color.Transparent;
            LabelTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            LabelTitulo.Location = new Point(135, 18);
            LabelTitulo.Name = "LabelTitulo";
            LabelTitulo.Size = new Size(316, 36);
            LabelTitulo.TabIndex = 0;
            LabelTitulo.Tag = "title";
            LabelTitulo.Text = stringValuesSP.actualizarPedido;
            LabelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(237, 87);
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
            LabelImpuestos.Location = new Point(69, 205);
            LabelImpuestos.Name = "LabelImpuestos";
            LabelImpuestos.Size = new Size(162, 21);
            LabelImpuestos.TabIndex = 11;
            LabelImpuestos.Tag = "normalText";
            LabelImpuestos.Text = "Impuestos (%): ";
            LabelImpuestos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxMetodo
            // 
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstado.FormattingEnabled = true;
            comboBoxEstado.Location = new Point(237, 174);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(247, 23);
            comboBoxEstado.TabIndex = 12;
            comboBoxEstado.Tag = "comboBox";
            comboBoxEstado.FlatStyle = FlatStyle.Flat;
            // 
            // PedidoUpdateForm
            // 
            ClientSize = new Size(580, 363);
            Controls.Add(comboBoxEstado);
            Controls.Add(LabelImpuestos);
            Controls.Add(textBoxId);
            Controls.Add(LabelTitulo);
            Controls.Add(BotonCrearC);
            Controls.Add(LabelEstado);
            Controls.Add(LabelMetodoPago);
            Controls.Add(LabelDniCliente);
            Controls.Add(LabelIdPedido);
            Controls.Add(textBoxImpuestos);
            Controls.Add(textBoxMetodoPago);
            Controls.Add(textBoxDniCliente);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(596, 402);
            MinimumSize = new Size(596, 402);
            Name = "PedidoUpdateForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();

        }

        private async void BotonActualizarC_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxDniCliente.Text) && !string.IsNullOrEmpty(textBoxImpuestos.Text) && !string.IsNullOrEmpty(textBoxId.Text) && !string.IsNullOrEmpty(textBoxMetodoPago.Text) && ValidarDni(textBoxDniCliente.Text))
            {
                Log.Info("Intento de actualización de pedido con Id: " + textBoxId.Text);
                try
                {
                    pedido.ActualizarPedido(textBoxDniCliente.Text,textBoxMetodoPago.Text,double.Parse(textBoxImpuestos.Text), comboBoxEstado.Text,pedido.articulos);
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
        private bool ValidarDni(string dni)
        {
            if (textBoxDniCliente.Text.Length != 9)
            {
                Log.Warn($"Intento de crear cliente con DNI de longitud incorrecta: {dni}.");
                MessageBox.Show("El DNI debe tener 9 caracteres, 8 números y una letra mayúscula al final. Ejemplo: 12345678A", "DNI no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(dni, @"^\d{8}[A-Za-z]$"))
            {
                Log.Warn($"Intento de crear cliente con DNI con formato incorrecto: {dni}.");
                MessageBox.Show("El DNI debe tener 9 caracteres, 8 números y una letra mayúscula al final. Ejemplo: 12345678A", "DNI no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            int numero;
            try
            { numero = int.Parse(dni.Substring(0, 8)); }
            catch
            {
                Log.Warn($"Intento de crear cliente con DNI cuyos primeros 8 caracteres no son numéricos: {dni}.");
                MessageBox.Show("Los primeros 8 caracteres del DNI deben ser números. Ejemplo: 12345678A", "DNI no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            char letraCalculada = letras[numero % 23];
            if (char.ToUpper(dni[8]) != letraCalculada)
            {
                Log.Warn($"Intento de crear cliente con DNI cuya letra ({letraCalculada}) no coincide con el número: {dni}.");
                MessageBox.Show("La letra del DNI no es correcta. Ejemplo: 12345678A", "DNI no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void textBoxDniCliente_DoubleClick(object sender, EventArgs e)
        {
           using (var form = new ClienteForm())
            {
                form.ModoInvocacion = "CrearPedido";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    textBoxDniCliente.Text = form.DniSeleccionado;
                    Log.Info($"Cliente seleccionado para pedido con Dni: {form.DniSeleccionado}");
                }
            }
        }
    }
}
