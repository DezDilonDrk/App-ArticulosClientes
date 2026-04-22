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

namespace Articulos_Frontend.Forms.main
{
    public partial class AjustesForm : Form
    {
        StringValuesSP stringValuesSP = new StringValuesSP();
        private ErrorProvider errorProvider;
        ShowTerminal terminal;
        private List<Cliente> listaActual;
        private bool admin = true;
        public string DniSeleccionado;
        public string ModoInvocacion;
        public AjustesForm()
        {
            InitializeComponent();
            string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
            StyleManager.StyleForm(this);
            this.ActiveControl = textBoxBuscadorAjustes;
            this.panelLateralPlegado.Visible = true;
            panelAccountSettings.Visible = false;
            panelNotificationSettings.Visible = false;
            this.buttonLogout.Text = stringValuesSP.logout;
            Log.Info("Formulario de Ajustes iniciado.");
        }
        private void AjustesForm_Load(object sender, EventArgs e)
        {
            Log.Info("Cargando clientes en el formulario.");
            buscarClientes(null);
            RegistrarClicks(this);
            syncCheckNotifications();
            if (!AppState.Roles.Contains(Roles.AdminVentas)) {admin = false;} else {admin = true;}
        }
        private void Ajustes_Paint(object sender, PaintEventArgs e)
        {
            if(sender == null) return;
            Rectangle rect;
            if (sender is Button btn)
            {
                btn = sender as Button;
                if (btn == null) return;
                rect = new Rectangle(0, 0, btn.Width, btn.Height);
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImage(btn.Image, rect);
            }
            if (sender is PictureBox pb)
            {
                pb = sender as PictureBox;
                if (pb == null) return;
                rect = new Rectangle(0, 0, pb.Width, pb.Height);
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImage(pb.Image, rect);
            }
        }
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            WindowManager.ShowForm(stringValuesSP.apartadoIniciarSesion, this, () => new LoginForm());

            var abiertos = WindowManager.OpenWindows.Values.ToList();
            foreach (var entry in abiertos)
            {
                try { entry.formularioHijo.Close(); }
                catch (Exception ex)
                {
                    Log.Error("Error al cerrar la ventana: " + ex.Message);
                }
            }
            this.Close();
        }
        private void buttonTerminal_Click(object sender, EventArgs e)
        {
            Log.Info("Abriendo terminal.");
            WindowManager.ShowForm(stringValuesSP.terminal, this, () =>
            {
                terminal = new ShowTerminal();
                return terminal;
            });
        }
        private async void buscarClientes(string nombreFiltro)
        {
           //Lo que sea
        }
        private async void openOptionAjustes(object sender, EventArgs e)
        {
            if (sender != null)
            {
                switch (((Control)sender).Name)
                {
                    case "labelAccountSettings":
                        Log.Info("Abriendo panel de configuración de cuenta.");
                        panelAccountSettings.Visible = true;
                        panelNotificationSettings.Visible = false;
                        break;
                    case "labelNotificationSettings":
                        Log.Info("Abriendo panel de configuración de notificaciones.");
                        panelAccountSettings.Visible = false;
                        panelNotificationSettings.Visible = true;
                        break;
                }
            }
        }
        private void textBoxNombreCliente_EnterClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //buscarClientes(textBoxCliente.Text);
            }
        }
        private void PanelPlegado_Click(object sender, EventArgs e)
        {
            Log.Info("Abriendo panel de filtros.");
            panelLateralPlegado.Visible = false;
            panelLateral.Visible = true;
        }
        private void markCheckNotifications_Click(object sender, EventArgs e)
        {
            Log.Info("Marcando el checkbox de notificaciones.");
            if (this.Owner != null)
            {
                var menu = this.Owner as Menu;
                if (menu != null)
                {
                    menu.changeSendEmailNotification();
                }
            }
        }
        private void syncCheckNotifications()
        {
            if (this.Owner != null)
            {
                var menu = this.Owner as Menu;
                if (menu != null)
                {
                    bool shouldbeChecked = menu.getSendEmailNotification();
                    if (shouldbeChecked)
                    {
                        checkCreateObjectEmailNotifications.Checked = true;
                        return;
                    }
                    checkCreateObjectEmailNotifications.Checked = false;
                }
            }
        }
        private void RegistrarClicks(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c == panelLateral)
                    continue;

                c.Click += CerrarPanelClickFuera;

                if (c.HasChildren)
                    RegistrarClicks(c);
            }

            parent.Click += CerrarPanelClickFuera;
        }
        private void CerrarPanelClickFuera(object sender, EventArgs e)
        {
            if (panelLateral.Visible)
            {
                Point mousePos = this.PointToClient(Cursor.Position);

                if (!panelLateral.Bounds.Contains(mousePos))
                {
                    panelLateral.Visible = false;
                    Log.Info("Cerrando panel de filtros al hacer clic fuera del panel.");
                    panelLateralPlegado.Visible = true;
                }
            }
        }
    }
}
