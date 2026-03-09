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
        private ArticuloRepository _repo;
        private Articulo _articulo;
        public ArticuloDetailForm(ArticuloRepository repo, Articulo articulo)
        {
            InitializeComponent();
            _repo = repo;
            _articulo = articulo;
            if (articulo != null)
            {
                textBoxNombre.Text = articulo.nombre;
                textBoxPrecio.Text = articulo.precio.ToString();
                textBoxCategoria.Text = articulo.categoria;
            }
        }

        public void botonConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                MessageBox.Show("Nombre obligatorio");
                return;
            }

            if (!double.TryParse(textBoxPrecio.Text, out var textPrecio) || textPrecio < 0)
            {
                MessageBox.Show("Precio inválido (no negativo)");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxCategoria.Text))
            {
                MessageBox.Show("Categoria obligatoria");
                return;
            }

            if (_articulo == null)
            {
                var id = 0;
                var nombre = textBoxNombre.Text.Trim();
                var precio = textPrecio;
                var categoria = textBoxCategoria.Text?.Trim();
                var articulo = new Articulo(id, nombre, precio, categoria);

                try
                {
                    _repo.Insertar(articulo);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _articulo.nombre = textBoxNombre.Text.Trim();
                _articulo.precio = textPrecio;
                _articulo.categoria = textBoxCategoria.Text?.Trim();
                var ok = _repo.Actualizar(_articulo);
                if (!ok)
                {
                    MessageBox.Show("No se pudo actualizar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }
        
    }
}
