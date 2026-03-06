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
            string connStr = "Server=localhost;Database=articulos_db;User Id=sa;Password=your_password;";
            repo = new ArticuloRepository(connStr);
        }

        private void ArticuloForm_Load(object sender, EventArgs e)
        {

        }

        private void botonAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void botonDel_Click(object sender, EventArgs e)
        {

        }

        private void cargarArticulos(string nombre)
        {
            IEnumerable<Articulo> articulos;
            if (string.IsNullOrEmpty(nombre))
            {
                articulos = repo.ObtenerArticulos();

            }
            else
            {
                articulos = repo.ObtenerPorNombre(nombre);
            }
        }

        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            string nombre = TextoNombre.Text;
            cargarArticulos(nombre);
        }


    }
}
