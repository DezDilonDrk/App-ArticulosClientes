using Articulos_Frontend.Theme;

namespace Articulos_Frontend
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private StringValuesSP stringValuesSP = new StringValuesSP();

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            menuStripAC = new MenuStrip();
            seguridadToolStripMenuItem = new ToolStripMenuItem();
            almacenToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            mnuVentanas = new ToolStripMenuItem();
            ventanasToolStripMenuItem = new ToolStripMenuItem();
            buttonTerminal = new Button();
            buttonLogout = new Button();
            statusStripMenu = new StatusStrip();
            toolStripStatusLabelUser = new ToolStripStatusLabel();
            toolStripStatusLabelEmail = new ToolStripStatusLabel();
            button1 = new Button();
            menuStripAC.SuspendLayout();
            statusStripMenu.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripAC
            // 
            menuStripAC.ImageScalingSize = new Size(20, 20);
            menuStripAC.Items.AddRange(new ToolStripItem[] { seguridadToolStripMenuItem, almacenToolStripMenuItem, ventasToolStripMenuItem, mnuVentanas });
            menuStripAC.Location = new Point(0, 0);
            menuStripAC.Name = "menuStripAC";
            menuStripAC.Padding = new Padding(4, 2, 0, 2);
            menuStripAC.Size = new Size(914, 24);
            menuStripAC.TabIndex = 0;
            menuStripAC.Tag = "menuStrip";
            menuStripAC.Text = "menuStrip";
            // 
            // seguridadToolStripMenuItem
            // 
            seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
            seguridadToolStripMenuItem.Size = new Size(72, 20);
            seguridadToolStripMenuItem.Text = "Seguridad";
            seguridadToolStripMenuItem.Click += seguridadToolStripMenuItem_Click;
            // 
            // almacenToolStripMenuItem
            // 
            almacenToolStripMenuItem.Name = "almacenToolStripMenuItem";
            almacenToolStripMenuItem.Size = new Size(66, 20);
            almacenToolStripMenuItem.Text = "Almacén";
            almacenToolStripMenuItem.Click += almacenToolStripMenuItem_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(53, 20);
            ventasToolStripMenuItem.Text = "Ventas";
            ventasToolStripMenuItem.Click += ventasToolStripMenuItem_Click;
            // 
            // mnuVentanas
            // 
            mnuVentanas.Name = "mnuVentanas";
            mnuVentanas.Size = new Size(12, 20);
            mnuVentanas.Click += mnuVentanas_Click;
            // 
            // ventanasToolStripMenuItem
            // 
            ventanasToolStripMenuItem.Name = "ventanasToolStripMenuItem";
            ventanasToolStripMenuItem.Size = new Size(32, 19);
            // 
            // buttonTerminal
            // 
            buttonTerminal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonTerminal.Location = new Point(806, 387);
            buttonTerminal.Name = "buttonTerminal";
            buttonTerminal.Size = new Size(75, 23);
            buttonTerminal.TabIndex = 1;
            buttonTerminal.UseVisualStyleBackColor = true;
            buttonTerminal.Click += buttonTerminal_Click;
            // 
            // buttonLogout
            // 
            buttonLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonLogout.Location = new Point(12, 387);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(105, 23);
            buttonLogout.TabIndex = 2;
            buttonLogout.UseVisualStyleBackColor = true;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // statusStripMenu
            // 
            statusStripMenu.AutoSize = false;
            statusStripMenu.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelUser, toolStripStatusLabelEmail });
            statusStripMenu.Location = new Point(0, 469);
            statusStripMenu.Name = "statusStripMenu";
            statusStripMenu.Size = new Size(914, 22);
            statusStripMenu.TabIndex = 4;
            statusStripMenu.Text = "statusStrip1";
            // 
            // toolStripStatusLabelUser
            // 
            toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            toolStripStatusLabelUser.Size = new Size(50, 17);
            toolStripStatusLabelUser.Text = "Usuario:";
            // 
            // toolStripStatusLabelEmail
            // 
            toolStripStatusLabelEmail.Name = "toolStripStatusLabelEmail";
            toolStripStatusLabelEmail.Size = new Size(39, 17);
            toolStripStatusLabelEmail.Text = "Email:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Image = Properties.Resources.IconoAjustesColorClaro;
            button1.Location = new Point(889, 0);
            button1.Name = "button1";
            button1.Size = new Size(24, 24);
            button1.TabIndex = 5;
            button1.UseVisualStyleBackColor = true;
            button1.Paint += Ajustes_Paint;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.MT_GROUP;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(914, 491);
            Controls.Add(button1);
            Controls.Add(statusStripMenu);
            Controls.Add(buttonLogout);
            Controls.Add(buttonTerminal);
            Controls.Add(menuStripAC);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(930, 530);
            Name = "Menu";
            WindowState = FormWindowState.Maximized;
            menuStripAC.ResumeLayout(false);
            menuStripAC.PerformLayout();
            statusStripMenu.ResumeLayout(false);
            statusStripMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripAC;
        private ToolStripMenuItem ventanasToolStripMenuItem;
        private Button buttonTerminal;
        private ToolStripMenuItem mnuVentanas;
        private Button buttonLogout;
        private StatusStrip statusStripMenu;
        private ToolStripStatusLabel toolStripStatusLabelUser;
        private ToolStripStatusLabel toolStripStatusLabelEmail;
        private ToolStripMenuItem seguridadToolStripMenuItem;
        private ToolStripMenuItem almacenToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private Button button1;
    }
}
