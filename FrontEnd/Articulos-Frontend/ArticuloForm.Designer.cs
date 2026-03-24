using Articulos_Frontend.Theme;

namespace Articulos_Frontend
{
    partial class ArticuloForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticuloForm));
            EtiquetaNombre = new Label();
            TextoNombre = new TextBox();
            BotonAdd = new Button();
            BotonDel = new Button();
            BotonBuscar = new Button();
            dataGridView1 = new DataGridView();
            BotonFiltros = new Button();
            groupBoxFecha = new GroupBox();
            fechaDesde = new DateTimePicker();
            checkBoxHasta = new CheckBox();
            fechaHasta = new DateTimePicker();
            checkBoxDesde = new CheckBox();
            groupBoxPrecio = new GroupBox();
            textBoxMaximo = new TextBox();
            textBoxMinimo = new TextBox();
            label1 = new Label();
            labelMin = new Label();
            comboBoxCategoria = new ComboBox();
            panelTodo = new Panel();
            panelFiltros = new Panel();
            labelCategoria = new Label();
            CategoriaGroupBox = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBoxFecha.SuspendLayout();
            groupBoxPrecio.SuspendLayout();
            panelTodo.SuspendLayout();
            panelFiltros.SuspendLayout();
            CategoriaGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // EtiquetaNombre
            // 
            EtiquetaNombre.BackColor = Color.Transparent;
            EtiquetaNombre.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EtiquetaNombre.Location = new Point(59, 53);
            EtiquetaNombre.Name = "EtiquetaNombre";
            EtiquetaNombre.Size = new Size(95, 28);
            EtiquetaNombre.TabIndex = 0;
            EtiquetaNombre.Tag = "normalText";
            EtiquetaNombre.Text = "Nombre: ";
            EtiquetaNombre.Click += EtiquetaNombre_Click;
            // 
            // TextoNombre
            // 
            TextoNombre.Font = new Font("Segoe UI", 12F);
            TextoNombre.Location = new Point(153, 53);
            TextoNombre.Name = "TextoNombre";
            TextoNombre.PlaceholderText = "Escribe aqui un articulo";
            TextoNombre.Size = new Size(190, 29);
            TextoNombre.TabIndex = 1;
            // 
            // BotonAdd
            // 
            BotonAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BotonAdd.Font = new Font("Segoe UI", 24.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotonAdd.Location = new Point(564, 26);
            BotonAdd.Name = "BotonAdd";
            BotonAdd.Size = new Size(62, 61);
            BotonAdd.TabIndex = 11;
            BotonAdd.Tag = "modButton";
            BotonAdd.Text = "+";
            BotonAdd.UseVisualStyleBackColor = true;
            BotonAdd.Click += botonAdd_Click;
            // 
            // BotonDel
            // 
            BotonDel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BotonDel.Font = new Font("Segoe UI", 24.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotonDel.Location = new Point(564, 106);
            BotonDel.Name = "BotonDel";
            BotonDel.Size = new Size(62, 61);
            BotonDel.TabIndex = 12;
            BotonDel.Tag = "modButton";
            BotonDel.Text = "-";
            BotonDel.UseVisualStyleBackColor = true;
            BotonDel.Click += botonDel_Click;
            // 
            // BotonBuscar
            // 
            BotonBuscar.Font = new Font("Segoe UI", 14F);
            BotonBuscar.Location = new Point(179, 115);
            BotonBuscar.Name = "BotonBuscar";
            BotonBuscar.Size = new Size(138, 33);
            BotonBuscar.TabIndex = 3;
            BotonBuscar.Text = "Buscar";
            BotonBuscar.UseVisualStyleBackColor = true;
            BotonBuscar.Click += BotonBuscar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 190);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(623, 318);
            dataGridView1.StandardTab = true;
            dataGridView1.TabIndex = 13;
            dataGridView1.VirtualMode = true;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            // 
            // BotonFiltros
            // 
            BotonFiltros.Font = new Font("Segoe UI", 14F);
            BotonFiltros.Location = new Point(360, 49);
            BotonFiltros.Name = "BotonFiltros";
            BotonFiltros.Size = new Size(138, 37);
            BotonFiltros.TabIndex = 2;
            BotonFiltros.Text = "Mostrar filtros";
            BotonFiltros.UseVisualStyleBackColor = true;
            BotonFiltros.Click += BotonFiltros_Click;
            // 
            // groupBoxFecha
            // 
            groupBoxFecha.BackColor = Color.Transparent;
            groupBoxFecha.Controls.Add(fechaDesde);
            groupBoxFecha.Controls.Add(checkBoxHasta);
            groupBoxFecha.Controls.Add(fechaHasta);
            groupBoxFecha.Controls.Add(checkBoxDesde);
            groupBoxFecha.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxFecha.Location = new Point(3, 5);
            groupBoxFecha.Name = "groupBoxFecha";
            groupBoxFecha.Size = new Size(304, 136);
            groupBoxFecha.TabIndex = 12;
            groupBoxFecha.TabStop = false;
            groupBoxFecha.Text = "Fecha de creacion";
            // 
            // fechaDesde
            // 
            fechaDesde.Format = DateTimePickerFormat.Short;
            fechaDesde.Location = new Point(124, 43);
            fechaDesde.Name = "fechaDesde";
            fechaDesde.Size = new Size(157, 34);
            fechaDesde.TabIndex = 5;
            // 
            // checkBoxHasta
            // 
            checkBoxHasta.AutoSize = true;
            checkBoxHasta.BackColor = Color.Transparent;
            checkBoxHasta.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBoxHasta.Location = new Point(21, 86);
            checkBoxHasta.Name = "checkBoxHasta";
            checkBoxHasta.Size = new Size(94, 31);
            checkBoxHasta.TabIndex = 6;
            checkBoxHasta.Text = "Hasta:";
            checkBoxHasta.UseVisualStyleBackColor = false;
            // 
            // fechaHasta
            // 
            fechaHasta.Format = DateTimePickerFormat.Short;
            fechaHasta.Location = new Point(122, 90);
            fechaHasta.Name = "fechaHasta";
            fechaHasta.Size = new Size(159, 34);
            fechaHasta.TabIndex = 7;
            // 
            // checkBoxDesde
            // 
            checkBoxDesde.AutoSize = true;
            checkBoxDesde.BackColor = Color.Transparent;
            checkBoxDesde.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBoxDesde.Location = new Point(21, 39);
            checkBoxDesde.Name = "checkBoxDesde";
            checkBoxDesde.Size = new Size(95, 31);
            checkBoxDesde.TabIndex = 4;
            checkBoxDesde.Text = "Desde:";
            checkBoxDesde.UseVisualStyleBackColor = false;
            checkBoxDesde.CheckedChanged += checkBoxHasta_CheckedChanged;
            // 
            // groupBoxPrecio
            // 
            groupBoxPrecio.BackColor = Color.Transparent;
            groupBoxPrecio.Controls.Add(textBoxMaximo);
            groupBoxPrecio.Controls.Add(textBoxMinimo);
            groupBoxPrecio.Controls.Add(label1);
            groupBoxPrecio.Controls.Add(labelMin);
            groupBoxPrecio.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxPrecio.Location = new Point(12, 154);
            groupBoxPrecio.Name = "groupBoxPrecio";
            groupBoxPrecio.Size = new Size(232, 136);
            groupBoxPrecio.TabIndex = 13;
            groupBoxPrecio.TabStop = false;
            groupBoxPrecio.Text = "Precio";
            // 
            // textBoxMaximo
            // 
            textBoxMaximo.Location = new Point(110, 81);
            textBoxMaximo.Name = "textBoxMaximo";
            textBoxMaximo.Size = new Size(100, 34);
            textBoxMaximo.TabIndex = 9;
            textBoxMaximo.Text = "1000000";
            textBoxMaximo.TextAlign = HorizontalAlignment.Right;
            // 
            // textBoxMinimo
            // 
            textBoxMinimo.Location = new Point(110, 37);
            textBoxMinimo.Name = "textBoxMinimo";
            textBoxMinimo.Size = new Size(100, 34);
            textBoxMinimo.TabIndex = 8;
            textBoxMinimo.Text = "0";
            textBoxMinimo.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 84);
            label1.Name = "label1";
            label1.Size = new Size(89, 27);
            label1.TabIndex = 1;
            label1.Text = "Máximo:";
            // 
            // labelMin
            // 
            labelMin.AutoSize = true;
            labelMin.Location = new Point(22, 39);
            labelMin.Name = "labelMin";
            labelMin.Size = new Size(82, 27);
            labelMin.TabIndex = 0;
            labelMin.Text = "Mínimo:";
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.Location = new Point(116, 35);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(100, 23);
            comboBoxCategoria.TabIndex = 14;
            // 
            // panelTodo
            // 
            panelTodo.Controls.Add(EtiquetaNombre);
            panelTodo.Controls.Add(TextoNombre);
            panelTodo.Controls.Add(BotonAdd);
            panelTodo.Controls.Add(BotonDel);
            panelTodo.Controls.Add(BotonBuscar);
            panelTodo.Controls.Add(dataGridView1);
            panelTodo.Controls.Add(BotonFiltros);
            panelTodo.Dock = DockStyle.Fill;
            panelTodo.Location = new Point(300, 0);
            panelTodo.Name = "panelTodo";
            panelTodo.Size = new Size(668, 520);
            panelTodo.TabIndex = 15;
            // 
            // panelFiltros
            // 
            panelFiltros.Controls.Add(CategoriaGroupBox);
            panelFiltros.Controls.Add(groupBoxPrecio);
            panelFiltros.Controls.Add(groupBoxFecha);
            panelFiltros.Dock = DockStyle.Left;
            panelFiltros.Location = new Point(0, 0);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(300, 520);
            panelFiltros.TabIndex = 14;
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Font = new Font("Segoe UI", 14F);
            labelCategoria.Location = new Point(6, 33);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(94, 25);
            labelCategoria.TabIndex = 15;
            labelCategoria.Tag = "normalText";
            labelCategoria.Text = "Categoría";
            // 
            // CategoriaGroupBox
            // 
            CategoriaGroupBox.Controls.Add(comboBoxCategoria);
            CategoriaGroupBox.Controls.Add(labelCategoria);
            CategoriaGroupBox.Location = new Point(12, 316);
            CategoriaGroupBox.Name = "CategoriaGroupBox";
            CategoriaGroupBox.Size = new Size(232, 88);
            CategoriaGroupBox.TabIndex = 16;
            CategoriaGroupBox.TabStop = false;
            CategoriaGroupBox.Text = "Categoría";
            // 
            // ArticuloForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(968, 520);
            Controls.Add(panelTodo);
            Controls.Add(panelFiltros);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(984, 559);
            Name = "ArticuloForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sección Articulo";
            Load += ArticuloForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBoxFecha.ResumeLayout(false);
            groupBoxFecha.PerformLayout();
            groupBoxPrecio.ResumeLayout(false);
            groupBoxPrecio.PerformLayout();
            panelTodo.ResumeLayout(false);
            panelTodo.PerformLayout();
            panelFiltros.ResumeLayout(false);
            CategoriaGroupBox.ResumeLayout(false);
            CategoriaGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label EtiquetaNombre;
        private TextBox TextoNombre;
        private Button BotonAdd;
        private Button BotonDel;
        private Button BotonBuscar;
        private DataGridView dataGridView1;
        private Button BotonFiltros;
        private GroupBox groupBoxFecha;
        private DateTimePicker fechaDesde;
        private CheckBox checkBoxHasta;
        private DateTimePicker fechaHasta;
        private CheckBox checkBoxDesde;
        private GroupBox groupBoxPrecio;
        private TextBox textBoxMaximo;
        private TextBox textBoxMinimo;
        private Label label1;
        private Label labelMin;
        private GroupBox CategoriaGroupBox;
        private ComboBox comboBoxCategoria;
        private Label labelCategoria;
        private Panel panelFiltros;
        private Panel panelTodo;
    }
}