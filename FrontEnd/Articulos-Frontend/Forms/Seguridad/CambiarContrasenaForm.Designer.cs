namespace Articulos_Frontend.Forms.Seguridad
{
    partial class CambiarContrasenaForm
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
            labelTitulo = new Label();
            labelCorreo = new Label();
            labelContrasena = new Label();
            labelConfirmarContrasena = new Label();
            textBoxCorreo = new TextBox();
            textBoxContrasena = new TextBox();
            textBoxConfirmarContrasena = new TextBox();
            buttonConfirm = new Button();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.Location = new Point(23, 22);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(179, 23);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Cambio de contraseña";
            // 
            // labelCorreo
            // 
            labelCorreo.Location = new Point(117, 122);
            labelCorreo.Name = "labelCorreo";
            labelCorreo.Size = new Size(51, 23);
            labelCorreo.TabIndex = 1;
            labelCorreo.Text = "Correo:";
            // 
            // labelContrasena
            // 
            labelContrasena.Location = new Point(91, 169);
            labelContrasena.Name = "labelContrasena";
            labelContrasena.Size = new Size(77, 23);
            labelContrasena.TabIndex = 2;
            labelContrasena.Text = "Contraseña:";
            // 
            // labelConfirmarContrasena
            // 
            labelConfirmarContrasena.Location = new Point(37, 216);
            labelConfirmarContrasena.Name = "labelConfirmarContrasena";
            labelConfirmarContrasena.Size = new Size(131, 23);
            labelConfirmarContrasena.TabIndex = 3;
            labelConfirmarContrasena.Text = "Confirmar Contraseña:";
            // 
            // textBoxCorreo
            // 
            textBoxCorreo.Location = new Point(174, 119);
            textBoxCorreo.Name = "textBoxCorreo";
            textBoxCorreo.Size = new Size(200, 23);
            textBoxCorreo.TabIndex = 4;
            // 
            // textBoxContrasena
            // 
            textBoxContrasena.Location = new Point(174, 166);
            textBoxContrasena.Name = "textBoxContrasena";
            textBoxContrasena.PasswordChar = '*';
            textBoxContrasena.Size = new Size(200, 23);
            textBoxContrasena.TabIndex = 5;
            textBoxContrasena.UseSystemPasswordChar = true;
            // 
            // textBoxConfirmarContrasena
            // 
            textBoxConfirmarContrasena.Location = new Point(174, 213);
            textBoxConfirmarContrasena.MaximumSize = new Size(200, 23);
            textBoxConfirmarContrasena.MinimumSize = new Size(200, 23);
            textBoxConfirmarContrasena.Name = "textBoxConfirmarContrasena";
            textBoxConfirmarContrasena.PasswordChar = '*';
            textBoxConfirmarContrasena.Size = new Size(200, 23);
            textBoxConfirmarContrasena.TabIndex = 6;
            textBoxConfirmarContrasena.UseSystemPasswordChar = true;
            // 
            // buttonConfirm
            // 
            buttonConfirm.Location = new Point(187, 261);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(175, 47);
            buttonConfirm.TabIndex = 7;
            buttonConfirm.Text = "Cambiar contraseña";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // CambiarContrasenaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 450);
            Controls.Add(buttonConfirm);
            Controls.Add(textBoxConfirmarContrasena);
            Controls.Add(textBoxContrasena);
            Controls.Add(textBoxCorreo);
            Controls.Add(labelConfirmarContrasena);
            Controls.Add(labelContrasena);
            Controls.Add(labelCorreo);
            Controls.Add(labelTitulo);
            Name = "CambiarContrasenaForm";
            Text = "CambiarContrasenaForm";
            Load += CambiarContrasenaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitulo;
        private Label labelCorreo;
        private Label labelContrasena;
        private Label labelConfirmarContrasena;
        private TextBox textBoxCorreo;
        private TextBox textBoxContrasena;
        private TextBox textBoxConfirmarContrasena;
        private Button buttonConfirm;
    }
}