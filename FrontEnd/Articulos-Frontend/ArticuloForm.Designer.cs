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
            EtiquetaNombre = new Label();
            TextoNombre = new TextBox();
            BotonAdd = new Button();
            BotonDel = new Button();
            BotonBuscar = new Button();
            dataGridView1 = new DataGridView();
            fechaDesde = new DateTimePicker();
            fechaHasta = new DateTimePicker();
            checkBoxDesde = new CheckBox();
            checkBoxHasta = new CheckBox();
            groupBoxFecha = new GroupBox();
            BotonFiltros = new Button();
            panelFiltros = new Panel();
            groupBox1 = new GroupBox();
            comboBoxCategoria = new ComboBox();
            label2 = new Label();
            groupBoxPrecio = new GroupBox();
            textBoxMaximo = new TextBox();
            textBoxMinimo = new TextBox();
            label1 = new Label();
            labelMin = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBoxFecha.SuspendLayout();
            panelFiltros.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBoxPrecio.SuspendLayout();
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
            BotonAdd.Location = new Point(1378, 26);
            BotonAdd.Name = "BotonAdd";
            BotonAdd.Size = new Size(62, 61);
            BotonAdd.TabIndex = 2;
            BotonAdd.Text = "+";
            BotonAdd.UseVisualStyleBackColor = true;
            BotonAdd.Click += botonAdd_Click;
            // 
            // BotonDel
            // 
            BotonDel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BotonDel.Font = new Font("Segoe UI", 24.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotonDel.Location = new Point(1378, 106);
            BotonDel.Name = "BotonDel";
            BotonDel.Size = new Size(62, 61);
            BotonDel.TabIndex = 3;
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
            BotonBuscar.TabIndex = 4;
            BotonBuscar.Text = "Buscar";
            BotonBuscar.UseVisualStyleBackColor = true;
            BotonBuscar.Click += BotonBuscar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 190);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1437, 318);
            dataGridView1.StandardTab = true;
            dataGridView1.TabIndex = 5;
            dataGridView1.VirtualMode = true;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // fechaDesde
            // 
            fechaDesde.Format = DateTimePickerFormat.Short;
            fechaDesde.Location = new Point(124, 43);
            fechaDesde.Name = "fechaDesde";
            fechaDesde.Size = new Size(157, 34);
            fechaDesde.TabIndex = 8;
            // 
            // fechaHasta
            // 
            fechaHasta.Format = DateTimePickerFormat.Short;
            fechaHasta.Location = new Point(122, 90);
            fechaHasta.Name = "fechaHasta";
            fechaHasta.Size = new Size(159, 34);
            fechaHasta.TabIndex = 9;
            // 
            // checkBoxDesde
            // 
            checkBoxDesde.AutoSize = true;
            checkBoxDesde.BackColor = Color.Transparent;
            checkBoxDesde.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBoxDesde.Location = new Point(21, 39);
            checkBoxDesde.Name = "checkBoxDesde";
            checkBoxDesde.Size = new Size(95, 31);
            checkBoxDesde.TabIndex = 10;
            checkBoxDesde.Text = "Desde:";
            checkBoxDesde.UseVisualStyleBackColor = false;
            checkBoxDesde.CheckedChanged += checkBoxHasta_CheckedChanged;
            // 
            // checkBoxHasta
            // 
            checkBoxHasta.AutoSize = true;
            checkBoxHasta.BackColor = Color.Transparent;
            checkBoxHasta.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBoxHasta.Location = new Point(21, 86);
            checkBoxHasta.Name = "checkBoxHasta";
            checkBoxHasta.Size = new Size(94, 31);
            checkBoxHasta.TabIndex = 11;
            checkBoxHasta.Text = "Hasta:";
            checkBoxHasta.UseVisualStyleBackColor = false;
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
            // BotonFiltros
            // 
            BotonFiltros.Font = new Font("Segoe UI", 14F);
            BotonFiltros.Location = new Point(360, 49);
            BotonFiltros.Name = "BotonFiltros";
            BotonFiltros.Size = new Size(138, 37);
            BotonFiltros.TabIndex = 13;
            BotonFiltros.Text = "Mostrar filtros";
            BotonFiltros.UseVisualStyleBackColor = true;
            BotonFiltros.Click += BotonFiltros_Click;
            // 
            // panelFiltros
            // 
            panelFiltros.Anchor = AnchorStyles.Top;
            panelFiltros.BackColor = Color.Transparent;
            panelFiltros.Controls.Add(groupBox1);
            panelFiltros.Controls.Add(groupBoxPrecio);
            panelFiltros.Controls.Add(groupBoxFecha);
            panelFiltros.Location = new Point(504, 26);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(851, 158);
            panelFiltros.TabIndex = 14;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(comboBoxCategoria);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(553, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(257, 136);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Categoria";
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoria.Location = new Point(106, 54);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(131, 35);
            comboBoxCategoria.TabIndex = 15;
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 57);
            label2.Name = "label2";
            label2.Size = new Size(94, 27);
            label2.TabIndex = 1;
            label2.Text = "Mostrar:";
            // 
            // groupBoxPrecio
            // 
            groupBoxPrecio.BackColor = Color.Transparent;
            groupBoxPrecio.Controls.Add(textBoxMaximo);
            groupBoxPrecio.Controls.Add(textBoxMinimo);
            groupBoxPrecio.Controls.Add(label1);
            groupBoxPrecio.Controls.Add(labelMin);
            groupBoxPrecio.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxPrecio.Location = new Point(315, 5);
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
            textBoxMaximo.TabIndex = 3;
            textBoxMaximo.Text = "1000000";
            textBoxMaximo.TextAlign = HorizontalAlignment.Right;
            // 
            // textBoxMinimo
            // 
            textBoxMinimo.Location = new Point(110, 37);
            textBoxMinimo.Name = "textBoxMinimo";
            textBoxMinimo.Size = new Size(100, 34);
            textBoxMinimo.TabIndex = 2;
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
            // ArticuloForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1482, 520);
            Controls.Add(EtiquetaNombre);
            Controls.Add(BotonFiltros);
            Controls.Add(dataGridView1);
            Controls.Add(BotonBuscar);
            Controls.Add(BotonDel);
            Controls.Add(BotonAdd);
            Controls.Add(TextoNombre);
            Controls.Add(panelFiltros);
            MinimumSize = new Size(1498, 559);
            Name = "ArticuloForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ArticuloForm";
            Load += ArticuloForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBoxFecha.ResumeLayout(false);
            groupBoxFecha.PerformLayout();
            panelFiltros.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxPrecio.ResumeLayout(false);
            groupBoxPrecio.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label EtiquetaNombre;
        private TextBox TextoNombre;
        private Button BotonAdd;
        private Button BotonDel;
        private Button BotonBuscar;
        private DataGridView dataGridView1;
        private DateTimePicker fechaDesde;
        private DateTimePicker fechaHasta;
        private CheckBox checkBoxDesde;
        private CheckBox checkBoxHasta;
        private GroupBox groupBoxFecha;
        private Button BotonFiltros;
        private Panel panelFiltros;
        private GroupBox groupBoxPrecio;
        private Label labelMin;
        private TextBox textBoxMaximo;
        private TextBox textBoxMinimo;
        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private ComboBox comboBoxCategoria;
    }
}