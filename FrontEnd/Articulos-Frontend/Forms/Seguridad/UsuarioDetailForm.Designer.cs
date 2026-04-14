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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
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
            // textBox1
            // 
            textBox1.Location = new Point(123, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(281, 23);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(123, 113);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(365, 23);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(123, 158);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(338, 23);
            textBox3.TabIndex = 6;
            // 
            // UsuarioDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 307);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(labelContrasena);
            Controls.Add(labelCorreo);
            Controls.Add(labelNombre);
            Controls.Add(labelDetallesUsuario);
            Name = "UsuarioDetailForm";
            Text = "UsuarioDetailForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDetallesUsuario;
        private Label labelNombre;
        private Label labelCorreo;
        private Label labelContrasena;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}