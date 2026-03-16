using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Articulos_Backend.Articulos;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
//using Articulos_Backend.Repositorios;

namespace Articulos_Frontend;

public partial class ArticuloForm : Form
{
    //private ArticuloRepository repo;
    private ArticuloApiClient api;

    public ArticuloForm()
    {
        InitializeComponent();
        string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
        //repo = new ArticuloRepository(connStr);
        api = new ArticuloApiClient();
    }

    private void ArticuloForm_Load(object sender, EventArgs e)
    {
        cargarArticulos(null);
    }

    private void botonAdd_Click(object sender, EventArgs e)
    {
        WindowManager.ShowForm(
        "Articulo_Nuevo",
        this,
        () => new ArticuloDetailForm(api, null)
    );
    }

    private async void botonDel_Click(object sender, EventArgs e)
    {
        await api.Eliminar(dataGridView1.CurrentRow?.Cells["Id"].Value as int? ?? 0);
        cargarArticulos(null);
    }

    private async void cargarArticulos(string nombre)
    {
        var articulos = await api.ObtenerArticulos();
        var dateDesde = fechaDesde.Value.Date;
        var dateHasta = fechaHasta.Value.Date.AddDays(1);

        if (!string.IsNullOrWhiteSpace(nombre))
        {
            articulos = articulos
                .Where(a => a.nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        if (checkBoxDesde.Checked)
        {
            articulos = articulos
            .Where(a => a.FechaCreacion >= dateDesde)
            .ToList();
        }
        if (checkBoxHasta.Checked)
        {
            articulos = articulos
            .Where(a => a.FechaCreacion < dateHasta)
            .ToList();
        }

        dataGridView1.DataSource = articulos;

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
                WindowManager.ShowForm(
                    $"{nameof(ArticuloForm)}_{articulo.id}",
                    this,
                    () => new ArticuloDetailForm(api, articulo)
                );
            }
        }
    }

    

    private void EtiquetaNombre_Click(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {

    }

    private void checkBoxDesde_CheckedChanged(object sender, EventArgs e)
    {

    }
    private void checkBoxHasta_CheckedChanged(object sender, EventArgs e)
    {

    }

}
