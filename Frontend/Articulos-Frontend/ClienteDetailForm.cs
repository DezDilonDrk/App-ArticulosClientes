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
    public partial class ClienteDetailForm : Form
    {
        private ClienteRepository clienteRepository;
        public ClienteDetailForm(Cliente cliente)
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            LabelDni = new Label();
            LabelNombre = new Label();
            LabelApellidos = new Label();
            LabelEmail = new Label();
            SuspendLayout();
            // 
            // LabelDni
            // 
            LabelDni.AutoSize = true;
            LabelDni.Location = new Point(96, 67);
            LabelDni.Name = "LabelDni";
            LabelDni.Size = new Size(38, 15);
            LabelDni.TabIndex = 4;
            LabelDni.Text = "Dni: ";
            // 
            // LabelNombre
            // 
            LabelNombre.AutoSize = true;
            LabelNombre.Location = new Point(95, 95);
            LabelNombre.Name = "LabelNombre";
            LabelNombre.Size = new Size(38, 15);
            LabelNombre.TabIndex = 5;
            LabelNombre.Text = "Nombre: ";
            // 
            // LabelApellidos
            // 
            LabelApellidos.AutoSize = true;
            LabelApellidos.Location = new Point(95, 130);
            LabelApellidos.Name = "LabelApellidos";
            LabelApellidos.Size = new Size(38, 15);
            LabelApellidos.TabIndex = 6;
            LabelApellidos.Text = "Apellidos: ";
            // 
            // LabelEmail
            // 
            LabelEmail.AutoSize = true;
            LabelEmail.Location = new Point(103, 172);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(38, 15);
            LabelEmail.TabIndex = 7;
            LabelEmail.Text = "Email: ";
            // 
            // ClienteDetailForm
            // 
            ClientSize = new Size(580, 363);
            Controls.Add(LabelEmail);
            Controls.Add(LabelApellidos);
            Controls.Add(LabelNombre);
            Controls.Add(LabelDni);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "ClienteDetailForm";
            ResumeLayout(false);
            PerformLayout();

        }

        private void BotonMasC_Click(object sender, EventArgs e)
        {

        }

        private void BotonMenosC_Click(object sender, EventArgs e)
        {

        }
    }
}
