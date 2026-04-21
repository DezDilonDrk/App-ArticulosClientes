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
            labelDetallesUsuario.Location = new Point(64, 28);
            labelDetallesUsuario.Name = "labelDetallesUsuario";
            labelDetallesUsuario.Size = new Size(142, 27);
            labelDetallesUsuario.TabIndex = 0;
            labelDetallesUsuario.Text = "Detalles de usuario";
            // 
            // labelNombre
            // 
            labelNombre.Location = new Point(55, 70);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(73, 23);
            labelNombre.TabIndex = 1;
            labelNombre.Text = "Nombre: ";
            // 
            // labelCorreo
            // 
            labelCorreo.Location = new Point(64, 113);
            labelCorreo.Name = "labelCorreo";
            labelCorreo.Size = new Size(76, 23);
            labelCorreo.TabIndex = 2;
            labelCorreo.Text = "Correo:";
            // 
            // labelContrasena
            // 
            labelContrasena.Location = new Point(37, 158);
            labelContrasena.Name = "labelContrasena";
            labelContrasena.Size = new Size(91, 23);
            labelContrasena.TabIndex = 3;
            labelContrasena.Text = "Contraseña:";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(123, 70);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(281, 23);
            textBoxNombre.TabIndex = 4;
            // 
            // textBoxCorreo
            // 
            textBoxCorreo.Location = new Point(123, 113);
            textBoxCorreo.Name = "textBoxCorreo";
            textBoxCorreo.Size = new Size(365, 23);
            textBoxCorreo.TabIndex = 5;
            // 
            // textBoxContrasena
            // 
            textBoxContrasena.Location = new Point(123, 158);
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
            dataGridViewRoles.Size = new Size(281, 146);
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
            buttonCC.Location = new Point(476, 158);
            buttonCC.MaximumSize = new Size(147, 23);
            buttonCC.MinimumSize = new Size(147, 23);
            buttonCC.Name = "buttonCC";
            buttonCC.Size = new Size(147, 23);
            buttonCC.TabIndex = 9;
            buttonCC.Text = "Cambiar contraseña";
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