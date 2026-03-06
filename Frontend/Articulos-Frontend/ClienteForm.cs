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
            BotonMasC = new Button();
            BotonMenosC = new Button();
            labelNombreCliente = new Label();
            BotonBuscar = new Button();
            textBoxCliente = new TextBox();
            dgvCliente = new DataGridView();
            ((ISupportInitialize)dgvCliente).BeginInit();
            SuspendLayout();
            // 
            // BotonMasC
            // 
            BotonMasC.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            BotonMasC.Location = new Point(760, 23);
            BotonMasC.Name = "BotonMasC";
            BotonMasC.Padding = new Padding(0, 0, 0, 4);
            BotonMasC.Size = new Size(60, 60);
            BotonMasC.TabIndex = 0;
            BotonMasC.Text = " +";
            BotonMasC.UseVisualStyleBackColor = true;
            BotonMasC.Click += BotonMasC_Click;
            // 
            // BotonMenosC
            // 
            BotonMenosC.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            BotonMenosC.Location = new Point(760, 89);
            BotonMenosC.Name = "BotonMenosC";
            BotonMenosC.Padding = new Padding(0, 0, 0, 4);
            BotonMenosC.Size = new Size(60, 60);
            BotonMenosC.TabIndex = 1;
            BotonMenosC.Text = " -";
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
            BotonBuscar.BackColor = SystemColors.GradientActiveCaption;
            BotonBuscar.Font = new Font("Segoe UI", 10F);
            BotonBuscar.Location = new Point(360, 104);
            BotonBuscar.Name = "BotonBuscar";
            BotonBuscar.Size = new Size(150, 30);
            BotonBuscar.TabIndex = 3;
            BotonBuscar.Text = "Buscar";
            BotonBuscar.UseVisualStyleBackColor = false;
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
            // 
            // dgvCliente
            // 
            dgvCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCliente.Location = new Point(12, 155);
            dgvCliente.MultiSelect = false;
            dgvCliente.Name = "dgvCliente";
            dgvCliente.ReadOnly = true;
            dgvCliente.CellDoubleClick += dgvCliente_CellDoubleClick;
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
            Controls.Add(BotonMasC);
            Name = "ClienteForm";
            ((ISupportInitialize)dgvCliente).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
        private void buscarClientes(string nombreFiltro)
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
            buscarClientes(textBoxCliente.Text);
        }

        private void BotonMasC_Click(object sender, EventArgs e)
        {
            Cliente nuevoCliente = new Cliente();

            using (var form = new ClienteDetailForm(nuevoCliente))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    clienteRepository.Insertar(nuevoCliente);
                }
                buscarClientes(textBoxCliente.Text);
            }
        }

        private void BotonMenosC_Click(object sender, EventArgs e)
        {
            clienteRepository.Eliminar(dgvCliente.CurrentRow.Cells["Dni"].Value.ToString());
            buscarClientes(textBoxCliente.Text);
        }

        private void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string dni = dgvCliente.Rows[e.RowIndex].Cells["Dni"].Value.ToString();
                Cliente cliente = clienteRepository.ObtenerPorDni(dni);
                using (var form = new ClienteUpdateForm(cliente))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        clienteRepository.Actualizar(cliente);
                    }
                    buscarClientes(textBoxCliente.Text);
                }
            }
        }
    }
}
