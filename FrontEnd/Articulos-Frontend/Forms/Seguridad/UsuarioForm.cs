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
using MTCore_AC.Entidades;

namespace Articulos_Frontend.Forms.Seguridad;

public partial class UsuarioForm : Form
{

    private UsuarioApiClient api;
    private Usuario user;
    private Usuario usuarioSeleccionado;
    public UsuarioForm(UsuarioApiClient apiUser, Usuario usuario)
    {
        InitializeComponent();
        StyleManager.StyleForm(this);
        Log.Info("Formulario de usuario iniciado.");
        api = apiUser;
        user = usuario;
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

    private void buttonAdd_Click(object sender, EventArgs e)
    {
        var usuarioActual = user;
        Log.Info("Abriendo formulario de detalle para nuevo usuario.");
        WindowManager.ShowForm(
        "Usuario_Nuevo",
        this,
        () =>
        {
            var form = new UsuarioDetailForm(api, new RolApiClient(), usuarioActual, null);
            form.FormClosed += (s, e) => cargarUsuarios();
            return form;
        }
    );
    }

    private void buttonDel_Click(object sender, EventArgs e)
    {
        if (usuarioSeleccionado != null)
        {
            Log.Info($"Eliminando usuario con correo {usuarioSeleccionado.CorreoElectronico}.");
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Warning, new Exception("¿Confirma que desea eliminar este usuario?"));
            alerta.ShowDialog();
            if (alerta.resultado)
            {
                api.EliminarUsuario(usuarioSeleccionado.CorreoElectronico);
                cargarUsuarios();
            }
        }
    }

    private void dataGridViewUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {

            usuarioSeleccionado = new Usuario
            {
                CorreoElectronico = dataGridViewUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString(),
                Nombre = dataGridViewUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString(),
                Contrasena = dataGridViewUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString()
            };
            var usuarioActual = user;
            Log.Info("Abriendo formulario de detalle para actualizar usuario.");
            WindowManager.ShowForm(
            $"Usuario_",
            this,
            () =>
            {
                var form = new UsuarioDetailForm(api, new RolApiClient(), usuarioActual, usuarioSeleccionado);
                form.FormClosed += (s, e) => cargarUsuarios();
                return form;
            }
        );
        }
    }

}