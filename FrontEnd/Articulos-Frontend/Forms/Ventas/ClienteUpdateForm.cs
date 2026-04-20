
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
    public partial class ClienteUpdateForm : Form
    {
        private ClienteApiClient clienteApiClient;
        public event Action<Cliente> ClienteActualizadoCorrectamente;
        private StringValuesSP stringValuesSP = new StringValuesSP();
        public ClienteUpdateForm(Cliente cliente)
        {
            InitializeComponent();

            textBoxDni.Text = cliente.Dni;
            textBoxNombre.Text = cliente.Nombre;
            textBoxApellidos.Text = cliente.Apellidos;
            textBoxEmail.Text = cliente.Email;

            string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
            clienteApiClient = new ClienteApiClient();
            StyleManager.StyleForm(this);
            Log.Info("Formulario de actualización de cliente iniciado para cliente con DNI: " + cliente.Dni);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ClienteUpdateForm));
            textBoxDni = new TextBox();
            textBoxNombre = new TextBox();
            textBoxApellidos = new TextBox();
            textBoxEmail = new TextBox();
            LabelDni = new Label();
            LabelNombre = new Label();
            LabelApellidos = new Label();
            LabelEmail = new Label();
            BotonActualizarC = new Button();
            LabelTitulo = new Label();
            SuspendLayout();
            // 
            // textBoxDni
            // 
            textBoxDni.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxDni.Location = new Point(204, 93);
            textBoxDni.Name = "textBoxDni";
            textBoxDni.PlaceholderText = "Introduzca el dni";
            textBoxDni.ReadOnly = true;
            textBoxDni.Size = new Size(247, 23);
            textBoxDni.TabIndex = 0;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNombre.Location = new Point(204, 122);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.PlaceholderText = "Introduzca el nombre";
            textBoxNombre.Size = new Size(247, 23);
            textBoxNombre.TabIndex = 1;
            // 
            // textBoxApellidos
            // 
            textBoxApellidos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxApellidos.Location = new Point(204, 151);
            textBoxApellidos.Name = "textBoxApellidos";
            textBoxApellidos.PlaceholderText = "Introduzca el/los apellidos";
            textBoxApellidos.Size = new Size(247, 23);
            textBoxApellidos.TabIndex = 2;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxEmail.Location = new Point(204, 180);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Introduzca el email";
            textBoxEmail.Size = new Size(247, 23);
            textBoxEmail.TabIndex = 3;
            // 
            // LabelDni
            // 
            LabelDni.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LabelDni.BackColor = Color.Transparent;
            LabelDni.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelDni.Location = new Point(104, 93);
            LabelDni.Name = "LabelDni";
            LabelDni.Size = new Size(90, 21);
            LabelDni.TabIndex = 4;
            LabelDni.Tag = "normalText";
            LabelDni.Text = "Dni: ";
            LabelDni.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelNombre
            // 
            LabelNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LabelNombre.BackColor = Color.Transparent;
            LabelNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelNombre.Location = new Point(104, 122);
            LabelNombre.Name = "LabelNombre";
            LabelNombre.Size = new Size(90, 21);
            LabelNombre.TabIndex = 5;
            LabelNombre.Tag = "normalText";
            LabelNombre.Text = "Nombre: ";
            LabelNombre.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelApellidos
            // 
            LabelApellidos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LabelApellidos.BackColor = Color.Transparent;
            LabelApellidos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelApellidos.Location = new Point(104, 151);
            LabelApellidos.Name = "LabelApellidos";
            LabelApellidos.Size = new Size(90, 21);
            LabelApellidos.TabIndex = 6;
            LabelApellidos.Tag = "normalText";
            LabelApellidos.Text = "Apellidos: ";
            LabelApellidos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelEmail
            // 
            LabelEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LabelEmail.BackColor = Color.Transparent;
            LabelEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelEmail.Location = new Point(104, 180);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(90, 21);
            LabelEmail.TabIndex = 7;
            LabelEmail.Tag = "normalText";
            LabelEmail.Text = "Email: ";
            LabelEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BotonActualizarC
            // 
            BotonActualizarC.AutoSize = true;
            BotonActualizarC.BackColor = Color.DodgerBlue;
            BotonActualizarC.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BotonActualizarC.ForeColor = SystemColors.ControlLightLight;
            BotonActualizarC.Location = new Point(301, 248);
            BotonActualizarC.Name = "BotonActualizarC";
            BotonActualizarC.Size = new Size(150, 30);
            BotonActualizarC.TabIndex = 5;
            BotonActualizarC.Text = "Actualizar";
            BotonActualizarC.UseVisualStyleBackColor = false;
            BotonActualizarC.Click += BotonActualizarC_Click;
            // 
            // LabelTitulo
            // 
            LabelTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LabelTitulo.BackColor = Color.Transparent;
            LabelTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            LabelTitulo.Location = new Point(135, 18);
            LabelTitulo.Name = "LabelTitulo";
            LabelTitulo.Size = new Size(316, 36);
            LabelTitulo.TabIndex = 0;
            LabelTitulo.Tag = "title";
            LabelTitulo.Text = stringValuesSP.actualizarCliente;
            LabelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ClienteUpdateForm
            // 
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(580, 363);
            Controls.Add(LabelTitulo);
            Controls.Add(BotonActualizarC);
            Controls.Add(LabelEmail);
            Controls.Add(LabelApellidos);
            Controls.Add(LabelNombre);
            Controls.Add(LabelDni);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxApellidos);
            Controls.Add(textBoxNombre);
            Controls.Add(textBoxDni);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(596, 402);
            MinimumSize = new Size(596, 402);
            Name = "ClienteUpdateForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = stringValuesSP.actualizarCliente;
            ResumeLayout(false);
            PerformLayout();

        }
        private async void BotonActualizarC_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxDni.Text) && !string.IsNullOrEmpty(textBoxNombre.Text) && !string.IsNullOrEmpty(textBoxApellidos.Text) && !string.IsNullOrEmpty(textBoxDni.Text))
            {
                try
                {
                    Log.Info("Intento de actualización de cliente con DNI: " + textBoxDni.Text);
                    try
                    {
                        Cliente cliente = new Cliente(textBoxDni.Text, textBoxNombre.Text, textBoxApellidos.Text, textBoxEmail.Text, DateTime.Now, DateTime.Now);
                        await clienteApiClient.Actualizar(cliente.Dni, cliente);
                        MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClienteActualizadoCorrectamente?.Invoke(cliente);
                        Log.Info("Cliente actualizado correctamente: " + cliente.Dni);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Error al actualizar el cliente: " + ex.Message);
                        Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                        alerta.ShowDialog();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Error inesperado al actualizar el cliente: " + ex.Message);
                    Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                    alerta.ShowDialog();
                    return;
                }
            }
            else
            {
                Log.Warn("Intento de actualizar cliente con campos incompletos.");
                MessageBox.Show("Por favor, rellene todos los campos para crear el cliente.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
