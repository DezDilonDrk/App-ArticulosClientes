using Articulos_Backend.Repositorios;
using ClientesASPNET;
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
        private ClienteRepository clienteRepository;
        public ClienteUpdateForm(Cliente cliente)
        {
            InitializeComponent();

            textBoxDni.Text = cliente.Dni;
            textBoxNombre.Text = cliente.Nombre;
            textBoxApellidos.Text = cliente.Apellidos;
            textBoxEmail.Text = cliente.Email;

            string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
            clienteRepository = new ClienteRepository(connStr);
        }

        private void InitializeComponent()
        {
            textBoxDni = new TextBox();
            textBoxNombre = new TextBox();
            textBoxApellidos = new TextBox();
            textBoxEmail = new TextBox();
            LabelDni = new Label();
            LabelNombre = new Label();
            LabelApellidos = new Label();
            LabelEmail = new Label();
            BotonActualizarC = new Button();
            SuspendLayout();
            // 
            // textBoxDni
            // 
            textBoxDni.Location = new Point(204, 73);
            textBoxDni.Name = "textBoxDni";
            textBoxDni.PlaceholderText = "Introduzca el dni";
            textBoxDni.Size = new Size(247, 23);
            textBoxDni.TabIndex = 11;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(204, 102);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.PlaceholderText = "Introduzca el nombre";
            textBoxNombre.Size = new Size(247, 23);
            textBoxNombre.TabIndex = 10;
            // 
            // textBoxApellidos
            // 
            textBoxApellidos.Location = new Point(204, 131);
            textBoxApellidos.Name = "textBoxApellidos";
            textBoxApellidos.PlaceholderText = "Introduzca el/los apellidos";
            textBoxApellidos.Size = new Size(247, 23);
            textBoxApellidos.TabIndex = 9;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(204, 160);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Introduzca el email";
            textBoxEmail.Size = new Size(247, 23);
            textBoxEmail.TabIndex = 8;
            // 
            // LabelDni
            // 
            LabelDni.AutoSize = true;
            LabelDni.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelDni.Location = new Point(149, 73);
            LabelDni.Name = "LabelDni";
            LabelDni.Size = new Size(45, 21);
            LabelDni.TabIndex = 4;
            LabelDni.Text = "Dni: ";
            LabelDni.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LabelNombre
            // 
            LabelNombre.AutoSize = true;
            LabelNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelNombre.Location = new Point(115, 102);
            LabelNombre.Name = "LabelNombre";
            LabelNombre.Size = new Size(81, 21);
            LabelNombre.TabIndex = 5;
            LabelNombre.Text = "Nombre: ";
            LabelNombre.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LabelApellidos
            // 
            LabelApellidos.AutoSize = true;
            LabelApellidos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelApellidos.Location = new Point(104, 131);
            LabelApellidos.Name = "LabelApellidos";
            LabelApellidos.Size = new Size(90, 21);
            LabelApellidos.TabIndex = 6;
            LabelApellidos.Text = "Apellidos: ";
            LabelApellidos.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LabelEmail
            // 
            LabelEmail.AutoSize = true;
            LabelEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LabelEmail.Location = new Point(135, 160);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(61, 21);
            LabelEmail.TabIndex = 7;
            LabelEmail.Text = "Email: ";
            LabelEmail.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BotonActualizarC
            // 
            BotonActualizarC.AutoSize = true;
            BotonActualizarC.BackColor = Color.LightGreen;
            BotonActualizarC.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BotonActualizarC.ForeColor = SystemColors.ControlDarkDark;
            BotonActualizarC.Location = new Point(301, 227);
            BotonActualizarC.Name = "BotonActualizarC";
            BotonActualizarC.Size = new Size(150, 30);
            BotonActualizarC.TabIndex = 12;
            BotonActualizarC.Text = "Actualizar";
            BotonActualizarC.UseVisualStyleBackColor = false;
            BotonActualizarC.Click += BotonActualizarC_Click;
            // 
            // ClienteUpdateForm
            // 
            BackgroundImage = Properties.Resources.hinh_nen_powerpoint_don_gian_11;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(580, 363);
            Controls.Add(BotonActualizarC);
            Controls.Add(LabelEmail);
            Controls.Add(LabelApellidos);
            Controls.Add(LabelNombre);
            Controls.Add(LabelDni);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxApellidos);
            Controls.Add(textBoxNombre);
            Controls.Add(textBoxDni);
            Name = "ClienteUpdateForm";
            ResumeLayout(false);
            PerformLayout();

        }

        private void BotonActualizarC_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxDni.Text) && !string.IsNullOrEmpty(textBoxNombre.Text) && !string.IsNullOrEmpty(textBoxApellidos.Text) && !string.IsNullOrEmpty(textBoxDni.Text))
            {
                try
                {
                    Cliente cliente = new Cliente(textBoxDni.Text, textBoxNombre.Text, textBoxApellidos.Text, textBoxEmail.Text);
                    clienteRepository.Actualizar(cliente);
                    MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al crear el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, rellene todos los campos para crear el cliente.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
