namespace Articulos_Frontend
{
    partial class LoginForm
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
            pictureBox1 = new PictureBox();
            emailText = new TextBox();
            contrasenaText = new TextBox();
            emailLabel = new Label();
            contrasenaLabel = new Label();
            loginButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.MT_GROUP;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(214, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(379, 149);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // emailText
            // 
            emailText.Location = new Point(348, 207);
            emailText.Name = "emailText";
            emailText.Size = new Size(201, 23);
            emailText.TabIndex = 1;
            // 
            // contrasenaText
            // 
            contrasenaText.Location = new Point(348, 256);
            contrasenaText.Name = "contrasenaText";
            contrasenaText.Size = new Size(201, 23);
            contrasenaText.TabIndex = 2;
            // 
            // emailLabel
            // 
            emailLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailLabel.Location = new Point(282, 207);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(60, 23);
            emailLabel.TabIndex = 3;
            emailLabel.Text = "Email:";
            // 
            // contrasenaLabel
            // 
            contrasenaLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contrasenaLabel.Location = new Point(239, 256);
            contrasenaLabel.Name = "contrasenaLabel";
            contrasenaLabel.Size = new Size(103, 23);
            contrasenaLabel.TabIndex = 4;
            contrasenaLabel.Text = "Contraseña:";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(316, 308);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(172, 40);
            loginButton.TabIndex = 5;
            loginButton.Text = "Iniciar sesión";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginButton);
            Controls.Add(contrasenaLabel);
            Controls.Add(emailLabel);
            Controls.Add(contrasenaText);
            Controls.Add(emailText);
            Controls.Add(pictureBox1);
            Name = "LoginForm";
            Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox emailText;
        private TextBox contrasenaText;
        private Label emailLabel;
        private Label contrasenaLabel;
        private Button loginButton;
    }
}