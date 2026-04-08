using Articulos_Frontend.Client;
using Articulos_Frontend.LogConfig;
using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Articulos_Frontend
{
    public partial class LoginForm : Form
    {
        private UsuarioApiClient api;
        public LoginForm()
        {
            InitializeComponent();
            string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
            api = new UsuarioApiClient();
            StyleManager.StyleForm(this);
            Log.Info("Formulario de login iniciado.");

        }
        public async void loginButton_Click(object sender, EventArgs e)
        {
            string email = emailText.Text;
            string contrasena = contrasenaText.Text;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contrasena))
            {
                Log.Warn("Intento de login con campos vacíos.");
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new Exception("Por favor, complete ambos campos."));
                alerta.ShowDialog();
                return;
            }
            try
            {
                var usuario = new Usuario(email, contrasena);
                var usuarios = await api.ObtenerUsuarios();
                if (usuario != null)
                {
                    foreach (Usuario u in usuarios)
                    {
                        if (u.Correo == email && u.Contrasena == contrasena)
                        {
                            usuario = u;
                            break;
                        }
                    }
                    Log.Info($"Usuario {email} ha iniciado sesión exitosamente.");
                    WindowManager.ShowForm(
                        "MainForm",
                        this,
                        () =>
                        {
                            var form = new Menu(api, usuario);
                            form.FormClosed += (s, args) => this.Show();
                            return form;
                        }
                    );
                    this.Hide();
                }
                else
                {
                    Log.Warn($"Intento de login fallido para el usuario {email}.");
                    Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new Exception("Credenciales incorrectas."));
                    alerta.ShowDialog();
                }
                emailText.Text = "";
                contrasenaText.Text = "";
            }
            catch (Exception ex)
            {
                Log.Error("Error durante el proceso de login: " + ex.Message);
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                alerta.ShowDialog();
            }

        }
    }
    }
