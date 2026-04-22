using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Articulos_Frontend.Client;
using MTCore_AC.Entidades;
using Articulos_Frontend.LogConfig;
using Articulos_Frontend.Theme;

namespace Articulos_Frontend.Forms.Seguridad
{
    public partial class UsuarioDetailForm : Form
    {
        private UsuarioApiClient userapi;
        private RolApiClient rolapi;
        private Usuario usuarioActual;
        private Usuario usuarioSeleccionado;
        public UsuarioDetailForm(UsuarioApiClient api, RolApiClient api2, Usuario usuario1, Usuario? usuario2)
        {
            InitializeComponent();
            StyleManager.StyleForm(this);
            userapi = api;
            rolapi = api2;
            usuarioActual = usuario1;
            usuarioSeleccionado = usuario2;

        }

        public void UsuarioDetailForm_Load(object sender, EventArgs e)
        {
            Size = new Size(816, 421);
            cargarRoles();
            if (usuarioSeleccionado != null)
            {
                textBoxNombre.Text = usuarioSeleccionado.Nombre;
                textBoxCorreo.Text = usuarioSeleccionado.CorreoElectronico;
                textBoxContrasena.Text = usuarioSeleccionado.Contrasena;
            }
            dataGridViewRoles.AutoGenerateColumns = false;
            dataGridViewRoles.ReadOnly = false;
            dataGridViewRoles.Columns.Clear();
            dataGridViewRoles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "nombre",
                HeaderText = "Rol",
                ReadOnly = true,
            });
            dataGridViewRoles.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "seleccionado",
                HeaderText = "Asignado",
            });

        }

        private void dataGridViewRoles_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var rol = (RolItem)dataGridViewRoles.Rows[e.RowIndex].DataBoundItem;

                if (rol.nombre == Roles.AdminSeguridad && usuarioActual.CorreoElectronico == usuarioSeleccionado?.CorreoElectronico)
                {
                    e.Cancel = true;
                }
            }
        }


        public class RolItem
        {
            public string nombre { get; set; }
            public bool seleccionado { get; set; }
        }

        private async void cargarRoles()
        {
            var roles = await rolapi.ObtenerRoles();
            var usuarioRoles = new List<string>();
            if (usuarioSeleccionado != null)
            {
                textBoxContrasena.Enabled = false;
                textBoxCorreo.Enabled = false;
                textBoxNombre.Text = usuarioSeleccionado.Nombre;
                textBoxCorreo.Text = usuarioSeleccionado.CorreoElectronico;
                textBoxContrasena.Text = usuarioSeleccionado.Contrasena;
                usuarioRoles = await userapi.ObtenerRolesUsuario(usuarioSeleccionado.CorreoElectronico);
            }
            var listaRoles = roles.Select(r => new RolItem
            {
                nombre = r.Nombre,
                seleccionado = usuarioRoles.Contains(r.Nombre)
            }).ToList();
            dataGridViewRoles.DataSource = listaRoles;
        }

        private async void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado != null)
            {
                var lista = (List<RolItem>)dataGridViewRoles.DataSource;
                var rolesSeleccionados = lista.Where(r => r.seleccionado).Select(r => r.nombre).ToList();
                await userapi.ActualizarRolesUsuario(usuarioSeleccionado.CorreoElectronico, rolesSeleccionados);
                await userapi.ActualizarUsuario(new Usuario
                {
                    Nombre = textBoxNombre.Text,
                    CorreoElectronico = textBoxCorreo.Text,
                    Contrasena = textBoxContrasena.Text,
                });
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Info, new Exception("Se ha actualizado el usuarios correctamente"));
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
            else
            {
                Alerta alerta;
                if (string.IsNullOrEmpty(textBoxNombre.Text) || string.IsNullOrEmpty(textBoxCorreo.Text) || string.IsNullOrEmpty(textBoxContrasena.Text))
                {
                    alerta = new Alerta(Alerta.AlertaTipo.Warning, new Exception("Por favor complete todos los campos"));
                    alerta.ShowDialog();
                    return;
                }
                if (!ValidarEmail(textBoxCorreo.Text))
                {
                    return;
                }
                var lista = (List<RolItem>)dataGridViewRoles.DataSource;
                var rolesSeleccionados = lista.Where(r => r.seleccionado).Select(r => r.nombre).ToList();
                var usuarioNuevo = new Usuario
                {
                    Nombre = textBoxNombre.Text,
                    CorreoElectronico = textBoxCorreo.Text,
                    Contrasena = textBoxContrasena.Text,
                };
                await userapi.CrearUsuario(usuarioNuevo);
                await userapi.ActualizarRolesUsuario(usuarioNuevo.CorreoElectronico, rolesSeleccionados);
                alerta = new Alerta(Alerta.AlertaTipo.Info, new Exception("Se ha creado el usuario correctamente"));
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
            return;
        }

        private bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                Log.Warn($"Intento de crear usuario con email no válido: {email}.");
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new DuplicateNameException("Formato {usuario}@{proveedor}.{dominio} erroneo\", \"Email no válido"));
                alerta.ShowDialog();
                if (alerta.resultado)
                {
                    return false;
                }
                return false;
            }
        }

        private void buttonCC_Click(object sender, EventArgs e)
        {
            WindowManager.ShowForm(
            $"CC_{usuarioSeleccionado.CorreoElectronico}",
            this,
            () =>
            {
                var form = new CambiarContrasenaForm(usuarioSeleccionado.CorreoElectronico);
                return form;
            }
        );
        }
    }
}
