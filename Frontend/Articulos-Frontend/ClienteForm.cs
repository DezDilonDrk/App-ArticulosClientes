
using Articulos_Frontend.Client;
using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Articulos_Frontend;

public partial class ClienteForm : Form
{
    private ClienteApiClient ClienteApiClient;
    private ErrorProvider errorProvider;
    private List<Cliente> listaActual;
    public ClienteForm()
    {
        InitializeComponent();

        string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
        ClienteApiClient = new ClienteApiClient();
        StyleManager.StyleForm(this);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        ComponentResourceManager resources = new ComponentResourceManager(typeof(ClienteForm));
        BotonMasC = new Button();
        BotonMenosC = new Button();
        labelNombreCliente = new Label();
        BotonBuscar = new Button();
        textBoxCliente = new TextBox();
        dgvCliente = new DataGridView();
        BotonHelpC = new Button();
        FechaDesde = new DateTimePicker();
        FiltroFecha = new GroupBox();
        labelFechaMax = new Label();
        labelFechaMin = new Label();
        FechaHasta = new DateTimePicker();
        Filtros = new Button();
        panelFiltros = new Panel();
        ((ISupportInitialize)dgvCliente).BeginInit();
        FiltroFecha.SuspendLayout();
        panelFiltros.SuspendLayout();
        SuspendLayout();
        // 
        // BotonMasC
        // 
        BotonMasC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        BotonMasC.BackColor = Color.FromArgb(225, 6, 0);
        BotonMasC.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        BotonMasC.ForeColor = Color.White;
        BotonMasC.Location = new Point(697, 71);
        BotonMasC.Margin = new Padding(0);
        BotonMasC.Name = "BotonMasC";
        BotonMasC.Size = new Size(60, 45);
        BotonMasC.TabIndex = 3;
        BotonMasC.Text = " +";
        BotonMasC.UseVisualStyleBackColor = false;
        BotonMasC.Click += BotonMasC_Click;
        BotonMasC.MouseEnter += Boton_MouseEnter;
        BotonMasC.MouseLeave += Boton_MouseLeave;
        // 
        // BotonMenosC
        // 
        BotonMenosC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        BotonMenosC.BackColor = Color.FromArgb(225, 6, 0);
        BotonMenosC.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        BotonMenosC.ForeColor = Color.White;
        BotonMenosC.Location = new Point(760, 71);
        BotonMenosC.Name = "BotonMenosC";
        BotonMenosC.Padding = new Padding(0, 0, 0, 4);
        BotonMenosC.Size = new Size(60, 45);
        BotonMenosC.TabIndex = 4;
        BotonMenosC.Text = " -";
        BotonMenosC.UseVisualStyleBackColor = false;
        BotonMenosC.Click += BotonMenosC_Click;
        BotonMenosC.MouseEnter += Boton_MouseEnter;
        BotonMenosC.MouseLeave += Boton_MouseLeave;
        // 
        // labelNombreCliente
        // 
        labelNombreCliente.BackColor = Color.Transparent;
        labelNombreCliente.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
        labelNombreCliente.ForeColor = Color.FromArgb(242, 242, 242);
        labelNombreCliente.Location = new Point(12, 13);
        labelNombreCliente.Name = "labelNombreCliente";
        labelNombreCliente.Size = new Size(63, 15);
        labelNombreCliente.TabIndex = 2;
        labelNombreCliente.Text = "Nombre: ";
        // 
        // BotonBuscar
        // 
        BotonBuscar.BackColor = Color.FromArgb(225, 6, 0);
        BotonBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        BotonBuscar.ForeColor = Color.White;
        BotonBuscar.Location = new Point(12, 71);
        BotonBuscar.Name = "BotonBuscar";
        BotonBuscar.Size = new Size(200, 45);
        BotonBuscar.TabIndex = 2;
        BotonBuscar.Text = "Buscar";
        BotonBuscar.UseVisualStyleBackColor = false;
        BotonBuscar.Click += BotonBuscar_Click;
        BotonBuscar.MouseEnter += Boton_MouseEnter;
        BotonBuscar.MouseLeave += Boton_MouseLeave;
        // 
        // textBoxCliente
        // 
        textBoxCliente.BackColor = Color.FromArgb(42, 42, 42);
        textBoxCliente.BorderStyle = BorderStyle.None;
        textBoxCliente.Font = new Font("Segoe UI", 9F);
        textBoxCliente.ForeColor = Color.FromArgb(242, 242, 242);
        textBoxCliente.Location = new Point(81, 14);
        textBoxCliente.MaxLength = 60;
        textBoxCliente.Name = "textBoxCliente";
        textBoxCliente.PlaceholderText = "Busque aquí por nombre";
        textBoxCliente.Size = new Size(200, 16);
        textBoxCliente.TabIndex = 1;
        textBoxCliente.TextAlign = HorizontalAlignment.Center;
        // 
        // dgvCliente
        // 
        dgvCliente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvCliente.BackgroundColor = Color.FromArgb(42, 42, 42);
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(60, 60, 60);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(242, 242, 242);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(60, 60, 60);
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCliente.EditMode = DataGridViewEditMode.EditOnEnter;
        dgvCliente.EnableHeadersVisualStyles = false;
        dgvCliente.GridColor = Color.FromArgb(42, 42, 42);
        dgvCliente.Location = new Point(12, 122);
        dgvCliente.MultiSelect = false;
        dgvCliente.Name = "dgvCliente";
        dgvCliente.ReadOnly = true;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 60, 60);
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(242, 242, 242);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(204, 42, 36);
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
        dgvCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
        dgvCliente.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(42, 42, 42);
        dgvCliente.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(242, 242, 242);
        dgvCliente.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 42, 36);
        dgvCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCliente.Size = new Size(808, 258);
        dgvCliente.TabIndex = 5;
        dgvCliente.CellDoubleClick += dgvCliente_CellDoubleClick;
        // 
        // BotonHelpC
        // 
        BotonHelpC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        BotonHelpC.BackColor = Color.FromArgb(225, 6, 0);
        BotonHelpC.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        BotonHelpC.ForeColor = Color.White;
        BotonHelpC.Location = new Point(790, 12);
        BotonHelpC.Name = "BotonHelpC";
        BotonHelpC.Size = new Size(30, 30);
        BotonHelpC.TabIndex = 0;
        BotonHelpC.Text = "?";
        BotonHelpC.UseVisualStyleBackColor = false;
        BotonHelpC.Click += BotonHelpC_Click;
        BotonHelpC.MouseEnter += Boton_MouseEnter;
        BotonHelpC.MouseLeave += Boton_MouseLeave;
        // 
        // FechaDesde
        // 
        FechaDesde.AllowDrop = true;
        FechaDesde.CalendarForeColor = Color.Black;
        FechaDesde.CalendarMonthBackground = SystemColors.GrayText;
        FechaDesde.CalendarTitleForeColor = Color.Black;
        FechaDesde.Format = DateTimePickerFormat.Short;
        FechaDesde.Location = new Point(99, 22);
        FechaDesde.Name = "FechaDesde";
        FechaDesde.Size = new Size(97, 23);
        FechaDesde.TabIndex = 6;
        FechaDesde.Value = new DateTime(1979, 8, 10, 0, 0, 0, 0);
        FechaDesde.ValueChanged += FiltrarPorFecha;
        // 
        // FiltroFecha
        // 
        FiltroFecha.BackColor = Color.Transparent;
        FiltroFecha.Controls.Add(labelFechaMax);
        FiltroFecha.Controls.Add(labelFechaMin);
        FiltroFecha.Controls.Add(FechaHasta);
        FiltroFecha.Controls.Add(FechaDesde);
        FiltroFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        FiltroFecha.ForeColor = Color.FromArgb(242, 242, 242);
        FiltroFecha.Location = new Point(11, 8);
        FiltroFecha.Name = "FiltroFecha";
        FiltroFecha.Size = new Size(200, 85);
        FiltroFecha.TabIndex = 7;
        FiltroFecha.TabStop = false;
        FiltroFecha.Text = "Filtrar Resultado por Fecha";
        // 
        // labelFechaMax
        // 
        labelFechaMax.AutoSize = true;
        labelFechaMax.Location = new Point(10, 57);
        labelFechaMax.Name = "labelFechaMax";
        labelFechaMax.Size = new Size(86, 15);
        labelFechaMax.TabIndex = 9;
        labelFechaMax.Text = "Fecha Máxima";
        // 
        // labelFechaMin
        // 
        labelFechaMin.AutoSize = true;
        labelFechaMin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        labelFechaMin.Location = new Point(10, 27);
        labelFechaMin.Name = "labelFechaMin";
        labelFechaMin.Size = new Size(83, 15);
        labelFechaMin.TabIndex = 8;
        labelFechaMin.Text = "Fecha Mínima";
        // 
        // FechaHasta
        // 
        FechaHasta.CalendarForeColor = Color.Black;
        FechaHasta.CalendarMonthBackground = SystemColors.GrayText;
        FechaHasta.CalendarTitleForeColor = Color.Black;
        FechaHasta.Format = DateTimePickerFormat.Short;
        FechaHasta.Location = new Point(99, 51);
        FechaHasta.Name = "FechaHasta";
        FechaHasta.Size = new Size(97, 23);
        FechaHasta.TabIndex = 7;
        FechaHasta.Value = new DateTime(2099, 12, 31, 0, 0, 0, 0);
        FechaHasta.ValueChanged += FiltrarPorFecha;
        // 
        // Filtros
        // 
        Filtros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        Filtros.BackColor = Color.FromArgb(225, 6, 0);
        Filtros.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        Filtros.ForeColor = Color.White;
        Filtros.Location = new Point(522, 71);
        Filtros.Name = "Filtros";
        Filtros.Size = new Size(150, 45);
        Filtros.TabIndex = 8;
        Filtros.Text = " Abrir Filtros ▶";
        Filtros.UseVisualStyleBackColor = false;
        Filtros.Click += Filtros_Click;
        // 
        // panelFiltros
        // 
        panelFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        panelFiltros.AutoScroll = true;
        panelFiltros.BackColor = Color.FromArgb(58, 58, 58);
        panelFiltros.Controls.Add(FiltroFecha);
        panelFiltros.Location = new Point(420, 122);
        panelFiltros.Name = "panelFiltros";
        panelFiltros.Size = new Size(252, 238);
        panelFiltros.TabIndex = 9;
        panelFiltros.Visible = false;
        // 
        // ClienteForm
        // 
        BackColor = Color.FromArgb(26, 26, 26);
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(832, 392);
        Controls.Add(BotonHelpC);
        Controls.Add(panelFiltros);
        Controls.Add(Filtros);
        Controls.Add(dgvCliente);
        Controls.Add(textBoxCliente);
        Controls.Add(BotonBuscar);
        Controls.Add(labelNombreCliente);
        Controls.Add(BotonMenosC);
        Controls.Add(BotonMasC);
        ForeColor = SystemColors.ControlLight;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MinimumSize = new Size(848, 431);
        Name = "ClienteForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Sección Cliente";
        Load += ClienteForm_Load;
        ((ISupportInitialize)dgvCliente).EndInit();
        FiltroFecha.ResumeLayout(false);
        FiltroFecha.PerformLayout();
        panelFiltros.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();

    }
    private void ClienteForm_Load(object sender, EventArgs e)
    {
        buscarClientes(null);
    }
    private void FiltrarPorFecha(object sender, EventArgs e)
    {
        List<Cliente> clientesFiltrados = listaActual;
        clientesFiltrados = clientesFiltrados.Where(c => c.FechaCreacion.Date >= FechaDesde.Value.Date).ToList();
        if (FechaHasta.Value.Date < FechaDesde.Value.Date)
        {
            MessageBox.Show("La fecha máxima no puede ser anterior a la fecha mínima. Por favor, ajusta las fechas.", "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            FechaHasta.Value = FechaDesde.Value.Date;
            return;
        }
        clientesFiltrados = clientesFiltrados.Where(c => c.FechaCreacion.Date <= FechaHasta.Value.Date).ToList();
        dgvCliente.DataSource = clientesFiltrados;
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
        clientes = clientes.Where(c => c.FechaCreacion.Date >= FechaDesde.Value.Date);
        clientes = clientes.Where(c => c.FechaCreacion.Date <= FechaHasta.Value.Date);
        dgvCliente.DataSource = clientes.ToList();
        listaActual = clientes.ToList();
        if (dgvCliente.Columns["Dni"] != null)
        {
            dgvCliente.Columns["Dni"].Width = 80;
            dgvCliente.Columns["Dni"].Resizable = DataGridViewTriState.False;
        }
        if (dgvCliente.Columns["Nombre"] != null)
            //dgvCliente.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCliente.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dgvCliente.Columns["Nombre"].FillWeight = 30;
        dgvCliente.Columns["Nombre"].MinimumWidth = 100;
        if (dgvCliente.Columns["Apellidos"] != null)
            //dgvCliente.Columns["Apellidos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCliente.Columns["Apellidos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dgvCliente.Columns["Apellidos"].FillWeight = 30;
        dgvCliente.Columns["Apellidos"].MinimumWidth = 120;
        if (dgvCliente.Columns["Email"] != null)
        {
            //dgvCliente.Columns["Email"].Width = 250;
            //dgvCliente.Columns["Email"].Resizable = DataGridViewTriState.False;
            dgvCliente.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCliente.Columns["Email"].FillWeight = 40;
            dgvCliente.Columns["Email"].MinimumWidth = 150;
        }
        if (dgvCliente.Columns["FechaCreacion"] != null)
        {
            dgvCliente.Columns["FechaCreacion"].Width = 120;
            dgvCliente.Columns["FechaCreacion"].Resizable = DataGridViewTriState.False;
        }
        if (dgvCliente.Columns["FechaModificacion"] != null)
        {
            dgvCliente.Columns["FechaModificacion"].Width = 130;
            dgvCliente.Columns["FechaModificacion"].Resizable = DataGridViewTriState.False;
        }
    }
    private void BotonBuscar_Click(object sender, EventArgs e)
    {
        buscarClientes(textBoxCliente.Text);
    }

    private async void BotonMasC_Click(object sender, EventArgs e)
    {
        Cliente nuevoCliente = new Cliente();
        var formNuevo = new ClienteDetailForm(nuevoCliente);

        formNuevo.ClienteCreadoCorrectamente += async cliente =>
        {
            if (!string.IsNullOrEmpty(cliente.Dni))
            {
                buscarClientes(textBoxCliente.Text);

                WindowManager.ShowForm(
                    $"{cliente.Dni}_Actualizar",
                    this,
                    () => new ClienteUpdateForm(cliente));
            }
        };
        WindowManager.ShowForm(
            "Cliente_Nuevo",
            this,
            () => formNuevo);
    }

    private async void BotonMenosC_Click(object sender, EventArgs e)
    {
        DialogResult resultado = MessageBox.Show(
        "¿Está seguro de que desea eliminar este cliente?",
        "Confirmar eliminación",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

        if (resultado == DialogResult.Yes)
        {
            await ClienteApiClient.Eliminar(dgvCliente.CurrentRow.Cells["Dni"].Value.ToString());
        }
        buscarClientes(textBoxCliente.Text);
    }

    private async void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            string dni = dgvCliente.Rows[e.RowIndex].Cells["Dni"].Value.ToString();
            Cliente cliente = await ClienteApiClient.ObtenerPorDni(dni);
            var formActualizado = new ClienteUpdateForm(cliente);

            formActualizado.ClienteActualizadoCorrectamente += async cliente =>
            {
                if (!string.IsNullOrEmpty(cliente.Dni) && !string.IsNullOrEmpty(cliente.Nombre) && !string.IsNullOrEmpty(cliente.Apellidos) && !string.IsNullOrEmpty(cliente.Email))
                {
                    buscarClientes(textBoxCliente.Text);
                }
            };
            WindowManager.ShowForm(
                    $"{dni}_Actualizar",
                    this,
                    () => formActualizado);
            
        }
    }
    private async Task SeleccionarCliente(string dni)
    {
        for (int i = 0; i < dgvCliente.Rows.Count; i++)
        {
            if (dgvCliente.Rows[i].Cells["Dni"].Value?.ToString() == dni)
            {
                dgvCliente.ClearSelection();
                dgvCliente.Rows[i].Selected = true;
                dgvCliente.CurrentCell = dgvCliente.Rows[i].Cells[0];
                dgvCliente.FirstDisplayedScrollingRowIndex = i;
                break;
            }
        }
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
    private void BotonHelpC_Click(object sender, EventArgs e)
    {
        MessageBox.Show("En esta sección puedes gestionar los clientes. Usa el botón '+' para agregar un nuevo cliente, el botón '-' para eliminar el cliente seleccionado, y haz doble clic en un cliente para editar su información.", "Ayuda - Gestión de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void Filtros_Click(object sender, EventArgs e)
    {
        panelFiltros.Visible = !panelFiltros.Visible;
        if (panelFiltros.Visible)
        {
            Filtros.Text = "Cerrar Filtros ▼";
        }
        else
        {
            Filtros.Text = " Abrir Filtros ▶";
        }
    }
}
