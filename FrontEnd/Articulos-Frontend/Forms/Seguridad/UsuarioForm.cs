using Articulos_Frontend.Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Articulos_Frontend.LogConfig;
using Articulos_Frontend.Client;

namespace Articulos_Frontend.Forms.Seguridad;

public partial class UsuarioForm : Form
{

    UsuarioApiClient api;
    public UsuarioForm(UsuarioApiClient apiUser)
    {
        InitializeComponent();
        StyleManager.StyleForm(this);
        Log.Info("Formulario de usuario iniciado.");
        api = apiUser;
        MinimumSize = new Size(800, 600);
    }
    public void UsuarioForm_Load(object sender, EventArgs e)
    {
        cargarUsuarios();
    }

    public async void textBoxUsuario_TextChanged(object sender, EventArgs e)
    {
        cargarUsuarios();
    }

    public async void cargarUsuarios()
    {
        var usuarios = await api.ObtenerUsuarios();
        var search = textBoxUsuario.Text;
        if (!string.IsNullOrEmpty(search))
        {
           usuarios = usuarios.Where(u => u.Nombre.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        dataGridViewUsuarios.DataSource = usuarios;
    }

    public void dataGridViewUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        if (dataGridViewUsuarios.Columns.Contains("colVacia"))
        {
            dataGridViewUsuarios.Columns.Remove("colVacia");
        }
        if (dataGridViewUsuarios.Columns.Count == 0) return;

        dataGridViewUsuarios.Columns[0].Width = 140;
        dataGridViewUsuarios.Columns[1].Width = 140;
        dataGridViewUsuarios.Columns[2].Width = 300;
        DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
        col.Name = "colVacia";
        col.HeaderText = "";
        dataGridViewUsuarios.Columns.Add(col);
        dataGridViewUsuarios.Columns["colVacia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    }

}