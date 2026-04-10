using Articulos_Frontend.Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Articulos_Frontend
{
    public partial class Alerta : Form
    {
        public bool resultado = false;
        public enum AlertaTipo
        {
            Error,
            Warning,
            Info
        }
        private AlertaTipo tipo;
        private string _alertaTipo;
        private string _alertaDesc;
        private string _alertaLinea;
        public Alerta(AlertaTipo alertaTipo, Exception ex)
        {
            InitializeComponent();
            tipo = alertaTipo;
            _alertaDesc = ex.ToString();
            _alertaTipo = ex.GetType().Name;
            _alertaLinea = ex.StackTrace;
            StyleManager.StyleForm(this);

            switch ( tipo)
            {
                case AlertaTipo.Error:
                    imagenAlerta.BackgroundImage = Properties.Resources._8a027296c847ff9188483471a1830469;
                    buttonConfirm.Visible = true;
                    buttonConfirm.Text = "Aceptar";
                    buttonCancel.Visible = false;
                    if (ex != null)
                    {
                        excepcionAlerta.Visible = true;
                        lineaAlerta.Visible = true;
                        titulolAlerta.Text = $"Error: {ex.Message}";
                        descripcionAlerta.Text = ex.ToString();
                        excepcionAlerta.Text = _alertaTipo;
                        lineaAlerta.Text = _alertaLinea;
                    }
                    break;

                case AlertaTipo.Warning:
                    imagenAlerta.BackgroundImage = Properties.Resources.Yellow_Emoji_Face_meme_4;
                    excepcionAlerta.Visible = false;
                    lineaAlerta.Visible = false;
                    buttonConfirm.Visible = true;
                    buttonConfirm.Text = "Si";
                    buttonCancel.Visible = true;
                    buttonCancel.Text = "No";
                    titulolAlerta.Text = ex.Message;
                    descripcionAlerta.Text = "Se eliminará el articulo seleccionado. Esta acción es irreversible.";
                    break;

                case AlertaTipo.Info:
                    imagenAlerta.BackgroundImage = Properties.Resources._6a34ad6fa56d91529822911a0b8021ab;
                    excepcionAlerta.Visible = false;
                    lineaAlerta.Visible = false;
                    buttonConfirm.Visible = true;
                    buttonConfirm.Text = "Aceptar";
                    buttonCancel.Visible = false;
                    titulolAlerta.Text = "Información";
                    descripcionAlerta.Text = "La acción se ha completado exitosamente.";
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            resultado = true;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            resultado = false;
            this.Close();
        }
    }
}
