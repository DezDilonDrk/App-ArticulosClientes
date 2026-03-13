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
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // EtiquetaNombre
            // 
            EtiquetaNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            EtiquetaNombre.BackColor = Color.Transparent;
            EtiquetaNombre.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EtiquetaNombre.Location = new Point(65, 53);
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
            BotonAdd.Location = new Point(696, 26);
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
            BotonDel.Location = new Point(696, 106);
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
            dataGridView1.Size = new Size(755, 248);
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
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(fechaDesde);
            groupBox1.Controls.Add(checkBoxHasta);
            groupBox1.Controls.Add(fechaHasta);
            groupBox1.Controls.Add(checkBoxDesde);
            groupBox1.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(349, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(304, 136);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fecha de creacion";
            // 
            // ArticuloForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.cvx4sgvtzsv81;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(BotonBuscar);
            Controls.Add(BotonDel);
            Controls.Add(BotonAdd);
            Controls.Add(TextoNombre);
            Controls.Add(EtiquetaNombre);
            MinimumSize = new Size(816, 489);
            Name = "ArticuloForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ArticuloForm";
            Load += ArticuloForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private GroupBox groupBox1;
    }
}