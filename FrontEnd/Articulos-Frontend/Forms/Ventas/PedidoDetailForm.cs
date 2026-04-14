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
        BindingList<LineaPedido> articulos = new BindingList<LineaPedido> { };
        private StringValuesSP stringValuesSP = new StringValuesSP();
        public PedidoDetailForm()
        {
            InitializeComponent();
            LabelTitulo.Text = stringValuesSP.crearPedido;
            this.Text = stringValuesSP.crearPedido;
            var impuestos = new List<string> { "21", "10", "4", "0" };
            var metodosPago = new List<string> { "Tarjeta de Crédito", "PayPal", "Transferencia Bancaria", "Contra Reembolso" };
            comboBoxImpuestos.DataSource = impuestos;
            comboBoxImpuestos.SelectedIndex = -1;
            comboBoxMetodoPago.DataSource = metodosPago;
            comboBoxMetodoPago.SelectedIndex = -1;
            dataGridViewArticulos.DataSource = articulos;
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
            comboBoxMetodoPago = new ComboBox();
            dataGridViewArticulos = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            ((ISupportInitialize)dataGridViewArticulos).BeginInit();
            SuspendLayout();
            // 
            // textBoxDniCliente
            // 
            textBoxDniCliente.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            BotonCrearC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BotonCrearC.AutoSize = true;
            BotonCrearC.BackColor = SystemColors.MenuHighlight;
            BotonCrearC.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BotonCrearC.ForeColor = SystemColors.ControlLightLight;
            BotonCrearC.Location = new Point(344, 101);
            BotonCrearC.MaximumSize = new Size(150, 30);
            BotonCrearC.Name = "BotonCrearC";
            BotonCrearC.Size = new Size(150, 30);
            BotonCrearC.TabIndex = 5;
            BotonCrearC.Text = "Crear";
            BotonCrearC.UseVisualStyleBackColor = false;
            BotonCrearC.Click += BotonCrearC_Click;
            // 
            // LabelTitulo
            // 
            LabelTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            button1.Location = new Point(79, 105);
            button1.MaximumSize = new Size(90, 23);
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
            comboBoxImpuestos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxImpuestos.FormattingEnabled = true;
            comboBoxImpuestos.Location = new Point(247, 199);
            comboBoxImpuestos.Name = "comboBoxImpuestos";
            comboBoxImpuestos.Size = new Size(247, 23);
            comboBoxImpuestos.TabIndex = 12;
            comboBoxImpuestos.Tag = "comboBox";
            // 
            // comboBoxMetodoPago
            // 
            comboBoxMetodoPago.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxMetodoPago.FormattingEnabled = true;
            comboBoxMetodoPago.Location = new Point(247, 168);
            comboBoxMetodoPago.Name = "comboBoxMetodoPago";
            comboBoxMetodoPago.Size = new Size(247, 23);
            comboBoxMetodoPago.TabIndex = 13;
            comboBoxMetodoPago.Tag = "comboBox";
            // 
            // dataGridViewArticulos
            // 
            dataGridViewArticulos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewArticulos.Location = new Point(79, 243);
            dataGridViewArticulos.Name = "dataGridViewArticulos";
            dataGridViewArticulos.Size = new Size(415, 108);
            dataGridViewArticulos.TabIndex = 14;
            dataGridViewArticulos.CellEndEdit += dgvArticulos_CellEndEdit;
            dataGridViewArticulos.Validating += dgvArticulos_Validating;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(500, 243);
            button2.MaximumSize = new Size(68, 51);
            button2.Name = "button2";
            button2.Size = new Size(68, 51);
            button2.TabIndex = 15;
            button2.Text = "+";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BotonAgregarP_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(500, 300);
            button3.Name = "button3";
            button3.Size = new Size(68, 51);
            button3.TabIndex = 16;
            button3.Text = "-";
            button3.UseVisualStyleBackColor = true;
            // 
            // PedidoDetailForm
            // 
            ClientSize = new Size(580, 363);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridViewArticulos);
            Controls.Add(comboBoxMetodoPago);
            Controls.Add(comboBoxImpuestos);
            Controls.Add(LabelImpuestos);
            Controls.Add(button1);
            Controls.Add(LabelTitulo);
            Controls.Add(BotonCrearC);
            Controls.Add(LabelMetodoPago);
            Controls.Add(LabelDniCliente);
            Controls.Add(textBoxDniCliente);
            MaximizeBox = false;
            MinimumSize = new Size(596, 402);
            Name = "PedidoDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            ((ISupportInitialize)dataGridViewArticulos).EndInit();
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
                List<PedidoArticulos> articulosPedido = new List<PedidoArticulos>();
                foreach (LineaPedido lin in articulos)
                {
                    PedidoArticulos pa = new PedidoArticulos
                    {
                        id_pedido = pedidoCreated.id_pedido,
                        id_articulo = lin.id_articulo,
                        cantidad = lin.cantidad,
                        precio_unidad = lin.precioUnidad
                    };
                    articulosPedido.Add(pa);
                }
                pedidoCreated.cambiarLista(articulosPedido);
                await pedidoApiClient.Crear(pedidoCreated);
                await pedidoApiClient.AgregarArticulos(articulosPedido);
                EmailSender emailSender = new EmailSender();
                emailSender.SendEmail("leandro.santilario@mthelmets.com", "Un nuevo pedido ha sido creado", $"Un nuevo pedido ha sido creado con el id: {pedidoCreated.id_pedido}");
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Info, new Exception("Se ha creado el pedido correctamente"));
                alerta.ShowDialog();
                PedidoCreadoCorrectamente?.Invoke(pedidoCreated);
                this.Close();
            }
            catch (Exception ex)
            {
                Log.Error($"Error al crear el pedido: {ex.Message}", ex);
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                alerta.ShowDialog();
                return;
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
        private void BotonAgregarP_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new ArticuloForm())
                {
                    form.ModoInvocacion = "CrearPedido";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.articuloSeleccionado == null)
                        {
                            Log.Warn("No se ha seleccionado ningún articulo para el pedido.");
                            MessageBox.Show("No se ha seleccionado ningún artículo. Por favor, seleccione un artículo para agregarlo al pedido.", "Artículo no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        Articulo artSel = form.articuloSeleccionado;
                        Log.Info($"Artículo seleccionado para el pedido con nombre: {artSel.nombre}");
                        articulos.Add(new LineaPedido(artSel.id, artSel.nombre, artSel.categoria, 1, artSel.precio));
                        dataGridViewArticulos.DataSource = null;
                        dataGridViewArticulos.DataSource = articulos;
                        dataGridViewArticulos.ReadOnly = false;
                    }
                }
                if (dataGridViewArticulos.Columns["cantidad"] != null)
                {
                    dataGridViewArticulos.Columns["cantidad"].Width = 80;
                    dataGridViewArticulos.Columns["cantidad"].Resizable = DataGridViewTriState.False;
                    dataGridViewArticulos.Columns["cantidad"].ReadOnly = false;
                    dataGridViewArticulos.Columns["cantidad"].HeaderText = "Cantidad";
                }
                if (dataGridViewArticulos.Columns["id_articulo"] != null)
                {
                    dataGridViewArticulos.Columns["id_articulo"].Width = 80;
                    dataGridViewArticulos.Columns["id_articulo"].Resizable = DataGridViewTriState.False;
                    dataGridViewArticulos.Columns["id_articulo"].ReadOnly = true;
                    dataGridViewArticulos.Columns["id_articulo"].HeaderText = "Id del Articulo";
                }
                if (dataGridViewArticulos.Columns["Nombre"] != null)
                {
                    dataGridViewArticulos.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dataGridViewArticulos.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dataGridViewArticulos.Columns["Nombre"].FillWeight = 30;
                    dataGridViewArticulos.Columns["Nombre"].MinimumWidth = 100;
                    dataGridViewArticulos.Columns["Nombre"].ReadOnly = true;
                }
                if (dataGridViewArticulos.Columns["Categoria"] != null)
                {
                    dataGridViewArticulos.Columns["Categoria"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dataGridViewArticulos.Columns["Categoria"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dataGridViewArticulos.Columns["Categoria"].FillWeight = 30;
                    dataGridViewArticulos.Columns["Categoria"].MinimumWidth = 120;
                    dataGridViewArticulos.Columns["Categoria"].ReadOnly = true;
                    dataGridViewArticulos.Columns["Categoria"].HeaderText = "Categoría";
                }
                if (dataGridViewArticulos.Columns["PrecioUnidad"] != null)
                {
                    dataGridViewArticulos.Columns["PrecioUnidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dataGridViewArticulos.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dataGridViewArticulos.Columns["Email"].FillWeight = 40;
                    dataGridViewArticulos.Columns["PrecioUnidad"].MinimumWidth = 150;
                    dataGridViewArticulos.Columns["PrecioUnidad"].HeaderText = "Precio de Unidad";
                    dataGridViewArticulos.Columns["PrecioUnidad"].ReadOnly = false;
                }
                if (dataGridViewArticulos.Columns["TotalLinea"] != null)
                {
                    dataGridViewArticulos.Columns["TotalLinea"].Width = 80;
                    dataGridViewArticulos.Columns["TotalLinea"].Resizable = DataGridViewTriState.False;
                    dataGridViewArticulos.Columns["TotalLinea"].HeaderText = "Total de la Linea";
                    dataGridViewArticulos.Columns["TotalLinea"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error al crear el pedido: {ex.Message}", ex);
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                alerta.ShowDialog();
                return;
            }
        }
        public void dgvArticulos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridViewArticulos.Rows[e.RowIndex];
                string nomcol = dataGridViewArticulos.Columns[e.ColumnIndex].Name;

                LineaPedido linea = articulos[e.RowIndex];
                if (nomcol == "cantidad" && row.Cells["cantidad"].Value != null)
                {
                    int cantidad;
                    if (int.TryParse(row.Cells["cantidad"].Value.ToString(), out cantidad))
                    {
                        linea.cantidad = cantidad;
                    }
                    else
                    {
                        Log.Warn($"Valor no numérico ingresado en la cantidad del artículo: {row.Cells["cantidad"].Value}");
                        MessageBox.Show("Por favor, ingrese un número válido para la cantidad.", "Cantidad no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row.Cells["cantidad"].Value = articulos[e.RowIndex].cantidad; //Revertir al valor anterior
                    }
                } else if (nomcol == "PrecioUnidad")
                {
                    if (decimal.TryParse(row.Cells["precioUnidad"].Value.ToString(), out decimal precio))
                    {
                        linea.precioUnidad = precio;
                    }
                    else
                    {
                        MessageBox.Show("Precio no válido");
                        row.Cells["precioUnidad"].Value = linea.precioUnidad;
                    }
                }
                linea.calcularTotalLinea();
                dataGridViewArticulos.Refresh();
            }
        }
        private void dgvArticulos_Validating(object sender, CancelEventArgs e)
        {
            if (dataGridViewArticulos.CurrentCell == null)
                return;

            int rowIndex = dataGridViewArticulos.CurrentCell.RowIndex;
            int colIndex = dataGridViewArticulos.CurrentCell.ColumnIndex;
            if (rowIndex < 0 || colIndex < 0) return;
            var colName = dataGridViewArticulos.Columns[colIndex].Name;
            dgvArticulos_CellEndEdit(sender, new DataGridViewCellEventArgs(colIndex, rowIndex));
        }
    }
    public class LineaPedido
    {
        public int id_articulo { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }

        public decimal precioUnidad { get; set; }
        public int cantidad { get; set; }
        public decimal totalLinea { get; set; }
        public LineaPedido(int id_articulo, string nombre, string categoria, int cantidad, decimal precioUnidad)
        {
            this.id_articulo = id_articulo;
            this.nombre = nombre;
            this.categoria = categoria;
            this.cantidad = cantidad;
            this.precioUnidad = precioUnidad;
            calcularTotalLinea();
        }
        public void calcularTotalLinea()
        {
            totalLinea = precioUnidad * cantidad;
        }
    }
}
