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
            detalleNombre = new Label();
            detallePrecio = new Label();
            detalleCategoria = new Label();
            textBoxNombre = new TextBox();
            textBoxPrecio = new TextBox();
            detallesTitulo = new Label();
            botonConfirm = new Button();
            comboBoxCategoria = new ComboBox();
            SuspendLayout();
            // 
            // detalleNombre
            // 
            detalleNombre.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            detalleNombre.Location = new Point(174, 131);
            detalleNombre.Name = "detalleNombre";
            detalleNombre.Size = new Size(82, 28);
            detalleNombre.TabIndex = 0;
            detalleNombre.Text = "Nombre";
            // 
            // detallePrecio
            // 
            detallePrecio.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            detallePrecio.Location = new Point(186, 170);
            detallePrecio.Name = "detallePrecio";
            detallePrecio.Size = new Size(70, 28);
            detallePrecio.TabIndex = 1;
            detallePrecio.Text = "Precio";
            // 
            // detalleCategoria
            // 
            detalleCategoria.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            detalleCategoria.Location = new Point(156, 209);
            detalleCategoria.Name = "detalleCategoria";
            detalleCategoria.Size = new Size(100, 23);
            detalleCategoria.TabIndex = 2;
            detalleCategoria.Text = "Categoria";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(253, 131);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(131, 23);
            textBoxNombre.TabIndex = 3;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Location = new Point(253, 170);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.Size = new Size(131, 23);
            textBoxPrecio.TabIndex = 4;
            // 
            // detallesTitulo
            // 
            detallesTitulo.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            detallesTitulo.Location = new Point(26, 23);
            detallesTitulo.Name = "detallesTitulo";
            detallesTitulo.Size = new Size(481, 52);
            detallesTitulo.TabIndex = 6;
            detallesTitulo.Text = "Detalles del articulo";
            // 
            // botonConfirm
            // 
            botonConfirm.Font = new Font("Segoe UI", 20F);
            botonConfirm.Location = new Point(443, 144);
            botonConfirm.Name = "botonConfirm";
            botonConfirm.Size = new Size(64, 61);
            botonConfirm.TabIndex = 7;
            botonConfirm.Text = "Ok";
            botonConfirm.UseVisualStyleBackColor = true;
            botonConfirm.Click += botonConfirm_Click;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoria.Location = new Point(253, 209);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(131, 23);
            comboBoxCategoria.TabIndex = 0;
            // 
            // ArticuloDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Yellow_Emoji_Face_meme_4;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(583, 343);
            Controls.Add(comboBoxCategoria);
            Controls.Add(botonConfirm);
            Controls.Add(detallesTitulo);
            Controls.Add(textBoxPrecio);
            Controls.Add(textBoxNombre);
            Controls.Add(detalleCategoria);
            Controls.Add(detallePrecio);
            Controls.Add(detalleNombre);
            Name = "ArticuloDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ArticuloDetailForm";
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
    }
}