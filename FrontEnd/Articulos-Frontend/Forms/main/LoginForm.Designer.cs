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
            buttonVerContrasena = new Button();
            comboBoxServer = new ComboBox();
            servidorLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackgroundImage = Properties.Resources.MT_GROUP;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(214, 26);
            pictureBox1.MaximumSize = new Size(379, 149);
            pictureBox1.MinimumSize = new Size(379, 149);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(379, 149);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // emailText
            // 
            emailText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            emailText.Location = new Point(319, 229);
            emailText.MaximumSize = new Size(201, 23);
            emailText.MinimumSize = new Size(201, 23);
            emailText.Name = "emailText";
            emailText.Size = new Size(201, 23);
            emailText.TabIndex = 1;
            emailText.KeyPress += emailText_keyPress;
            // 
            // contrasenaText
            // 
            contrasenaText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            contrasenaText.Location = new Point(319, 258);
            contrasenaText.MaximumSize = new Size(201, 23);
            contrasenaText.MinimumSize = new Size(201, 23);
            contrasenaText.Name = "contrasenaText";
            contrasenaText.Size = new Size(201, 23);
            contrasenaText.TabIndex = 2;
            contrasenaText.UseSystemPasswordChar = true;
            contrasenaText.KeyPress += contrasenaText_keyPress;
            // 
            // emailLabel
            // 
            emailLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            emailLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailLabel.Location = new Point(253, 226);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(60, 23);
            emailLabel.TabIndex = 5;
            emailLabel.Text = "Email:";
            emailLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // contrasenaLabel
            // 
            contrasenaLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            contrasenaLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contrasenaLabel.Location = new Point(210, 255);
            contrasenaLabel.Name = "contrasenaLabel";
            contrasenaLabel.Size = new Size(103, 23);
            contrasenaLabel.TabIndex = 4;
            contrasenaLabel.Text = "Contraseña:";
            contrasenaLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loginButton.Location = new Point(319, 324);
            loginButton.MaximumSize = new Size(201, 40);
            loginButton.MinimumSize = new Size(201, 40);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(201, 40);
            loginButton.TabIndex = 3;
            loginButton.Text = "Iniciar sesión";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // buttonVerContrasena
            // 
            buttonVerContrasena.Anchor = AnchorStyles.Bottom;
            buttonVerContrasena.Location = new Point(526, 257);
            buttonVerContrasena.MaximumSize = new Size(38, 23);
            buttonVerContrasena.MinimumSize = new Size(38, 23);
            buttonVerContrasena.Name = "buttonVerContrasena";
            buttonVerContrasena.Size = new Size(38, 23);
            buttonVerContrasena.TabIndex = 6;
            buttonVerContrasena.Text = "👁";
            buttonVerContrasena.UseVisualStyleBackColor = true;
            buttonVerContrasena.MouseDown += buttonVerContrasena_MouseDown;
            buttonVerContrasena.MouseUp += buttonVerContrasena_MouseUp;
            // 
            // comboBoxServer
            // 
            comboBoxServer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxServer.FormattingEnabled = true;
            comboBoxServer.Location = new Point(319, 288);
            comboBoxServer.MaximumSize = new Size(201, 0);
            comboBoxServer.MinimumSize = new Size(201, 0);
            comboBoxServer.Name = "comboBoxServer";
            comboBoxServer.Size = new Size(201, 23);
            comboBoxServer.TabIndex = 7;
            // 
            // servidorLabel
            // 
            servidorLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            servidorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            servidorLabel.Location = new Point(210, 285);
            servidorLabel.Name = "servidorLabel";
            servidorLabel.Size = new Size(103, 23);
            servidorLabel.TabIndex = 8;
            servidorLabel.Text = "Servidor:";
            servidorLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(servidorLabel);
            Controls.Add(comboBoxServer);
            Controls.Add(buttonVerContrasena);
            Controls.Add(loginButton);
            Controls.Add(contrasenaLabel);
            Controls.Add(emailLabel);
            Controls.Add(contrasenaText);
            Controls.Add(emailText);
            Controls.Add(pictureBox1);
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
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
        private Button buttonVerContrasena;
        private ComboBox comboBoxServer;
        private Label servidorLabel;
    }
}