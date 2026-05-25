namespace Articulos_Frontend.Forms.Seguridad
{
    partial class UsuarioDetailForm
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
            labelDetallesUsuario = new Label();
            labelNombre = new Label();
            labelCorreo = new Label();
            labelContrasena = new Label();
            textBoxNombre = new TextBox();
            textBoxCorreo = new TextBox();
            textBoxContrasena = new TextBox();
            dataGridViewRoles = new DataGridView();
            buttonConfirm = new Button();
            buttonCC = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoles).BeginInit();
            SuspendLayout();
            // 
            // labelDetallesUsuario
            // 
            labelDetallesUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelDetallesUsuario.Location = new Point(263, 9);
            labelDetallesUsuario.Name = "labelDetallesUsuario";
            labelDetallesUsuario.Size = new Size(290, 36);
            labelDetallesUsuario.TabIndex = 0;
            labelDetallesUsuario.Tag = "title";
            labelDetallesUsuario.Text = "Detalles de usuario";
            labelDetallesUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelNombre
            // 
            labelNombre.Location = new Point(29, 87);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(91, 23);
            labelNombre.TabIndex = 1;
            labelNombre.Text = "Nombre: ";
            labelNombre.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelCorreo
            // 
            labelCorreo.Location = new Point(29, 116);
            labelCorreo.Name = "labelCorreo";
            labelCorreo.Size = new Size(91, 23);
            labelCorreo.TabIndex = 2;
            labelCorreo.Text = "Correo:";
            labelCorreo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelContrasena
            // 
            labelContrasena.Location = new Point(29, 142);
            labelContrasena.Name = "labelContrasena";
            labelContrasena.Size = new Size(91, 23);
            labelContrasena.TabIndex = 3;
            labelContrasena.Text = "Contraseña:";
            labelContrasena.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNombre.Location = new Point(123, 84);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(338, 23);
            textBoxNombre.TabIndex = 4;
            // 
            // textBoxCorreo
            // 
            textBoxCorreo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCorreo.Location = new Point(123, 113);
            textBoxCorreo.Name = "textBoxCorreo";
            textBoxCorreo.Size = new Size(338, 23);
            textBoxCorreo.TabIndex = 5;
            // 
            // textBoxContrasena
            // 
            textBoxContrasena.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxContrasena.Location = new Point(123, 142);
            textBoxContrasena.Name = "textBoxContrasena";
            textBoxContrasena.Size = new Size(338, 23);
            textBoxContrasena.TabIndex = 6;
            // 
            // dataGridViewRoles
            // 
            dataGridViewRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRoles.Location = new Point(123, 202);
            dataGridViewRoles.Name = "dataGridViewRoles";
            dataGridViewRoles.Size = new Size(338, 146);
            dataGridViewRoles.TabIndex = 7;
            dataGridViewRoles.CellBeginEdit += dataGridViewRoles_CellBeginEdit;
            // 
            // buttonConfirm
            // 
            buttonConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonConfirm.Location = new Point(658, 347);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(86, 23);
            buttonConfirm.TabIndex = 8;
            buttonConfirm.Text = "Confirmar";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // buttonCC
            // 
            buttonCC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCC.Location = new Point(467, 141);
            buttonCC.MaximumSize = new Size(147, 23);
            buttonCC.MinimumSize = new Size(147, 23);
            buttonCC.Name = "buttonCC";
            buttonCC.Size = new Size(147, 23);
            buttonCC.TabIndex = 9;
            buttonCC.UseVisualStyleBackColor = true;
            buttonCC.Click += buttonCC_Click;
            // 
            // UsuarioDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 382);
            Controls.Add(buttonCC);
            Controls.Add(buttonConfirm);
            Controls.Add(dataGridViewRoles);
            Controls.Add(textBoxContrasena);
            Controls.Add(textBoxCorreo);
            Controls.Add(textBoxNombre);
            Controls.Add(labelContrasena);
            Controls.Add(labelCorreo);
            Controls.Add(labelNombre);
            Controls.Add(labelDetallesUsuario);
            MinimumSize = new Size(816, 421);
            Name = "UsuarioDetailForm";
            Text = "UsuarioDetailForm";
            Load += UsuarioDetailForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDetallesUsuario;
        private Label labelNombre;
        private Label labelCorreo;
        private Label labelContrasena;
        private TextBox textBoxNombre;
        private TextBox textBoxCorreo;
        private TextBox textBoxContrasena;
        private DataGridView dataGridViewRoles;
        private Button buttonConfirm;
        private Button buttonCC;
    }
}