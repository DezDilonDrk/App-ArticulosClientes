using Articulos_Frontend.Client;
using Articulos_Frontend.Theme;
using Articulos_Frontend.LogConfig;
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
    public partial class PedidoDetailForm : Form
    {
        private PedidoApiClient pedidoApiClient;
        private ClienteApiClient clienteApiClient = new ClienteApiClient();
        private Pedido pedidoCreated;
        public event Action<Pedido> PedidoCreadoCorrectamente;
        private StringValuesSP stringValuesSP = new StringValuesSP();
        public PedidoDetailForm()
        {
            InitializeComponent();
            var impuestos = new List<string> { "21", "10", "4", "0" };
            var metodosPago = new List<string> { "Tarjeta de Crédito", "PayPal", "Transferencia Bancaria", "Contra Reembolso" };
            comboBoxImpuestos.DataSource = impuestos;
            comboBoxImpuestos.SelectedIndex = -1;
            comboBoxMetodoPago.DataSource = metodosPago;
            comboBoxMetodoPago.SelectedIndex = -1;
            string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
            pedidoApiClient = new PedidoApiClient();
            StyleManager.StyleForm(this);
        }


        private void InitializeComponent()
        {
            textBoxDniCliente = new TextBox();
            LabelDniCliente = new Label();
            LabelMetodoPago = new Label();
            BotonCrearC = new Button();
            LabelTitulo = new Label();
            button1 = new Button();
            LabelImpuestos = new Label();
            comboBoxImpuestos = new ComboBox();
            this.comboBoxMetodoPago = new ComboBox();
            SuspendLayout();
            // 
            // textBoxDniCliente
            // 
            textBoxDniCliente.Location = new Point(247, 137);
            textBoxDniCliente.Name = "textBoxDniCliente";
            textBoxDniCliente.PlaceholderText = "Introduzca el dni del cliente";
            textBoxDniCliente.Size = new Size(247, 23);
            textBoxDniCliente.TabIndex = 0;
            textBoxDniCliente.DoubleClick += textBoxDniCliente_DoubleClick;
            // 
            // LabelDniCliente
            // 
            LabelDniCliente.BackColor = Color.Transparent;
            LabelDniCliente.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelDniCliente.Location = new Point(79, 139);
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
            LabelMetodoPago.Location = new Point(79, 168);
            LabelMetodoPago.Name = "LabelMetodoPago";
            LabelMetodoPago.Size = new Size(162, 21);
            LabelMetodoPago.TabIndex = 6;
            LabelMetodoPago.Tag = "normalText";
            LabelMetodoPago.Text = "Método de Pago: ";
            LabelMetodoPago.TextAlign = ContentAlignment.MiddleLeft;
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
            BotonCrearC.Text = "Crear";
            BotonCrearC.UseVisualStyleBackColor = false;
            BotonCrearC.Click += BotonCrearC_Click;
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
            LabelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.Chartreuse;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(104, 251);
            button1.Name = "button1";
            button1.Size = new Size(90, 23);
            button1.TabIndex = 8;
            button1.Text = "debug";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // LabelImpuestos
            // 
            LabelImpuestos.BackColor = Color.Transparent;
            LabelImpuestos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelImpuestos.Location = new Point(79, 197);
            LabelImpuestos.Name = "LabelImpuestos";
            LabelImpuestos.Size = new Size(162, 21);
            LabelImpuestos.TabIndex = 11;
            LabelImpuestos.Tag = "normalText";
            LabelImpuestos.Text = "Impuestos (%): ";
            LabelImpuestos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxImpuestos
            // 
            comboBoxImpuestos.FormattingEnabled = true;
            comboBoxImpuestos.Location = new Point(247, 199);
            comboBoxImpuestos.Name = "comboBoxImpuestos";
            comboBoxImpuestos.Size = new Size(247, 23);
            comboBoxImpuestos.TabIndex = 12;
            comboBoxImpuestos.Tag = "comboBox";
            // 
            // comboBoxMetodoPago
            // 
            this.comboBoxMetodoPago.FormattingEnabled = true;
            this.comboBoxMetodoPago.Location = new Point(247, 168);
            this.comboBoxMetodoPago.Name = "comboBoxMetodoPago";
            this.comboBoxMetodoPago.Size = new Size(247, 23);
            this.comboBoxMetodoPago.TabIndex = 13;
            // 
            // PedidoDetailForm
            // 
            ClientSize = new Size(580, 363);
            Controls.Add(this.comboBoxMetodoPago);
            Controls.Add(comboBoxImpuestos);
            Controls.Add(LabelImpuestos);
            Controls.Add(button1);
            Controls.Add(LabelTitulo);
            Controls.Add(BotonCrearC);
            Controls.Add(LabelMetodoPago);
            Controls.Add(LabelDniCliente);
            Controls.Add(textBoxDniCliente);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(596, 402);
            MinimumSize = new Size(596, 402);
            Name = "PedidoDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();

        }

        private async void BotonCrearC_Click(object sender, EventArgs e)
        {
            if (!validarCamposLlenos()) return;
            if (!await ValidarDni(textBoxDniCliente.Text)) return;
            try
            {
                bool existePedido = false;
                double parsedImpuestos = 0;
                try
                {
                    parsedImpuestos = double.Parse(comboBoxImpuestos.Text);
                    if (parsedImpuestos < 0 || parsedImpuestos > 100)
                    {
                        Log.Warn($"Intento de crear pedido con porcentaje de impuestos fuera de rango: {comboBoxImpuestos.Text}.");
                        MessageBox.Show("El porcentaje de impuestos debe ser un número entre 0 y 100. Ejemplo: 21", "Porcentaje no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                catch (FormatException)
                {
                    Log.Warn($"Intento de crear pedido con porcentaje de impuestos no numérico: {comboBoxImpuestos.Text}.");
                    MessageBox.Show("El porcentaje de impuestos debe ser un número entre 0 y 100. Ejemplo: 21", "Porcentaje no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                pedidoCreated = new Pedido(textBoxDniCliente.Text.ToUpper(), comboBoxMetodoPago.Text, parsedImpuestos);
                PedidoArticulos articulo1 = new PedidoArticulos(pedidoCreated.id_pedido, 1, 1, float.Parse("5.50"));
                PedidoArticulos articulo2 = new PedidoArticulos(pedidoCreated.id_pedido, 2, 1, float.Parse("5.50"));
                PedidoArticulos articulo3 = new PedidoArticulos(pedidoCreated.id_pedido, 3, 1, float.Parse("5.50"));
                PedidoArticulos articulo4 = new PedidoArticulos(pedidoCreated.id_pedido, 4, 1, float.Parse("5.50"));
                List<PedidoArticulos> articulos = new List<PedidoArticulos> { articulo1, articulo2, articulo3, articulo4 }; //Para probar, luego lo cambiare por una funcion que añada a una lista los productos, que se puedan seleccionar desde un combobox
                pedidoCreated.cambiarLista(articulos);
                await pedidoApiClient.Crear(pedidoCreated);
                EmailSender emailSender = new EmailSender();
                emailSender.SendEmail("leandro.santilario@mthelmets.com", "Un nuevo pedido ha sido creado", $"Un nuevo pedido ha sido creado con el id: {pedidoCreated.id_pedido}");
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Info, new Exception("Se ha creado el pedido correctamente"));
                alerta.ShowDialog();
                this.Close();
                PedidoCreadoCorrectamente?.Invoke(pedidoCreated);
            }
            catch (Exception ex)
            {
                Log.Error($"Error al crear el pedido: {ex.Message}", ex);
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
        private bool validarCamposLlenos()
        {
            if (!string.IsNullOrEmpty(textBoxDniCliente.Text) && !string.IsNullOrEmpty(comboBoxImpuestos.Text) && !string.IsNullOrEmpty(comboBoxMetodoPago.Text))
            {
                return true;
            }
            Log.Warn("Intento de crear pedido con campos incompletos.");
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new MissingFieldException("Campos sin rellenar"));
            alerta.ShowDialog();
            if (alerta.resultado)
            {
                return false;
            }
            return false;
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
        public Pedido getPedido()
        {
            return this.pedidoCreated;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Log.Info("Rellenando campos de cliente con la opción debug.");
            this.comboBoxMetodoPago.Text = "PayPal";
            this.textBoxDniCliente.Text = "12345678Z";
            this.comboBoxImpuestos.Text = "21";
        }
        private void textBoxDniCliente_DoubleClick(object sender, EventArgs e)
        {
            using (var form = new ClienteForm())
            {
                form.ModoInvocacion = "CrearPedido";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(form.DniSeleccionado))
                    {
                        Log.Warn("No se ha seleccionado ningún cliente para el pedido.");
                        MessageBox.Show("No se ha seleccionado ningún cliente. Por favor, seleccione un cliente para continuar.", "Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Log.Info($"Cliente seleccionado para el pedido con Dni: {form.DniSeleccionado}");
                    textBoxDniCliente.Text = form.DniSeleccionado.ToString();
                    Log.Info($"Cliente seleccionado para pedido con Dni: {form.DniSeleccionado}");
                }
            }
        }
    }
}
