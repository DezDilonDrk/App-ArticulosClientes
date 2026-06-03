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
            usuarioToolStripMenuItem = new ToolStripMenuItem();
            aplicacionToolStripMenuItem = new ToolStripMenuItem();
            mnuVentanas = new ToolStripMenuItem();
            ventanasToolStripMenuItem = new ToolStripMenuItem();
            statusStripMenu = new StatusStrip();
            toolStripStatusLabelUser = new ToolStripStatusLabel();
            toolStripStatusLabelEmail = new ToolStripStatusLabel();
            StStatusLServidor = new ToolStripStatusLabel();
            panelRolesUsuario = new Panel();
            panelSuperiorRoles = new Panel();
            labelRolesTitulo = new Label();
            panel2 = new Panel();
            LabelListaRoles = new Label();
            menuStripAC.SuspendLayout();
            statusStripMenu.SuspendLayout();
            panelRolesUsuario.SuspendLayout();
            panelSuperiorRoles.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripAC
            // 
            menuStripAC.ImageScalingSize = new Size(20, 20);
            menuStripAC.Items.AddRange(new ToolStripItem[] { seguridadToolStripMenuItem, almacenToolStripMenuItem, ventasToolStripMenuItem, usuarioToolStripMenuItem, aplicacionToolStripMenuItem, mnuVentanas });
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
            // statusStripMenu
            // 
            statusStripMenu.AutoSize = false;
            statusStripMenu.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelUser, toolStripStatusLabelEmail, StStatusLServidor });
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
            toolStripStatusLabelUser.Click += RolesClick;
            // 
            // toolStripStatusLabelEmail
            // 
            toolStripStatusLabelEmail.Name = "toolStripStatusLabelEmail";
            toolStripStatusLabelEmail.Size = new Size(39, 17);
            toolStripStatusLabelEmail.Text = "Email:";
            toolStripStatusLabelEmail.Click += RolesClick;
            // 
            // StStatusLServidor
            // 
            StStatusLServidor.Name = "StStatusLServidor";
            StStatusLServidor.Size = new Size(56, 17);
            StStatusLServidor.Text = "Servidor: ";
            // 
            // panelRolesUsuario
            // 
            panelRolesUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelRolesUsuario.Controls.Add(panelSuperiorRoles);
            panelRolesUsuario.Controls.Add(panel2);
            panelRolesUsuario.Location = new Point(0, 27);
            panelRolesUsuario.MinimumSize = new Size(200, 439);
            panelRolesUsuario.Name = "panelRolesUsuario";
            panelRolesUsuario.Size = new Size(200, 439);
            panelRolesUsuario.TabIndex = 5;
            panelRolesUsuario.Visible = false;
            // 
            // panelSuperiorRoles
            // 
            panelSuperiorRoles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSuperiorRoles.Controls.Add(labelRolesTitulo);
            panelSuperiorRoles.Location = new Point(0, 0);
            panelSuperiorRoles.Name = "panelSuperiorRoles";
            panelSuperiorRoles.Size = new Size(200, 60);
            panelSuperiorRoles.TabIndex = 0;
            // 
            // labelRolesTitulo
            // 
            labelRolesTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelRolesTitulo.Location = new Point(10, 15);
            labelRolesTitulo.Name = "labelRolesTitulo";
            labelRolesTitulo.RightToLeft = RightToLeft.No;
            labelRolesTitulo.Size = new Size(180, 30);
            labelRolesTitulo.TabIndex = 1;
            labelRolesTitulo.Tag = "title";
            labelRolesTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(LabelListaRoles);
            panel2.Location = new Point(0, 59);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 380);
            panel2.TabIndex = 0;
            // 
            // LabelListaRoles
            // 
            LabelListaRoles.AutoSize = true;
            LabelListaRoles.Location = new Point(12, 13);
            LabelListaRoles.Name = "LabelListaRoles";
            LabelListaRoles.Size = new Size(78, 15);
            LabelListaRoles.TabIndex = 0;
            LabelListaRoles.Text = "Lista de Roles";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.MT_GROUP;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(914, 491);
            Controls.Add(panelRolesUsuario);
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
            panelRolesUsuario.ResumeLayout(false);
            panelSuperiorRoles.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private ToolStripMenuItem usuarioToolStripMenuItem;
        private ToolStripMenuItem aplicacionToolStripMenuItem;
        private ToolStripStatusLabel StStatusLServidor;
        private Panel panelRolesUsuario;
        private Panel panel2;
        private Panel panelSuperiorRoles;
        private Label labelRolesTitulo;
        private Label LabelListaRoles;
    }
}
