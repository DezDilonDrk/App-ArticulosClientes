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
            artículosToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            mnuVentanas = new ToolStripMenuItem();
            ventanasToolStripMenuItem = new ToolStripMenuItem();
            buttonTerminal = new Button();
            buttonLogout = new Button();
            menuStripAC.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripAC
            // 
            menuStripAC.ImageScalingSize = new Size(20, 20);
            menuStripAC.Items.AddRange(new ToolStripItem[] { artículosToolStripMenuItem, clientesToolStripMenuItem, productosToolStripMenuItem, mnuVentanas });
            menuStripAC.Location = new Point(0, 0);
            menuStripAC.Name = "menuStripAC";
            menuStripAC.Padding = new Padding(4, 2, 0, 2);
            menuStripAC.Size = new Size(914, 24);
            menuStripAC.TabIndex = 0;
            menuStripAC.Tag = "menuStrip";
            menuStripAC.Text = "menuStrip";
            // 
            // artículosToolStripMenuItem
            // 
            artículosToolStripMenuItem.Name = "artículosToolStripMenuItem";
            artículosToolStripMenuItem.Size = new Size(66, 20);
            artículosToolStripMenuItem.Text = stringValuesSP.articulos;
            artículosToolStripMenuItem.Click += artículosToolStripMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(61, 20);
            clientesToolStripMenuItem.Text = stringValuesSP.clientes;
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(61, 20);
            productosToolStripMenuItem.Text = stringValuesSP.pedidos;
            productosToolStripMenuItem.Click += productosToolStripMenuItem_Click;
            // 
            // mnuVentanas
            // 
            mnuVentanas.Name = "mnuVentanas";
            mnuVentanas.Size = new Size(66, 20);
            mnuVentanas.Text = stringValuesSP.terminal;
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
            buttonTerminal.Text = stringValuesSP.terminal;
            buttonTerminal.UseVisualStyleBackColor = true;
            buttonTerminal.Click += buttonTerminal_Click;
            // 
            // buttonLogout
            // 
            buttonLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonLogout.Location = new Point(28, 421);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(105, 23);
            buttonLogout.TabIndex = 2;
            buttonLogout.Text = "Cerrar sesión";
            buttonLogout.UseVisualStyleBackColor = true;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.MT_GROUP;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(914, 491);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripAC;
        private ToolStripMenuItem artículosToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem ventanasToolStripMenuItem;
        private Button buttonTerminal;
        private ToolStripMenuItem mnuVentanas;
        private Button buttonLogout;
    }
}
