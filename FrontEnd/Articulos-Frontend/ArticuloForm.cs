using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Articulos_Backend.Articulos;
using Articulos_Backend.Repositorios;

namespace Articulos_Frontend
{
    public partial class ArticuloForm : Form
    {
        private ArticuloRepository repo;

        public ArticuloForm()
        {
            InitializeComponent();
            string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
            repo = new ArticuloRepository(connStr);
        }

        private void ArticuloForm_Load(object sender, EventArgs e)
        {
            cargarArticulos(null);
        }

        private void botonAdd_Click(object sender, EventArgs e)
        {
            using (var f = new ArticuloDetailForm(repo, null))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    cargarArticulos(TextoNombre.Text);
                }
            }
        }

        private void botonDel_Click(object sender, EventArgs e)
        {
            repo.Eliminar(dataGridView1.CurrentRow?.Cells["Id"].Value as int? ?? 0);
            cargarArticulos(null);
        }

        private void cargarArticulos(string nombre)
        {
            IEnumerable<Articulo> articulos;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                articulos = repo.ObtenerArticulos();

            }
            else
            {
                articulos = repo.ObtenerPorNombre(nombre);
            }
            dataGridView1.DataSource = articulos.ToList();
        }

        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            cargarArticulos(TextoNombre.Text);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var articulo = dataGridView1.Rows[e.RowIndex].DataBoundItem as Articulo;
                if (articulo != null)
                {
                    using (var f = new ArticuloDetailForm(repo, articulo))
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            cargarArticulos(TextoNombre.Text);
                        }
                    }
                }
            }
        }

    }
}
