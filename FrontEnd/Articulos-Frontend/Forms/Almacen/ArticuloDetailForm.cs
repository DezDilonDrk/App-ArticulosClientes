using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;
using SesionMT.LogConfig;

namespace Articulos_Frontend
{
    public partial class ArticuloDetailForm : Form
    {
        private ArticuloApiClient _client;
        private Articulo _articulo;
        private StringValuesSP stringValuesSP = new StringValuesSP();
        private Usuario user;
        public ArticuloDetailForm(ArticuloApiClient client, Articulo articulo, Usuario usuario)
        {
            InitializeComponent();
            _client = client;
            _articulo = articulo;
            user = usuario;
            var categorias = new[] { "Cascos", "Ropa", "Accesorios", "Otros" };
            comboBoxCategoria.DataSource = categorias.ToList();
            comboBoxCategoria.SelectedIndex = -1;
            
            if (articulo != null)
            {
                textBoxNombre.Text = articulo.Nombre;
                textBoxPrecio.Text = articulo.Precio.ToString();
                comboBoxCategoria.Text = articulo.Categoria;
                
            }
            StyleManager.StyleForm(this);
            if(AppState.getUserSession().getRoles().Contains(Roles.UserAlmacen))
            {
                textBoxNombre.ReadOnly = true;
                textBoxPrecio.ReadOnly = true;
                comboBoxCategoria.Enabled = false;
                botonConfirm.Visible = false;
            }

        }

        private async void ArticuloDetailForm_Load(object sender, EventArgs e)
        {

            if (_articulo != null)
            {
                if (_articulo.Categoria == "Cascos" && !string.IsNullOrWhiteSpace(_articulo.IdDisenoCasco))
                {
                    labelDiseno.Visible = true;
                    comboBoxDiseno.Visible = true;
                    comboBoxDiseno.Enabled = true;
                    

                    var disenos = await _client.ObtenerDisenosCascos();

                    comboBoxDiseno.DataSource = disenos;
                    comboBoxDiseno.Text = disenos.FirstOrDefault(d => d.id == _articulo.IdDisenoCasco)?.nombre;
                }
            }
            if (comboBoxCategoria.Text != "Cascos")
            {
                labelDiseno.Visible = false;
                comboBoxDiseno.Visible = false;
                comboBoxDiseno.Enabled = false;
            }
        }

        private async void comboBoxCategoria_OnChange(object sender, EventArgs e)
        {
            if (comboBoxCategoria.Text == "Cascos")
            {
                labelDiseno.Visible = true;
                comboBoxDiseno.Visible = true;
                comboBoxDiseno.Enabled = true;
                var disenos = await _client.ObtenerDisenosCascos();
                comboBoxDiseno.DataSource = disenos;
                comboBoxDiseno.DisplayMember = "nombre";
                comboBoxDiseno.ValueMember = "id";
                comboBoxDiseno.SelectedIndex = -1;
            }
            else
            {
                labelDiseno.Visible = false;
                comboBoxDiseno.Visible = false;
                comboBoxDiseno.DataSource = null;
            }
        }

        private async void botonConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                Log.Warn("Intento de guardar artículo sin nombre.");
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new MissingFieldException("Nombre en blanco"));
                alerta.ShowDialog();
                return;
            }

            if (!decimal.TryParse(textBoxPrecio.Text, out var textPrecio) || textPrecio < 0)
            {
                Log.Warn("Intento de guardar artículo con precio inválido: " + textBoxPrecio.Text);
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new FormatException("Número decimal incorrecto o número negativo"));
                alerta.ShowDialog();
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxCategoria.Text))
            {
                Log.Warn("Intento de guardar artículo sin categoría seleccionada.");
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new MissingFieldException("Categoria no seleccionada"));
                alerta.ShowDialog();
                return;
            }
            if (comboBoxDiseno.Visible && string.IsNullOrWhiteSpace(comboBoxDiseno.Text))
            {
                Log.Warn("Intento de guardar artículo sin diseño de casco seleccionado.");
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new MissingFieldException("Diseño de casco no seleccionado"));
                alerta.ShowDialog();
                return;
            }

            if (_articulo == null)
            {


                try
                {
                    string idDisenoCasco = null;
                    var nombre = textBoxNombre.Text.Trim();
                    var precio = textPrecio;
                    var categoria = comboBoxCategoria.Text?.Trim();
                    if(categoria == "Cascos")
                    {
                        idDisenoCasco = await _client.ObtenerIdDiseno(comboBoxDiseno.Text.Trim());
                    }
                    var fechaCreacion = DateTime.Now;
                    var fechaActualizacion = (DateTime?)null;
                    var articulo = new Articulo(nombre, precio, categoria, idDisenoCasco, fechaCreacion, fechaActualizacion);
                    var creado = await _client.Crear(articulo);
                    if (creado == null) throw new Exception("No se ha podido crear el artículo");
                    string articuloId = creado.id;
                    this.DialogResult = DialogResult.OK;
                    Log.Info($"Artículo creado: {articulo.Nombre} (ID: {articulo.id})");
                    var menu = this.Owner as Menu;
                    if (AppState.getConfiguracion().SendNotifications == true)
                    {
                        EmailSender emailSender = new EmailSender();
                        emailSender.SendEmail("emilio.martinez@mthelmets.com", "Nuevo artículo creado", $"Se ha creado el artículo '{articulo.Nombre}' con ID {articulo.id}, con un costo de {articulo.Precio} euros y de la categoria {articulo.Categoria} en {articulo.FechaCreacion}.");
                    }
                    Alerta alerta = new Alerta(Alerta.AlertaTipo.Info, new Exception("Se ha creado el articulo correctamente"));
                    alerta.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Log.Error("Error al guardar artículo: " + ex.Message, ex);
                    Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                    alerta.ShowDialog();
                    return;
                }
                return;
            }
            else
            {
                string idDisenoCasco = null;
                _articulo.Nombre = textBoxNombre.Text.Trim();
                _articulo.Precio = (decimal)textPrecio;
                _articulo.Categoria = comboBoxCategoria.Text?.Trim();
                if (comboBoxCategoria.Text == "Cascos")
                {
                    idDisenoCasco = await _client.ObtenerIdDiseno(comboBoxDiseno.Text?.Trim());
                }
                _articulo.IdDisenoCasco = idDisenoCasco?.ToString();
                await _client.Actualizar(_articulo.id, _articulo);
                Log.Info($"Artículo actualizado: {_articulo.Nombre} (ID: {_articulo.id})");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
