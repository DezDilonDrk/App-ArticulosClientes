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
    public partial class ClienteForm : Form
    {
        private ClienteRepository clienteRepository;
        public ClienteForm()
        {
            InitializeComponent();

            string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
            clienteRepository = new ClienteRepository(connStr);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            s = new Button();
            BotonMenosC = new Button();
            labelNombreCliente = new Label();
            BotonBuscar = new Button();
            textBoxCliente = new TextBox();
            dgvCliente = new DataGridView();
            ((ISupportInitialize)dgvCliente).BeginInit();
            SuspendLayout();
            // 
            // s
            // 
            s.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            s.Location = new Point(760, 23);
            s.Name = "s";
            s.Padding = new Padding(0, 0, 0, 4);
            s.Size = new Size(60, 60);
            s.TabIndex = 0;
            s.Text = " + ";
            s.UseVisualStyleBackColor = true;
            s.Click += BotonMasC_Click;
            // 
            // BotonMenosC
            // 
            BotonMenosC.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            BotonMenosC.Location = new Point(760, 89);
            BotonMenosC.Name = "BotonMenosC";
            BotonMenosC.Padding = new Padding(0, 0, 0, 4);
            BotonMenosC.Size = new Size(60, 60);
            BotonMenosC.TabIndex = 1;
            BotonMenosC.Text = " - ";
            BotonMenosC.UseVisualStyleBackColor = true;
            BotonMenosC.Click += BotonMenosC_Click;
            // 
            // labelNombreCliente
            // 
            labelNombreCliente.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelNombreCliente.Location = new Point(209, 45);
            labelNombreCliente.Name = "labelNombreCliente";
            labelNombreCliente.Size = new Size(95, 31);
            labelNombreCliente.TabIndex = 2;
            labelNombreCliente.Text = "Nombre: ";
            // 
            // BotonBuscar
            // 
            BotonBuscar.Font = new Font("Segoe UI", 10F);
            BotonBuscar.Location = new Point(360, 104);
            BotonBuscar.Name = "BotonBuscar";
            BotonBuscar.Size = new Size(150, 30);
            BotonBuscar.TabIndex = 3;
            BotonBuscar.Text = "Buscar";
            BotonBuscar.UseVisualStyleBackColor = true;
            BotonBuscar.Click += BotonBuscar_Click;
            // 
            // textBoxCliente
            // 
            textBoxCliente.Location = new Point(310, 45);
            textBoxCliente.Multiline = true;
            textBoxCliente.Name = "textBoxCliente";
            textBoxCliente.PlaceholderText = "Busque aquí por nombre";
            textBoxCliente.Size = new Size(200, 40);
            textBoxCliente.TabIndex = 4;
            textBoxCliente.TextAlign = HorizontalAlignment.Center;
            textBoxCliente.TextChanged += textBox_TextChanged;
            // 
            // dgvCliente
            // 
            dgvCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCliente.Location = new Point(12, 155);
            dgvCliente.MultiSelect = false;
            dgvCliente.Name = "dgvCliente";
            dgvCliente.ReadOnly = true;
            dgvCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCliente.Size = new Size(808, 225);
            dgvCliente.TabIndex = 5;
            // 
            // ClienteForm
            // 
            ClientSize = new Size(832, 392);
            Controls.Add(dgvCliente);
            Controls.Add(textBoxCliente);
            Controls.Add(BotonBuscar);
            Controls.Add(labelNombreCliente);
            Controls.Add(BotonMenosC);
            Controls.Add(s);
            Name = "ClienteForm";
            ((ISupportInitialize)dgvCliente).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void cargarClientes(string nombreFiltro)
        {
            IEnumerable<Cliente> clientes;
            if (string.IsNullOrWhiteSpace(nombreFiltro))
            {
                clientes = clienteRepository.ObtenerClientes();
            }
            else
            {
                clientes = clienteRepository.BuscarPorNombre(nombreFiltro);
            }
            dgvCliente.DataSource = clientes.ToList();
        }

        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            cargarClientes(textBoxCliente.Text);
        }

        private void BotonMasC_Click(object sender, EventArgs e)
        {

        }

        private void BotonMenosC_Click(object sender, EventArgs e)
        {

        }
    }
}
