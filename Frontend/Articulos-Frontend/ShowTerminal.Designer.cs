using Articulos_Frontend.Theme;

namespace Articulos_Frontend
{
    partial class ShowTerminal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private StringValuesSP stringValuesSP = new StringValuesSP();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowTerminal));
            labelTerminalTitle = new Label();
            panelTerminalArea = new Panel();
            panelTerminal = new Panel();
            panel1 = new Panel();
            panelTerminalArea.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // labelTerminalTitle
            // 
            labelTerminalTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelTerminalTitle.BackColor = Color.Transparent;
            labelTerminalTitle.Font = new Font("Segoe UI", 14F);
            labelTerminalTitle.ForeColor = SystemColors.ActiveCaptionText;
            labelTerminalTitle.Location = new Point(265, 24);
            labelTerminalTitle.Name = "labelTerminalTitle";
            labelTerminalTitle.Size = new Size(270, 54);
            labelTerminalTitle.TabIndex = 1;
            labelTerminalTitle.Tag = "titleTerminal";
            labelTerminalTitle.Text = stringValuesSP.terminal;
            labelTerminalTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelTerminalArea
            // 
            panelTerminalArea.Controls.Add(panelTerminal);
            panelTerminalArea.Dock = DockStyle.Fill;
            panelTerminalArea.Location = new Point(0, 100);
            panelTerminalArea.Name = "panelTerminalArea";
            panelTerminalArea.Padding = new Padding(30);
            panelTerminalArea.Size = new Size(800, 350);
            panelTerminalArea.TabIndex = 2;
            // 
            // panelTerminal
            // 
            panelTerminal.BackColor = SystemColors.ActiveCaption;
            panelTerminal.Dock = DockStyle.Fill;
            panelTerminal.Location = new Point(30, 30);
            panelTerminal.Name = "panelTerminal";
            panelTerminal.Size = new Size(740, 290);
            panelTerminal.TabIndex = 0;
            panelTerminal.Tag = "terminal";
            // 
            // panel1
            // 
            panel1.Controls.Add(labelTerminalTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 100);
            panel1.TabIndex = 3;
            // 
            // ShowTerminal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelTerminalArea);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlLightLight;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(816, 489);
            Name = "ShowTerminal";
            panelTerminalArea.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label labelTerminalTitle;
        private Panel panelTerminalArea;
        private Panel panel1;
        private Panel panelTerminal;
    }
}