using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;
using System.ComponentModel;

namespace Articulos_Frontend.Forms.main
{
    partial class AjustesForm
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
            panelLateral = new Panel();
            groupBoxAppSettings = new GroupBox();
            groupBoxUserSettings = new GroupBox();
            labelNotificationSettings = new Label();
            labelAccountSettings = new Label();
            pictureBoxLogoDesplegado = new PictureBox();
            panelMain = new Panel();
            panelMainSpace = new Panel();
            panelAccountSettings = new Panel();
            label1 = new Label();
            panelNotificationSettings = new Panel();
            checkCreateObjectEmailNotifications = new CheckBox();
            labelTittleEmailNotifications = new Label();
            panel1 = new Panel();
            labelBuscadorAjustes = new Label();
            textBoxBuscadorAjustes = new TextBox();
            panelLateralPlegado = new Panel();
            pictureBoxLogo = new PictureBox();
            panelLateral.SuspendLayout();
            groupBoxUserSettings.SuspendLayout();
            ((ISupportInitialize)pictureBoxLogoDesplegado).BeginInit();
            panelMain.SuspendLayout();
            panelMainSpace.SuspendLayout();
            panelAccountSettings.SuspendLayout();
            panelNotificationSettings.SuspendLayout();
            panel1.SuspendLayout();
            panelLateralPlegado.SuspendLayout();
            ((ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // panelLateral
            // 
            panelLateral.AutoScroll = true;
            panelLateral.BackColor = Color.FromArgb(58, 58, 58);
            panelLateral.Controls.Add(groupBoxAppSettings);
            panelLateral.Controls.Add(groupBoxUserSettings);
            panelLateral.Controls.Add(pictureBoxLogoDesplegado);
            panelLateral.Dock = DockStyle.Left;
            panelLateral.Location = new Point(70, 0);
            panelLateral.Name = "panelLateral";
            panelLateral.Size = new Size(200, 450);
            panelLateral.TabIndex = 10;
            panelLateral.Visible = false;
            // 
            // groupBoxAppSettings
            // 
            groupBoxAppSettings.Location = new Point(3, 116);
            groupBoxAppSettings.Name = "groupBoxAppSettings";
            groupBoxAppSettings.Size = new Size(180, 249);
            groupBoxAppSettings.TabIndex = 4;
            groupBoxAppSettings.TabStop = false;
            groupBoxAppSettings.Text = "App Settings";
            // 
            // groupBoxUserSettings
            // 
            groupBoxUserSettings.Controls.Add(labelNotificationSettings);
            groupBoxUserSettings.Controls.Add(labelAccountSettings);
            groupBoxUserSettings.Location = new Point(2, 371);
            groupBoxUserSettings.Name = "groupBoxUserSettings";
            groupBoxUserSettings.Size = new Size(180, 100);
            groupBoxUserSettings.TabIndex = 3;
            groupBoxUserSettings.TabStop = false;
            groupBoxUserSettings.Text = "User Settings";
            // 
            // labelNotificationSettings
            // 
            labelNotificationSettings.AutoSize = true;
            labelNotificationSettings.Location = new Point(6, 55);
            labelNotificationSettings.Name = "labelNotificationSettings";
            labelNotificationSettings.Size = new Size(115, 15);
            labelNotificationSettings.TabIndex = 3;
            labelNotificationSettings.Text = "Notification Settings";
            labelNotificationSettings.Click += openOptionAjustes;
            // 
            // labelAccountSettings
            // 
            labelAccountSettings.AutoSize = true;
            labelAccountSettings.Location = new Point(6, 31);
            labelAccountSettings.Name = "labelAccountSettings";
            labelAccountSettings.Size = new Size(97, 15);
            labelAccountSettings.TabIndex = 2;
            labelAccountSettings.Text = "Account Settings";
            labelAccountSettings.Click += openOptionAjustes;
            // 
            // pictureBoxLogoDesplegado
            // 
            pictureBoxLogoDesplegado.Image = Properties.Resources.IconoAjustesMTColorClaro;
            pictureBoxLogoDesplegado.Location = new Point(40, 20);
            pictureBoxLogoDesplegado.MaximumSize = new Size(120, 80);
            pictureBoxLogoDesplegado.MinimumSize = new Size(120, 80);
            pictureBoxLogoDesplegado.Name = "pictureBoxLogoDesplegado";
            pictureBoxLogoDesplegado.Size = new Size(120, 80);
            pictureBoxLogoDesplegado.TabIndex = 1;
            pictureBoxLogoDesplegado.TabStop = false;
            pictureBoxLogoDesplegado.Click += PanelPlegado_Click;
            pictureBoxLogoDesplegado.Paint += Ajustes_Paint;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(panelMainSpace);
            panelMain.Controls.Add(panel1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(832, 450);
            panelMain.TabIndex = 8;
            // 
            // panelMainSpace
            // 
            panelMainSpace.Controls.Add(panelAccountSettings);
            panelMainSpace.Controls.Add(panelNotificationSettings);
            panelMainSpace.Dock = DockStyle.Fill;
            panelMainSpace.Location = new Point(0, 60);
            panelMainSpace.Name = "panelMainSpace";
            panelMainSpace.Size = new Size(832, 390);
            panelMainSpace.TabIndex = 9;
            // 
            // panelAccountSettings
            // 
            panelAccountSettings.Controls.Add(label1);
            panelAccountSettings.Dock = DockStyle.Fill;
            panelAccountSettings.Location = new Point(0, 0);
            panelAccountSettings.Name = "panelAccountSettings";
            panelAccountSettings.Size = new Size(832, 390);
            panelAccountSettings.TabIndex = 10;
            panelAccountSettings.Tag = "fondoGrisPanel";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 350);
            label1.Name = "label1";
            label1.Size = new Size(145, 15);
            label1.TabIndex = 0;
            label1.Text = "Cerrar Sesión en la Cuenta";
            // 
            // panelNotificationSettings
            // 
            panelNotificationSettings.Controls.Add(checkCreateObjectEmailNotifications);
            panelNotificationSettings.Controls.Add(labelTittleEmailNotifications);
            panelNotificationSettings.Dock = DockStyle.Fill;
            panelNotificationSettings.Location = new Point(0, 0);
            panelNotificationSettings.Name = "panelNotificationSettings";
            panelNotificationSettings.Size = new Size(832, 390);
            panelNotificationSettings.TabIndex = 11;
            panelNotificationSettings.Tag = "fondoGrisPanel";
            // 
            // checkCreateObjectEmailNotifications
            // 
            checkCreateObjectEmailNotifications.AutoSize = true;
            checkCreateObjectEmailNotifications.Location = new Point(130, 47);
            checkCreateObjectEmailNotifications.Name = "checkCreateObjectEmailNotifications";
            checkCreateObjectEmailNotifications.Size = new Size(169, 19);
            checkCreateObjectEmailNotifications.TabIndex = 1;
            checkCreateObjectEmailNotifications.Text = "Noticación mediante Email";
            checkCreateObjectEmailNotifications.UseVisualStyleBackColor = true;
            checkCreateObjectEmailNotifications.Click += markCheckNotifications_Click;
            // 
            // labelTittleEmailNotifications
            // 
            labelTittleEmailNotifications.AutoSize = true;
            labelTittleEmailNotifications.Location = new Point(100, 26);
            labelTittleEmailNotifications.Name = "labelTittleEmailNotifications";
            labelTittleEmailNotifications.Size = new Size(349, 15);
            labelTittleEmailNotifications.TabIndex = 0;
            labelTittleEmailNotifications.Text = "Notificaciones sobre los elementos dados de alta en la aplicación";
            // 
            // panel1
            // 
            panel1.Controls.Add(labelBuscadorAjustes);
            panel1.Controls.Add(textBoxBuscadorAjustes);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(832, 60);
            panel1.TabIndex = 10;
            // 
            // labelBuscadorAjustes
            // 
            labelBuscadorAjustes.Anchor = AnchorStyles.None;
            labelBuscadorAjustes.BackColor = Color.Transparent;
            labelBuscadorAjustes.ForeColor = Color.FromArgb(242, 242, 242);
            labelBuscadorAjustes.Location = new Point(158, 25);
            labelBuscadorAjustes.Name = "labelBuscadorAjustes";
            labelBuscadorAjustes.Size = new Size(130, 15);
            labelBuscadorAjustes.TabIndex = 4;
            labelBuscadorAjustes.Tag = "normalText";
            labelBuscadorAjustes.Text = "Buscar en esta sección: ";
            // 
            // textBoxBuscadorAjustes
            // 
            textBoxBuscadorAjustes.Anchor = AnchorStyles.None;
            textBoxBuscadorAjustes.BackColor = Color.FromArgb(42, 42, 42);
            textBoxBuscadorAjustes.BorderStyle = BorderStyle.None;
            textBoxBuscadorAjustes.Enabled = false;
            textBoxBuscadorAjustes.ForeColor = Color.FromArgb(242, 242, 242);
            textBoxBuscadorAjustes.Location = new Point(294, 25);
            textBoxBuscadorAjustes.MaxLength = 60;
            textBoxBuscadorAjustes.Name = "textBoxBuscadorAjustes";
            textBoxBuscadorAjustes.PlaceholderText = "Escriba aquí";
            textBoxBuscadorAjustes.Size = new Size(262, 16);
            textBoxBuscadorAjustes.TabIndex = 3;
            // 
            // panelLateralPlegado
            // 
            panelLateralPlegado.AutoScroll = true;
            panelLateralPlegado.BackColor = Color.FromArgb(58, 58, 58);
            panelLateralPlegado.Controls.Add(pictureBoxLogo);
            panelLateralPlegado.Dock = DockStyle.Left;
            panelLateralPlegado.Location = new Point(0, 0);
            panelLateralPlegado.Name = "panelLateralPlegado";
            panelLateralPlegado.Size = new Size(70, 450);
            panelLateralPlegado.TabIndex = 11;
            panelLateralPlegado.Visible = false;
            panelLateralPlegado.Click += PanelPlegado_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = Properties.Resources.IconoAjustesMTColorClaro;
            pictureBoxLogo.Location = new Point(5, 15);
            pictureBoxLogo.MaximumSize = new Size(60, 40);
            pictureBoxLogo.MinimumSize = new Size(60, 40);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(60, 40);
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            pictureBoxLogo.Click += PanelPlegado_Click;
            pictureBoxLogo.Paint += Ajustes_Paint;
            // 
            // AjustesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(832, 450);
            Controls.Add(panelLateral);
            Controls.Add(panelLateralPlegado);
            Controls.Add(panelMain);
            ForeColor = SystemColors.ControlLight;
            MinimumSize = new Size(848, 431);
            Name = "AjustesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AjustesForm";
            Load += AjustesForm_Load;
            panelLateral.ResumeLayout(false);
            groupBoxUserSettings.ResumeLayout(false);
            groupBoxUserSettings.PerformLayout();
            ((ISupportInitialize)pictureBoxLogoDesplegado).EndInit();
            panelMain.ResumeLayout(false);
            panelMainSpace.ResumeLayout(false);
            panelAccountSettings.ResumeLayout(false);
            panelAccountSettings.PerformLayout();
            panelNotificationSettings.ResumeLayout(false);
            panelNotificationSettings.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelLateralPlegado.ResumeLayout(false);
            ((ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelLateral;
        private Panel panelMain;
        private Panel panelMainSpace;
        private Panel panel1;
        private Label labelBuscadorAjustes;
        private TextBox textBoxBuscadorAjustes;
        private Panel panelLateralPlegado;
        private PictureBox pictureBoxLogo;
        private PictureBox pictureBoxLogoDesplegado;
        private Label labelAccountSettings;
        private GroupBox groupBoxUserSettings;
        private Label labelNotificationSettings;
        private GroupBox groupBoxAppSettings;
        private Panel panelAccountSettings;
        private Panel panelNotificationSettings;
        private Label labelTittleEmailNotifications;
        private CheckBox checkCreateObjectEmailNotifications;
        private Label label1;
    }
}