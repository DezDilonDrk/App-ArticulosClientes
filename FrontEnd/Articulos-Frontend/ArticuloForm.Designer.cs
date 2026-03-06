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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // EtiquetaNombre
            // 
            EtiquetaNombre.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EtiquetaNombre.Location = new Point(174, 76);
            EtiquetaNombre.Name = "EtiquetaNombre";
            EtiquetaNombre.Size = new Size(95, 28);
            EtiquetaNombre.TabIndex = 0;
            EtiquetaNombre.Text = "Nombre: ";
            // 
            // TextoNombre
            // 
            TextoNombre.Font = new Font("Segoe UI", 12F);
            TextoNombre.Location = new Point(266, 75);
            TextoNombre.Name = "TextoNombre";
            TextoNombre.PlaceholderText = "Escribe aqui un articulo";
            TextoNombre.Size = new Size(220, 29);
            TextoNombre.TabIndex = 1;
            // 
            // BotonAdd
            // 
            BotonAdd.Font = new Font("Segoe UI", 24.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotonAdd.Location = new Point(648, 28);
            BotonAdd.Name = "BotonAdd";
            BotonAdd.Size = new Size(62, 61);
            BotonAdd.TabIndex = 2;
            BotonAdd.Text = "+";
            BotonAdd.UseVisualStyleBackColor = true;
            BotonAdd.Click += botonAdd_Click;
            // 
            // BotonDel
            // 
            BotonDel.Font = new Font("Segoe UI", 24.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotonDel.Location = new Point(648, 108);
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
            BotonBuscar.Location = new Point(348, 127);
            BotonBuscar.Name = "BotonBuscar";
            BotonBuscar.Size = new Size(138, 33);
            BotonBuscar.TabIndex = 4;
            BotonBuscar.Text = "Buscar";
            BotonBuscar.UseVisualStyleBackColor = true;
            BotonBuscar.Click += BotonBuscar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 190);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(755, 248);
            dataGridView1.TabIndex = 5;
            // 
            // ArticuloForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(BotonBuscar);
            Controls.Add(BotonDel);
            Controls.Add(BotonAdd);
            Controls.Add(TextoNombre);
            Controls.Add(EtiquetaNombre);
            Name = "ArticuloForm";
            Text = "ArticuloForm";
            Load += ArticuloForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
    }
}