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
            Log.Info("Formulario de Ajustes iniciado.");
        }
        private void ClienteForm_Load(object sender, EventArgs e)
        {
            Log.Info("Cargando clientes en el formulario.");
            buscarClientes(null);
            RegistrarClicks(this);
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
        private async void buscarClientes(string nombreFiltro)
        {
           //Lo que sea
        }
        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            //buscarClientes(textBoxCliente.Text);
        }

        private async void BotonMasC_Click(object sender, EventArgs e)
        {
            Log.Info("Abriendo formulario para crear un nuevo cliente.");
            Cliente nuevoCliente = new Cliente();
            var formNuevo = new ClienteDetailForm(nuevoCliente);

            formNuevo.ClienteCreadoCorrectamente += async cliente =>
            {
                if (!string.IsNullOrEmpty(cliente.Dni))
                {
                    //buscarClientes(textBoxCliente.Text);

                    var actualizarClienteForm = new ClienteDetailForm(cliente);
                    WindowManager.ShowForm(
                        $"{cliente.Dni}_Actualizar",
                        this,
                        () => actualizarClienteForm);

                    actualizarClienteForm.ClienteCreadoCorrectamente += async updatedCliente =>
                    {
                        if (!string.IsNullOrEmpty(updatedCliente.Dni) && !string.IsNullOrEmpty(updatedCliente.Nombre) && !string.IsNullOrEmpty(updatedCliente.Apellidos) && !string.IsNullOrEmpty(updatedCliente.Email))
                        {
                            //buscarClientes(textBoxCliente.Text);
                        }
                    };
                }
            };
            WindowManager.ShowForm(
                "Cliente_Nuevo",
                this,
                () => formNuevo);
        }

        private async void BotonMenosC_Click(object sender, EventArgs e)
        {
            
        }

        private async void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void Boton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(255, 59, 48);
                btn.ForeColor = Color.White;
            }
        }
        private void Boton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(225, 6, 0);
                btn.ForeColor = SystemColors.ControlLightLight;
            }
        }
        private void textBoxNombreCliente_EnterClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //buscarClientes(textBoxCliente.Text);
            }
        }
        private void BotonHelpC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En esta sección puedes gestionar los clientes. Usa el botón '+' para agregar un nuevo cliente, el botón '-' para eliminar el cliente seleccionado, y haz doble clic en un cliente para editar su información.", "Ayuda - Gestión de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PanelPlegado_Click(object sender, EventArgs e)
        {
            Log.Info("Abriendo panel de filtros.");
            panelLateralPlegado.Visible = false;
            panelLateral.Visible = true;
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
