
using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;
using System.Drawing.Text;

namespace Articulos_Frontend
{
    public partial class ArticuloDetailForm : Form
    {
        private ArticuloApiClient _client;
        private Articulo _articulo;
        public ArticuloDetailForm(ArticuloApiClient client, Articulo articulo)
        {
            InitializeComponent();
            _client = client;
            _articulo = articulo;
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
                    var id = 0;
                    var nombre = textBoxNombre.Text.Trim();
                    var precio = textPrecio;
                    var categoria = comboBoxCategoria.Text?.Trim();
                    var fechaCreacion = DateTime.Now;
                    var fechaActualizacion = (DateTime?)null;
                    var articulo = new Articulo(id, nombre, precio, categoria, fechaCreacion, fechaActualizacion);
                    await _client.Crear(articulo);
                    this.DialogResult = DialogResult.OK;
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
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

    }
}
