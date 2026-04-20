using Articulos_Frontend.Theme;
using System.ComponentModel;

namespace Articulos_Frontend
{
    partial class PedidoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private TextBox textBoxCliente;
        private Button BotonMasC;
        private Button BotonMenosC;
        private Label labelNombreCliente;
        private Button BotonBuscar;
        private DataGridView dgvPedido;
        private Button Filtros;
        private Panel panelFiltros;
        private GroupBox FiltroFecha;
        private Label labelFechaMax;
        private Label labelFechaMin;
        private DateTimePicker FechaHasta;
        private DateTimePicker FechaDesde;
        private Panel panelMain;
        private Panel panelDGV;
        private Panel panel1;
        private GroupBox BuscarNombre;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(PedidoForm));
            BotonMasC = new Button();
            BotonMenosC = new Button();
            labelNombreCliente = new Label();
            BotonBuscar = new Button();
            textBoxCliente = new TextBox();
            dgvPedido = new DataGridView();
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            ((ISupportInitialize)dgvPedido).BeginInit();
            panelFiltros.SuspendLayout();
            FiltroFecha.SuspendLayout();
            panelMain.SuspendLayout();
            panelDGV.SuspendLayout();
            panel1.SuspendLayout();
            BuscarNombre.SuspendLayout();
            groupBox1.SuspendLayout();
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
            // dgvPedido
            // 
            dgvPedido.BackgroundColor = Color.FromArgb(42, 42, 42);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(242, 242, 242);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPedido.ColumnHeadersHeight = 40;
            dgvPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPedido.Dock = DockStyle.Fill;
            dgvPedido.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvPedido.EnableHeadersVisualStyles = false;
            dgvPedido.GridColor = Color.FromArgb(42, 42, 42);
            dgvPedido.Location = new Point(0, 0);
            dgvPedido.MultiSelect = false;
            dgvPedido.Name = "dgvPedido";
            dgvPedido.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(242, 242, 242);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(204, 42, 36);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPedido.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPedido.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(42, 42, 42);
            dgvPedido.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(242, 242, 242);
            dgvPedido.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 42, 36);
            dgvPedido.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvPedido.Size = new Size(648, 267);
            dgvPedido.TabIndex = 5;
            dgvPedido.CellDoubleClick += dgvCliente_CellDoubleClick;
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
            panelFiltros.Controls.Add(groupBox1);
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
            FiltroFecha.Text = "Filtrar por Fecha de Creación";
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
            panelDGV.Controls.Add(dgvPedido);
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
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(242, 242, 242);
            groupBox1.Location = new Point(11, 99);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 85);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtrar por Fecha de Envío";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 57);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 9;
            label1.Text = "Fecha Máxima";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(10, 27);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 8;
            label2.Text = "Fecha Mínima";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarForeColor = Color.Black;
            dateTimePicker1.CalendarMonthBackground = SystemColors.GrayText;
            dateTimePicker1.CalendarTitleForeColor = Color.Black;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(99, 51);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(97, 23);
            dateTimePicker1.TabIndex = 7;
            dateTimePicker1.Value = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.AllowDrop = true;
            dateTimePicker2.CalendarForeColor = Color.Black;
            dateTimePicker2.CalendarMonthBackground = SystemColors.GrayText;
            dateTimePicker2.CalendarTitleForeColor = Color.Black;
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(99, 22);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(97, 23);
            dateTimePicker2.TabIndex = 6;
            dateTimePicker2.Value = new DateTime(1979, 8, 10, 0, 0, 0, 0);
            // 
            // PedidoForm
            // 
            BackColor = Color.FromArgb(26, 26, 26);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(870, 392);
            Controls.Add(panelMain);
            Controls.Add(panelFiltros);
            ForeColor = SystemColors.ControlLight;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(848, 431);
            Name = "PedidoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += PedidosForm_Load;
            ((ISupportInitialize)dgvPedido).EndInit();
            panelFiltros.ResumeLayout(false);
            FiltroFecha.ResumeLayout(false);
            FiltroFecha.PerformLayout();
            panelMain.ResumeLayout(false);
            panelDGV.ResumeLayout(false);
            panel1.ResumeLayout(false);
            BuscarNombre.ResumeLayout(false);
            BuscarNombre.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
    }

        #endregion
}