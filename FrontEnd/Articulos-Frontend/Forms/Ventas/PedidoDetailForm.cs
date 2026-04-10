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
        private Pedido pedido;
        public event Action<Pedido> PedidoCreadoCorrectamente;
        private StringValuesSP stringValuesSP = new StringValuesSP();
        public PedidoDetailForm(Pedido pedido)
        {
            InitializeComponent();
            this.pedido = pedido;
            string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
            pedidoApiClient = new PedidoApiClient();
            StyleManager.StyleForm(this);
        }


        private void InitializeComponent()
        {
            textBoxDniCliente = new TextBox();
            textBoxMetodoPago = new TextBox();
            textBoxImpuestos = new TextBox();
            LabelIdPedido = new Label();
            LabelDniCliente = new Label();
            LabelMetodoPago = new Label();
            BotonCrearC = new Button();
            LabelTitulo = new Label();
            button1 = new Button();
            textBoxId = new TextBox();
            LabelImpuestos = new Label();
            SuspendLayout();
            // 
            // textBoxDniCliente
            // 
            textBoxDniCliente.Location = new Point(247, 137);
            textBoxDniCliente.Name = "textBoxDniCliente";
            textBoxDniCliente.PlaceholderText = "Introduzca el dni del cliente";
            textBoxDniCliente.Size = new Size(247, 23);
            textBoxDniCliente.TabIndex = 0;
            // 
            // textBoxMetodoPago
            // 
            textBoxMetodoPago.Location = new Point(247, 166);
            textBoxMetodoPago.Name = "textBoxMetodoPago";
            textBoxMetodoPago.PlaceholderText = "Introduzca el método de pago";
            textBoxMetodoPago.Size = new Size(247, 23);
            textBoxMetodoPago.TabIndex = 1;
            // 
            // textBoxImpuestos
            // 
            textBoxImpuestos.Location = new Point(247, 195);
            textBoxImpuestos.Name = "textBoxImpuestos";
            textBoxImpuestos.PlaceholderText = "Introduzca el porcentaje de impuestos";
            textBoxImpuestos.Size = new Size(247, 23);
            textBoxImpuestos.TabIndex = 3;
            // 
            // LabelIdPedido
            // 
            LabelIdPedido.BackColor = Color.Transparent;
            LabelIdPedido.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelIdPedido.Location = new Point(79, 110);
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
            LabelTitulo.Text = stringValuesSP.crearPedido;
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
            // textBoxId
            // 
            textBoxId.Location = new Point(247, 108);
            textBoxId.Name = "textBoxId";
            textBoxId.PlaceholderText = "Introduzca el id";
            textBoxId.Size = new Size(247, 23);
            textBoxId.TabIndex = 10;
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
            // PedidoDetailForm
            // 
            ClientSize = new Size(580, 363);
            Controls.Add(LabelImpuestos);
            Controls.Add(textBoxId);
            Controls.Add(button1);
            Controls.Add(LabelTitulo);
            Controls.Add(BotonCrearC);
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
            Name = "PedidoDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();

        }

        private async void BotonCrearC_Click(object sender, EventArgs e)
        {
            if (!validarCamposLlenos() || !ValidarDni(textBoxDniCliente.Text)) return;
            try
            {
                bool existePedido = false;
                int parsedId = 0;
                double parsedImpuestos = 0;
                try
                {
                    try
                    {
                        parsedId = int.Parse(textBoxId.Text);
                    } catch (FormatException)
                    {
                        Log.Warn($"Intento de crear pedido con Id no numérico: {textBoxId.Text.ToUpper()}.");
                        MessageBox.Show("El Id del pedido debe ser un número entero. Ejemplo: 123", "Id no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    try
                    {
                        parsedImpuestos = double.Parse(textBoxImpuestos.Text);
                        if (parsedImpuestos < 0 || parsedImpuestos > 100)
                        {
                            Log.Warn($"Intento de crear pedido con porcentaje de impuestos fuera de rango: {textBoxImpuestos.Text}.");
                            MessageBox.Show("El porcentaje de impuestos debe ser un número entre 0 y 100. Ejemplo: 21", "Porcentaje no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                    catch (FormatException)
                    {
                        Log.Warn($"Intento de crear pedido con porcentaje de impuestos no numérico: {textBoxImpuestos.Text}.");
                        MessageBox.Show("El porcentaje de impuestos debe ser un número entre 0 y 100. Ejemplo: 21", "Porcentaje no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Pedido comprobar = await pedidoApiClient.BuscarPorIdPedido(parsedId);
                    if (comprobar != null)
                    {
                        existePedido = true;
                        Log.Warn($"Intento de crear pedido con Id duplicado: {textBoxId.Text.ToUpper()}.");
                        Alerta alertaa = new Alerta(Alerta.AlertaTipo.Error, new DuplicateNameException("Pedido duplicado"));
                        alertaa.ShowDialog();
                        if (alertaa.resultado)
                        {
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    existePedido = false;
                }
                if (existePedido) return;

                PedidoArticulos articulo1 = new PedidoArticulos(parsedId, 1, 1);
                PedidoArticulos articulo2 = new PedidoArticulos(parsedId, 2, 1);
                PedidoArticulos articulo3 = new PedidoArticulos(parsedId, 3, 1);
                PedidoArticulos articulo4 = new PedidoArticulos(parsedId, 4, 1);
                List<PedidoArticulos> articulos = new List<PedidoArticulos> { articulo1, articulo2, articulo3, articulo4 }; //Para probar, luego lo cambiare por una funcion que añada a una lista los productos, que se puedan seleccionar desde un combobox
                Pedido pedido = new Pedido(parsedId, textBoxDniCliente.Text.ToUpper(), textBoxMetodoPago.Text, parsedImpuestos, articulos);
                pedidoApiClient.Crear(pedido);
                EmailSender emailSender = new EmailSender();
                emailSender.SendEmail("leandro.santilario@mthelmets.com", "Un nuevo producto ha sido creado", $"Un nuevo pedido ha sido creado con el id: {parsedId}");
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Info, new Exception("Se ha creado el articulo correctamente"));
                alerta.ShowDialog();
                if (alerta.resultado)
                {
                    this.Close();
                }
                else
                {
                    this.Close();
                }
                PedidoCreadoCorrectamente?.Invoke(pedido);
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
            if (!string.IsNullOrEmpty(textBoxDniCliente.Text) && !string.IsNullOrEmpty(textBoxImpuestos.Text) && !string.IsNullOrEmpty(textBoxId.Text) && !string.IsNullOrEmpty(textBoxMetodoPago.Text))
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
        public Pedido getPedido()
        {
            return this.pedido;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Log.Info("Rellenando campos de cliente con la opción debug.");
            this.textBoxId.Text = "11";
            this.textBoxMetodoPago.Text = "PayPal";
            this.textBoxDniCliente.Text = "12345678Z";
            this.textBoxImpuestos.Text = "21";
        }
    }
}
