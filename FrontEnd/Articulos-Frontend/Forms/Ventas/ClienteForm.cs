
using Articulos_Frontend.Client;
using Articulos_Frontend.LogConfig;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Articulos_Frontend;

public partial class ClienteForm : Form
{
    private ClienteApiClient ClienteApiClient;
    private ErrorProvider errorProvider;
    private List<Cliente> listaActual;
    private StringValuesSP stringValuesSP = new StringValuesSP();
    private bool admin = true;
    public string DniSeleccionado;
    public string ModoInvocacion;
    /*private System.Windows.Forms.Timer animTimer;
    private bool animAbriendo;
    private int panelObjetivo = 222;*/
    public ClienteForm()
    {
        InitializeComponent();
        /*animTimer = new System.Windows.Forms.Timer();
        animTimer.Interval = 1;
        animTimer.Tick += AnimarPanel;*/
        string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
        ClienteApiClient = new ClienteApiClient();
        StyleManager.StyleForm(this);
        this.ActiveControl = textBoxCliente;
        Log.Info("Formulario de clientes iniciado.");
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
        Filtros = new Button();
        panelFiltros = new Panel();
        FiltroFecha = new GroupBox();
        labelFechaMax = new Label();
        labelFechaMin = new Label();
        FechaHasta = new DateTimePicker();
        FechaDesde = new DateTimePicker();
        panelMain = new Panel();
        panelDGV = new Panel();
        panel1 = new Panel();
        BuscarNombre = new GroupBox();
        ((ISupportInitialize)dgvCliente).BeginInit();
        panelFiltros.SuspendLayout();
        FiltroFecha.SuspendLayout();
        panelMain.SuspendLayout();
        panelDGV.SuspendLayout();
        panel1.SuspendLayout();
        BuscarNombre.SuspendLayout();
        SuspendLayout();
        // 
        // BotonMasC
        // 
        BotonMasC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        BotonMasC.BackColor = Color.FromArgb(225, 6, 0);
        BotonMasC.ForeColor = Color.White;
        BotonMasC.Location = new Point(524, 71);
        BotonMasC.Margin = new Padding(0);
        BotonMasC.Name = "BotonMasC";
        BotonMasC.Size = new Size(60, 45);
        BotonMasC.TabIndex = 3;
        BotonMasC.Tag = "modButton";
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
        BotonMenosC.ForeColor = Color.White;
        BotonMenosC.Location = new Point(587, 71);
        BotonMenosC.Name = "BotonMenosC";
        BotonMenosC.Padding = new Padding(0, 0, 0, 4);
        BotonMenosC.Size = new Size(60, 45);
        BotonMenosC.TabIndex = 4;
        BotonMenosC.Tag = "modButton";
        BotonMenosC.Text = " -";
        BotonMenosC.UseVisualStyleBackColor = false;
        BotonMenosC.Click += BotonMenosC_Click;
        BotonMenosC.MouseEnter += Boton_MouseEnter;
        BotonMenosC.MouseLeave += Boton_MouseLeave;
        // 
        // labelNombreCliente
        // 
        labelNombreCliente.Anchor = AnchorStyles.None;
        labelNombreCliente.BackColor = Color.Transparent;
        labelNombreCliente.ForeColor = Color.FromArgb(242, 242, 242);
        labelNombreCliente.Location = new Point(16, 19);
        labelNombreCliente.Name = "labelNombreCliente";
        labelNombreCliente.Size = new Size(63, 15);
        labelNombreCliente.TabIndex = 2;
        labelNombreCliente.Tag = "normalText";
        labelNombreCliente.Text = "Nombre: ";
        // 
        // BotonBuscar
        // 
        BotonBuscar.Anchor = AnchorStyles.None;
        BotonBuscar.BackColor = Color.FromArgb(225, 6, 0);
        BotonBuscar.ForeColor = Color.White;
        BotonBuscar.Location = new Point(85, 63);
        BotonBuscar.MaximumSize = new Size(200, 45);
        BotonBuscar.Name = "BotonBuscar";
        BotonBuscar.Size = new Size(200, 45);
        BotonBuscar.TabIndex = 1;
        BotonBuscar.Text = "Buscar";
        BotonBuscar.UseVisualStyleBackColor = false;
        BotonBuscar.Click += BotonBuscar_Click;
        BotonBuscar.MouseEnter += Boton_MouseEnter;
        BotonBuscar.MouseLeave += Boton_MouseLeave;
        // 
        // textBoxCliente
        // 
        textBoxCliente.Anchor = AnchorStyles.None;
        textBoxCliente.BackColor = Color.FromArgb(42, 42, 42);
        textBoxCliente.BorderStyle = BorderStyle.None;
        textBoxCliente.ForeColor = Color.FromArgb(242, 242, 242);
        textBoxCliente.Location = new Point(85, 18);
        textBoxCliente.MaxLength = 60;
        textBoxCliente.Name = "textBoxCliente";
        textBoxCliente.PlaceholderText = "Busque aquí por nombre";
        textBoxCliente.Size = new Size(200, 16);
        textBoxCliente.TabIndex = 0;
        textBoxCliente.KeyDown += textBoxNombreCliente_EnterClick;
        // 
        // dgvCliente
        // 
        dgvCliente.BackgroundColor = Color.FromArgb(42, 42, 42);
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(60, 60, 60);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(242, 242, 242);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(60, 60, 60);
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvCliente.ColumnHeadersHeight = 40;
        dgvCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgvCliente.Dock = DockStyle.Fill;
        dgvCliente.EditMode = DataGridViewEditMode.EditOnEnter;
        dgvCliente.EnableHeadersVisualStyles = false;
        dgvCliente.GridColor = Color.FromArgb(42, 42, 42);
        dgvCliente.Location = new Point(0, 0);
        dgvCliente.MultiSelect = false;
        dgvCliente.Name = "dgvCliente";
        dgvCliente.ReadOnly = true;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 60, 60);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(242, 242, 242);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(204, 42, 36);
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
        dgvCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
        dgvCliente.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(42, 42, 42);
        dgvCliente.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(242, 242, 242);
        dgvCliente.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 42, 36);
        dgvCliente.SelectionMode = DataGridViewSelectionMode.CellSelect;
        dgvCliente.Size = new Size(648, 267);
        dgvCliente.TabIndex = 5;
        dgvCliente.CellDoubleClick += dgvCliente_CellDoubleClick;
        // 
        // Filtros
        // 
        Filtros.BackColor = Color.FromArgb(225, 6, 0);
        Filtros.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        Filtros.ForeColor = Color.White;
        Filtros.Location = new Point(0, 71);
        Filtros.Name = "Filtros";
        Filtros.Size = new Size(150, 45);
        Filtros.TabIndex = 2;
        Filtros.Text = "▼  Abrir Filtros";
        Filtros.UseVisualStyleBackColor = false;
        Filtros.Click += Filtros_Click;
        // 
        // panelFiltros
        // 
        panelFiltros.AutoScroll = true;
        panelFiltros.BackColor = Color.FromArgb(58, 58, 58);
        panelFiltros.Controls.Add(FiltroFecha);
        panelFiltros.Dock = DockStyle.Left;
        panelFiltros.Location = new Point(0, 0);
        panelFiltros.Name = "panelFiltros";
        panelFiltros.Size = new Size(222, 392);
        panelFiltros.TabIndex = 10;
        panelFiltros.Visible = false;
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
        // 
        // panelMain
        // 
        panelMain.Controls.Add(panelDGV);
        panelMain.Controls.Add(panel1);
        panelMain.Dock = DockStyle.Fill;
        panelMain.Location = new Point(222, 0);
        panelMain.Name = "panelMain";
        panelMain.Size = new Size(648, 392);
        panelMain.TabIndex = 8;
        // 
        // panelDGV
        // 
        panelDGV.Controls.Add(dgvCliente);
        panelDGV.Dock = DockStyle.Fill;
        panelDGV.Location = new Point(0, 125);
        panelDGV.Name = "panelDGV";
        panelDGV.Size = new Size(648, 267);
        panelDGV.TabIndex = 9;
        // 
        // panel1
        // 
        panel1.Controls.Add(BuscarNombre);
        panel1.Controls.Add(Filtros);
        panel1.Controls.Add(BotonMenosC);
        panel1.Controls.Add(BotonMasC);
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(648, 125);
        panel1.TabIndex = 10;
        // 
        // BuscarNombre
        // 
        BuscarNombre.Controls.Add(labelNombreCliente);
        BuscarNombre.Controls.Add(BotonBuscar);
        BuscarNombre.Controls.Add(textBoxCliente);
        BuscarNombre.Location = new Point(156, 8);
        BuscarNombre.Name = "BuscarNombre";
        BuscarNombre.Size = new Size(350, 108);
        BuscarNombre.TabIndex = 9;
        BuscarNombre.TabStop = false;
        BuscarNombre.Text = "Búsqueda por Nombre";
        // 
        // ClienteForm
        // 
        BackColor = Color.FromArgb(26, 26, 26);
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(870, 392);
        Controls.Add(panelMain);
        Controls.Add(panelFiltros);
        ForeColor = SystemColors.ControlLight;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MinimumSize = new Size(848, 431);
        Name = "ClienteForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = stringValuesSP.listaClientes;
        Load += ClienteForm_Load;
        ((ISupportInitialize)dgvCliente).EndInit();
        panelFiltros.ResumeLayout(false);
        FiltroFecha.ResumeLayout(false);
        FiltroFecha.PerformLayout();
        panelMain.ResumeLayout(false);
        panelDGV.ResumeLayout(false);
        panel1.ResumeLayout(false);
        BuscarNombre.ResumeLayout(false);
        BuscarNombre.PerformLayout();
        ResumeLayout(false);
    }
    private void ClienteForm_Load(object sender, EventArgs e)
    {
        Log.Info("Cargando clientes en el formulario.");
        buscarClientes(null);
        RegistrarClicks(this);
        if(!AppState.Roles.Contains("ADMIN_CLIENTES"))
        {
            BotonMasC.Enabled = false;
            BotonMenosC.Enabled = false;
            admin = false;
        } else
        {
            admin = true;
        }
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
        Log.Info($"Buscando clientes: '{nombreFiltro}'");
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
        {
            //dgvCliente.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCliente.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCliente.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCliente.Columns["Nombre"].FillWeight = 30;
            dgvCliente.Columns["Nombre"].MinimumWidth = 100;
        }
        if (dgvCliente.Columns["Apellidos"] != null)
        {
            //dgvCliente.Columns["Apellidos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCliente.Columns["Apellidos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCliente.Columns["Apellidos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCliente.Columns["Apellidos"].FillWeight = 30;
            dgvCliente.Columns["Apellidos"].MinimumWidth = 120;
        }
        if (dgvCliente.Columns["Email"] != null)
        {
            //dgvCliente.Columns["Email"].Width = 250;
            //dgvCliente.Columns["Email"].Resizable = DataGridViewTriState.False;
            dgvCliente.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
        Log.Info("Abriendo formulario para crear un nuevo cliente.");
        Cliente nuevoCliente = new Cliente();
        var formNuevo = new ClienteDetailForm(nuevoCliente);

        formNuevo.ClienteCreadoCorrectamente += async cliente =>
        {
            if (!string.IsNullOrEmpty(cliente.Dni))
            {
                buscarClientes(textBoxCliente.Text);

                var actualizarClienteForm = new ClienteDetailForm(cliente);
                WindowManager.ShowForm(
                    $"{cliente.Dni}_Actualizar",
                    this,
                    () => actualizarClienteForm);

                actualizarClienteForm.ClienteCreadoCorrectamente += async updatedCliente =>
                {
                    if (!string.IsNullOrEmpty(updatedCliente.Dni) && !string.IsNullOrEmpty(updatedCliente.Nombre) && !string.IsNullOrEmpty(updatedCliente.Apellidos) && !string.IsNullOrEmpty(updatedCliente.Email))
                    {
                        buscarClientes(textBoxCliente.Text);
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
        Log.Info("Pulsa el botón de eliminar");
        Alerta alerta = new Alerta(Alerta.AlertaTipo.Warning, new Exception("¿Confirma que desea eliminar este cliente?"));
        alerta.ShowDialog();
        if (alerta.resultado)
        {
            Log.Info($"Eliminando cliente con DNI: {dgvCliente.CurrentRow.Cells["Dni"].Value.ToString()}");
            await ClienteApiClient.Eliminar(dgvCliente.CurrentRow.Cells["Dni"].Value.ToString());
        }
        else
        {
            Log.Info("Eliminación cancelada por el usuario.");
        }
        buscarClientes(textBoxCliente.Text);
    }

    private async void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        Log.Info("Doble clic en cliente para acceder a la información.");
        if (e.RowIndex >= 0)
        {
            if (ModoInvocacion == "CrearPedido")
            {
                DniSeleccionado = dgvCliente.Rows[e.RowIndex].Cells["Dni"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            if (!admin)
            {
                MessageBox.Show("No tienes permisos para editar clientes.");
                return;
            }
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
    private void textBoxNombreCliente_EnterClick(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            buscarClientes(textBoxCliente.Text);
        }
    }
    private void BotonHelpC_Click(object sender, EventArgs e)
    {
        MessageBox.Show("En esta sección puedes gestionar los clientes. Usa el botón '+' para agregar un nuevo cliente, el botón '-' para eliminar el cliente seleccionado, y haz doble clic en un cliente para editar su información.", "Ayuda - Gestión de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void Filtros_Click(object sender, EventArgs e)
    {
        /*if (!panelFiltros.Visible)
        {
            animAbriendo = true;
            panelFiltros.Visible = true;
            panelFiltros.Width = 0;
            Filtros.Text = "◀ Cerrar Filtros";
            animTimer.Start();
        }
        else
        {
            animAbriendo = false;
            Filtros.Text = "▼  Abrir Filtros";
            animTimer.Start();
        }

        Filtros.Focus();*/
        panelFiltros.Visible = !panelFiltros.Visible;

        if (panelFiltros.Visible)
        {
            Log.Info("Abriendo panel de filtros.");
            Filtros.Text = "◀ Cerrar Filtros";
        }
        else {
            Log.Info("Cerrando panel de filtros.");
            Filtros.Text = "▼  Abrir Filtros";
        }
    }
    private void RegistrarClicks(Control parent) {
        /*foreach (Control c in parent.Controls)
        {
            if (c == panelFiltros || c == Filtros)
                continue;
            c.Click += CerrarPanelClickFuera;
            if (c.HasChildren)
                RegistrarClicks(c);
        }
        parent.Click += CerrarPanelClickFuera;*/
        foreach (Control c in parent.Controls)
        {
            if (c == panelFiltros || c == Filtros)
                continue;

            c.Click += CerrarPanelClickFuera;

            if (c.HasChildren)
                RegistrarClicks(c);
        }

        parent.Click += CerrarPanelClickFuera;
    }
    private void CerrarPanelClickFuera(object sender, EventArgs e)
    {
        /*if (!panelFiltros.Visible)
            return;

        if (animTimer.Enabled)
            return;

        Point mousePos = this.PointToClient(Cursor.Position);

        if (!panelFiltros.Bounds.Contains(mousePos))
        {
            animAbriendo = false;
            animTimer.Start();
            Filtros.Text = "▼  Abrir Filtros";
        }*/
        if (panelFiltros.Visible)
        {
            Point mousePos = this.PointToClient(Cursor.Position);

            if (!panelFiltros.Bounds.Contains(mousePos))
            {
                panelFiltros.Visible = false;
                Log.Info("Cerrando panel de filtros al hacer clic fuera del panel.");
                Filtros.Text = "▼  Abrir Filtros";
            }
        }
    }
    /*private void AnimarPanel(object sender, EventArgs e)
    {
        if (animAbriendo)
        {
            if (panelFiltros.Width < panelObjetivo)
            {
                panelFiltros.Width += 10;
            }
            else
            {
                panelFiltros.Width = panelObjetivo;
                animTimer.Stop();
            }
        }
        else
        {
            if (panelFiltros.Width > 0)
            {
                panelFiltros.Width -= 10;
            }
            else
            {
                panelFiltros.Width = 0;
                panelFiltros.Visible = false;
                animTimer.Stop();
            }
        }
    }*/
}
