using Articulos_Frontend.Client;
using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Articulos_Frontend.Forms.Seguridad
{
    public partial class CambiarContrasenaForm : Form
    {
        private string correo;
        private UsuarioApiClient api;
        public CambiarContrasenaForm(string correo)
        {
            InitializeComponent();
            StyleManager.StyleForm(this);
            this.correo = correo;
            api = new UsuarioApiClient();
        }

        public CambiarContrasenaForm()
        {
            InitializeComponent();
            StyleManager.StyleForm(this);
            api = new UsuarioApiClient();
        }

        public void CambiarContrasenaForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(correo))
            {
                textBoxCorreo.Text = correo;
                textBoxCorreo.Enabled = false;
            }
        }

        private async void buttonConfirm_Click(object sender, EventArgs e)
        {
            if(textBoxContrasena.Text != textBoxConfirmarContrasena.Text)
            {
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Warning, new Exception("Las contraseñas no coinciden. Por favor, inténtelo de nuevo."));
                alerta.ShowDialog();
                return;
            }
            if(textBoxContrasena.Text.Length < 6)
            {
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Warning, new Exception("La contraseña debe tener al menos 6 caracteres. Por favor, inténtelo de nuevo."));
                alerta.ShowDialog();
                return;
            }
            if(textBoxContrasena.Text.Length > 20)
            {
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Warning, new Exception("La contraseña no puede tener más de 20 caracteres. Por favor, inténtelo de nuevo."));
                alerta.ShowDialog();
                return;
            }
            if(string.IsNullOrEmpty(textBoxContrasena.Text) || string.IsNullOrEmpty(textBoxConfirmarContrasena.Text))
            {
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Warning, new Exception("La contraseña no puede estar vacía. Por favor, inténtelo de nuevo."));
                alerta.ShowDialog();
                return;
            }
            if(string.IsNullOrEmpty(textBoxCorreo.Text))
            {
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Warning, new Exception("El correo no puede estar vacío. Por favor, inténtelo de nuevo."));
                alerta.ShowDialog();
                return;
            }
            try
            {
                await api.ActualizarContrasena(textBoxCorreo.Text, textBoxContrasena.Text);
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Info, new Exception("Contraseña actualizada correctamente.")); alerta.ShowDialog();
                EmailSender emailSender = new EmailSender();
                emailSender.SendEmail("leandro.santilario@mthelmets.com", $"Email {textBoxCorreo.Text}: caambio de contraseña", $"Hola,\n\nEl usuario con email {textBoxCorreo.Text} ha cambiado su contraseña en el instante: {DateTime.Now}\n\nSaludos cordiales,\nEl equipo de MTHelmets-AC");
            }
            catch (Exception ex)
            {
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                alerta.ShowDialog();
                return;
            }
            
        }
    }
}
