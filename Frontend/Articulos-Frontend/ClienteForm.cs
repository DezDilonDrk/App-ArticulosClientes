using Articulos_Backend.Repositorios;
using Articulos_Frontend.Client;
using ClientesASPNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Articulos_Frontend;

public partial class ClienteForm : Form
{
    private ClienteApiClient ClienteApiClient;
    private ErrorProvider errorProvider;
    public ClienteForm()
    {
        InitializeComponent();

        string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
        ClienteApiClient = new ClienteApiClient();


    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void InitializeComponent()
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(ClienteForm));
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
        BotonMasC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        BotonMasC.BackColor = Color.DodgerBlue;
        BotonMasC.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        BotonMasC.ForeColor = SystemColors.ControlLightLight;
        BotonMasC.Location = new Point(760, 23);
        BotonMasC.Name = "BotonMasC";
        BotonMasC.Padding = new Padding(0, 0, 0, 4);
        BotonMasC.Size = new Size(60, 60);
        BotonMasC.TabIndex = 0;
        BotonMasC.Text = " +";
        BotonMasC.UseVisualStyleBackColor = false;
        BotonMasC.Click += BotonMasC_Click;
        BotonMasC.MouseEnter += Boton_MouseEnter;
        BotonMasC.MouseLeave += Boton_MouseLeave;
        // 
        // BotonMenosC
        // 
        BotonMenosC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        BotonMenosC.BackColor = Color.DodgerBlue;
        BotonMenosC.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        BotonMenosC.ForeColor = SystemColors.ControlLightLight;
        BotonMenosC.Location = new Point(760, 89);
        BotonMenosC.Name = "BotonMenosC";
        BotonMenosC.Padding = new Padding(0, 0, 0, 4);
        BotonMenosC.Size = new Size(60, 60);
        BotonMenosC.TabIndex = 1;
        BotonMenosC.Text = " -";
        BotonMenosC.UseVisualStyleBackColor = false;
        BotonMenosC.Click += BotonMenosC_Click;
        BotonMenosC.MouseEnter += Boton_MouseEnter;
        BotonMenosC.MouseLeave += Boton_MouseLeave;
        // 
        // labelNombreCliente
        // 
        labelNombreCliente.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        labelNombreCliente.BackColor = Color.Transparent;
        labelNombreCliente.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        labelNombreCliente.Location = new Point(209, 45);
        labelNombreCliente.Name = "labelNombreCliente";
        labelNombreCliente.Size = new Size(95, 31);
        labelNombreCliente.TabIndex = 2;
        labelNombreCliente.Text = "Nombre: ";
        // 
        // BotonBuscar
        // 
        BotonBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        BotonBuscar.BackColor = Color.DodgerBlue;
        BotonBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        BotonBuscar.ForeColor = SystemColors.ControlLightLight;
        BotonBuscar.Location = new Point(360, 104);
        BotonBuscar.MaximumSize = new Size(150, 30);
        BotonBuscar.Name = "BotonBuscar";
        BotonBuscar.Size = new Size(150, 30);
        BotonBuscar.TabIndex = 3;
        BotonBuscar.Text = "Buscar";
        BotonBuscar.UseVisualStyleBackColor = false;
        BotonBuscar.Click += BotonBuscar_Click;
        BotonBuscar.MouseEnter += Boton_MouseEnter;
        BotonBuscar.MouseLeave += Boton_MouseLeave;
        // 
        // textBoxCliente
        // 
        textBoxCliente.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        textBoxCliente.BorderStyle = BorderStyle.None;
        textBoxCliente.Location = new Point(310, 45);
        textBoxCliente.MaximumSize = new Size(200, 40);
        textBoxCliente.Multiline = true;
        textBoxCliente.Name = "textBoxCliente";
        textBoxCliente.PlaceholderText = "Busque aquí por nombre";
        textBoxCliente.Size = new Size(200, 40);
        textBoxCliente.TabIndex = 4;
        textBoxCliente.TextAlign = HorizontalAlignment.Center;
        // 
        // dgvCliente
        // 
        dgvCliente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvCliente.BackgroundColor = Color.MidnightBlue;
        dgvCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCliente.Location = new Point(12, 155);
        dgvCliente.MultiSelect = false;
        dgvCliente.Name = "dgvCliente";
        dgvCliente.ReadOnly = true;
        dgvCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCliente.Size = new Size(808, 225);
        dgvCliente.TabIndex = 5;
        dgvCliente.CellDoubleClick += dgvCliente_CellDoubleClick;
        // 
        // ClienteForm
        // 
        BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(832, 392);
        Controls.Add(dgvCliente);
        Controls.Add(textBoxCliente);
        Controls.Add(BotonBuscar);
        Controls.Add(labelNombreCliente);
        Controls.Add(BotonMenosC);
        Controls.Add(BotonMasC);
        MinimumSize = new Size(848, 431);
        Name = "ClienteForm";
        StartPosition = FormStartPosition.CenterScreen;
        Load += ClienteForm_Load;
        ((ISupportInitialize)dgvCliente).EndInit();
        ResumeLayout(false);
        PerformLayout();

    }
    private void ClienteForm_Load(object sender, EventArgs e)
    {
        buscarClientes(null);
    }
    private async void buscarClientes(string nombreFiltro)
    {
        IEnumerable<Cliente> clientes;
        if (string.IsNullOrWhiteSpace(nombreFiltro))
        {
            clientes = await ClienteApiClient.ObtenerClientes();
        }
        else
        {
            clientes = await ClienteApiClient.BuscarPorNombre(nombreFiltro);
        }
        dgvCliente.DataSource = clientes.ToList();
        if (dgvCliente.Columns["Dni"] != null)
        {
            dgvCliente.Columns["Dni"].Width = 80;
            dgvCliente.Columns["Dni"].Resizable = DataGridViewTriState.False;
        }
        if (dgvCliente.Columns["Nombre"] != null)
            dgvCliente.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        if (dgvCliente.Columns["Apellidos"] != null)
            dgvCliente.Columns["Apellidos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        if (dgvCliente.Columns["Email"] != null)
        {
            dgvCliente.Columns["Email"].Width = 250;
            dgvCliente.Columns["Email"].Resizable = DataGridViewTriState.False;
        }
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
                ClienteApiClient.Crear(nuevoCliente);
            }
            buscarClientes(textBoxCliente.Text);
        }
    }

    private void BotonMenosC_Click(object sender, EventArgs e)
    {
        ClienteApiClient.Eliminar(dgvCliente.CurrentRow.Cells["Dni"].Value.ToString());
        buscarClientes(textBoxCliente.Text);
    }

    private async void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            string dni = dgvCliente.Rows[e.RowIndex].Cells["Dni"].Value.ToString();
            Cliente cliente = await ClienteApiClient.ObtenerPorDni(dni);
            using (var form = new ClienteUpdateForm(cliente))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ClienteApiClient.Actualizar(dni, cliente);
                }
                buscarClientes(textBoxCliente.Text);
            }
        }
    }

    private void Boton_MouseEnter(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (btn != null)
        {
            btn.BackColor = Color.LightSkyBlue;
            btn.ForeColor = Color.RoyalBlue;
        }
    }
    private void Boton_MouseLeave(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (btn != null)
        {
            btn.BackColor = Color.DodgerBlue;
            btn.ForeColor = SystemColors.ControlLightLight;
        }
    }
}
