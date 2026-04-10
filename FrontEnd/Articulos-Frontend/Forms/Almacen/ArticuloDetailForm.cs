
using Articulos_Frontend.Client;
using Articulos_Frontend.LogConfig;
using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;
using System.Drawing.Text;

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
            var categorias = new[] { "Electrónica", "Perifericos", "Mobiliario" };
            comboBoxCategoria.DataSource = categorias.ToList();
            comboBoxCategoria.SelectedIndex = -1;
            if (articulo != null)
            {
                textBoxNombre.Text = articulo.nombre;
                textBoxPrecio.Text = articulo.precio.ToString();
                comboBoxCategoria.Text = articulo.categoria;
            }
            StyleManager.StyleForm(this);

        }

        private async void botonConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                Log.Warn("Intento de guardar artículo sin nombre.");
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new MissingFieldException("Nombre en blanco"));
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

            if (!decimal.TryParse(textBoxPrecio.Text, out var textPrecio) || textPrecio < 0)
            {
                Log.Warn("Intento de guardar artículo con precio inválido: " + textBoxPrecio.Text);
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new FormatException("Número decimal incorrecto o número negativo"));
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

            if (string.IsNullOrWhiteSpace(comboBoxCategoria.Text))
            {
                Log.Warn("Intento de guardar artículo sin categoría seleccionada.");
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new MissingFieldException("Categoria no seleccionada"));
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

            if (_articulo == null)
            {
                

                try
                {
                    EmailSender emailSender = new EmailSender();
                    var nombre = textBoxNombre.Text.Trim();
                    var precio = textPrecio;
                    var categoria = comboBoxCategoria.Text?.Trim();
                    var fechaCreacion = DateTime.Now;
                    var fechaActualizacion = (DateTime?)null;
                    var articulo = new Articulo(nombre, precio, categoria, fechaCreacion, fechaActualizacion);
                    var creado = await _client.Crear(articulo);
                    if(creado == null) throw new Exception("No se ha podido crear el artículo");
                    int articuloId = creado.id;
                    this.DialogResult = DialogResult.OK;
                    Log.Info($"Artículo creado: {articulo.nombre} (ID: {articulo.id})");
                    emailSender.SendEmail("emilio.martinez@mthelmets.com", "Nuevo artículo creado", $"Se ha creado el artículo '{articulo.nombre}' con ID {articulo.id}, con un costo de {articulo.precio} euros y de la categoria {articulo.categoria} en {articulo.FechaCreacion}.");
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
                    
                }
                catch (Exception ex)
                {
                    Log.Error("Error al guardar artículo: " + ex.Message, ex);
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
                return;
            }
            else
            {
                _articulo.nombre = textBoxNombre.Text.Trim();
                _articulo.precio = (decimal) textPrecio;
                _articulo.categoria = comboBoxCategoria.Text?.Trim();
                await _client.Actualizar(_articulo.id, _articulo);
                Log.Info($"Artículo actualizado: {_articulo.nombre} (ID: {_articulo.id})");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

    }
}
