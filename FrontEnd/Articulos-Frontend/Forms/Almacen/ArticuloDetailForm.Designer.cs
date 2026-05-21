namespace Articulos_Frontend
{
    partial class ArticuloDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticuloDetailForm));
            detalleNombre = new Label();
            detallePrecio = new Label();
            detalleCategoria = new Label();
            textBoxNombre = new TextBox();
            textBoxPrecio = new TextBox();
            detallesTitulo = new Label();
            botonConfirm = new Button();
            comboBoxCategoria = new ComboBox();
            labelDiseno = new Label();
            comboBoxDiseno = new ComboBox();
            SuspendLayout();
            // 
            // detalleNombre
            // 
            detalleNombre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            detalleNombre.BackColor = Color.Transparent;
            detalleNombre.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            detalleNombre.Location = new Point(68, 122);
            detalleNombre.Name = "detalleNombre";
            detalleNombre.Size = new Size(82, 28);
            detalleNombre.TabIndex = 0;
            detalleNombre.Tag = "normalText";
            detalleNombre.Text = "Nombre";
            // 
            // detallePrecio
            // 
            detallePrecio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            detallePrecio.BackColor = Color.Transparent;
            detallePrecio.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            detallePrecio.Location = new Point(80, 161);
            detallePrecio.Name = "detallePrecio";
            detallePrecio.Size = new Size(70, 28);
            detallePrecio.TabIndex = 1;
            detallePrecio.Tag = "normalText";
            detallePrecio.Text = "Precio";
            // 
            // detalleCategoria
            // 
            detalleCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            detalleCategoria.BackColor = Color.Transparent;
            detalleCategoria.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            detalleCategoria.Location = new Point(50, 200);
            detalleCategoria.Name = "detalleCategoria";
            detalleCategoria.Size = new Size(100, 23);
            detalleCategoria.TabIndex = 2;
            detalleCategoria.Tag = "normalText";
            detalleCategoria.Text = "Categoria";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxNombre.Location = new Point(147, 122);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(131, 23);
            textBoxNombre.TabIndex = 3;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxPrecio.Location = new Point(147, 161);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.Size = new Size(131, 23);
            textBoxPrecio.TabIndex = 4;
            // 
            // detallesTitulo
            // 
            detallesTitulo.BackColor = Color.Transparent;
            detallesTitulo.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            detallesTitulo.Location = new Point(12, 38);
            detallesTitulo.Name = "detallesTitulo";
            detallesTitulo.Size = new Size(559, 52);
            detallesTitulo.TabIndex = 6;
            detallesTitulo.Tag = "title";
            detallesTitulo.Text = "Detalles del articulo";
            detallesTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // botonConfirm
            // 
            botonConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            botonConfirm.Font = new Font("Segoe UI", 20F);
            botonConfirm.Location = new Point(371, 137);
            botonConfirm.Name = "botonConfirm";
            botonConfirm.Size = new Size(64, 61);
            botonConfirm.TabIndex = 7;
            botonConfirm.Text = "Ok";
            botonConfirm.UseVisualStyleBackColor = true;
            botonConfirm.Click += botonConfirm_Click;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoria.Location = new Point(147, 200);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(131, 23);
            comboBoxCategoria.TabIndex = 0;
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_OnChange;
            // 
            // labelDiseno
            // 
            labelDiseno.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            labelDiseno.BackColor = Color.Transparent;
            labelDiseno.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDiseno.Location = new Point(71, 236);
            labelDiseno.Name = "labelDiseno";
            labelDiseno.Size = new Size(70, 28);
            labelDiseno.TabIndex = 8;
            labelDiseno.Tag = "normalText";
            labelDiseno.Text = "Diseño";
            // 
            // comboBoxDiseno
            // 
            comboBoxDiseno.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxDiseno.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDiseno.Location = new Point(147, 239);
            comboBoxDiseno.Name = "comboBoxDiseno";
            comboBoxDiseno.Size = new Size(131, 23);
            comboBoxDiseno.TabIndex = 9;
            // 
            // ArticuloDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            Load += ArticuloDetailForm_Load;
            ClientSize = new Size(583, 343);
            Controls.Add(comboBoxDiseno);
            Controls.Add(labelDiseno);
            Controls.Add(comboBoxCategoria);
            Controls.Add(botonConfirm);
            Controls.Add(detallesTitulo);
            Controls.Add(textBoxPrecio);
            Controls.Add(textBoxNombre);
            Controls.Add(detalleCategoria);
            Controls.Add(detallePrecio);
            Controls.Add(detalleNombre);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(599, 382);
            MinimumSize = new Size(599, 382);
            Name = "ArticuloDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label detalleNombre;
        private Label detallePrecio;
        private Label detalleCategoria;
        private TextBox textBoxNombre;
        private TextBox textBoxPrecio;
        private Label detallesTitulo;
        private Button botonConfirm;
        private ComboBox comboBoxCategoria;
        private Label labelDiseno;
        private ComboBox comboBoxDiseno;
    }
}