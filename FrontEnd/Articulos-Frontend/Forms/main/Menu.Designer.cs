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
            usuarioToolStripMenuItem = new ToolStripMenuItem();
            aplicacionToolStripMenuItem = new ToolStripMenuItem();
            ventanasToolStripMenuItem = new ToolStripMenuItem();
            statusStripMenu = new StatusStrip();
            toolStripStatusLabelUser = new ToolStripStatusLabel();
            toolStripStatusLabelEmail = new ToolStripStatusLabel();
            buttonAjustes = new Button();
            menuStripAC.SuspendLayout();
            statusStripMenu.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripAC
            // 
            menuStripAC.ImageScalingSize = new Size(20, 20);
            menuStripAC.Items.AddRange(new ToolStripItem[] { seguridadToolStripMenuItem, almacenToolStripMenuItem, ventasToolStripMenuItem, mnuVentanas, usuarioToolStripMenuItem, aplicacionToolStripMenuItem });
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
            // usuarioToolStripMenuItem
            // 
            usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            usuarioToolStripMenuItem.Size = new Size(59, 20);
            usuarioToolStripMenuItem.Text = "Usuario";
            usuarioToolStripMenuItem.Click += usuarioToolStripMenuItem_Click;
            // 
            // aplicacionToolStripMenuItem
            // 
            aplicacionToolStripMenuItem.Name = "aplicacionToolStripMenuItem";
            aplicacionToolStripMenuItem.Size = new Size(75, 20);
            aplicacionToolStripMenuItem.Text = "Aplicación";
            aplicacionToolStripMenuItem.Click += aplicacionToolStripMenuItem_Click;
            // 
            // ventanasToolStripMenuItem
            // 
            ventanasToolStripMenuItem.Name = "ventanasToolStripMenuItem";
            ventanasToolStripMenuItem.Size = new Size(32, 19);
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
            // buttonAjustes
            // 
            buttonAjustes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAjustes.Image = Properties.Resources.IconoAjustesColorClaro;
            buttonAjustes.Location = new Point(889, 0);
            buttonAjustes.Name = "buttonAjustes";
            buttonAjustes.Size = new Size(24, 24);
            buttonAjustes.TabIndex = 5;
            buttonAjustes.UseVisualStyleBackColor = true;
            buttonAjustes.Click += buttonAjustes_Click;
            buttonAjustes.Paint += Ajustes_Paint;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.MT_GROUP;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(914, 491);
            Controls.Add(buttonAjustes);
            Controls.Add(statusStripMenu);
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
        private ToolStripMenuItem mnuVentanas;
        private StatusStrip statusStripMenu;
        private ToolStripStatusLabel toolStripStatusLabelUser;
        private ToolStripStatusLabel toolStripStatusLabelEmail;
        private ToolStripMenuItem seguridadToolStripMenuItem;
        private ToolStripMenuItem almacenToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private Button buttonAjustes;
        private ToolStripMenuItem usuarioToolStripMenuItem;
        private ToolStripMenuItem aplicacionToolStripMenuItem;
    }
}
