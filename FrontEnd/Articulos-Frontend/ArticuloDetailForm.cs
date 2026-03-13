using Articulos_Backend.Articulos;
using Articulos_Backend.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            
        }

        private async void botonConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                MessageBox.Show("Nombre obligatorio");
                return;
            }

            if (!decimal.TryParse(textBoxPrecio.Text, out var textPrecio) || textPrecio < 0)
            {
                MessageBox.Show("Precio inválido (no negativo)");
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxCategoria.Text))
            {
                MessageBox.Show("Categoria obligatoria");
                return;
            }

            if (_articulo == null)
            {
                var id = 0;
                var nombre = textBoxNombre.Text.Trim();
                var precio = textPrecio;
                var categoria = comboBoxCategoria.Text?.Trim();
                var fechaCreacion = DateTime.Now;
                var fechaActualizacion = (DateTime?)null;
                var articulo = new Articulo(id, nombre, precio, categoria, fechaCreacion, fechaActualizacion);

                try
                {
                    await _client.Crear(articulo);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
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
