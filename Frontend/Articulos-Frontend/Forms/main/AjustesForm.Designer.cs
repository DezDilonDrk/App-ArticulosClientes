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
            pictureBoxLogoDesplegado = new PictureBox();
            panelMain = new Panel();
            panelMainSpace = new Panel();
            panel1 = new Panel();
            labelBuscadorAjustes = new Label();
            textBoxBuscadorAjustes = new TextBox();
            panelLateralPlegado = new Panel();
            pictureBoxLogo = new PictureBox();
            panelLateral.SuspendLayout();
            ((ISupportInitialize)pictureBoxLogoDesplegado).BeginInit();
            panelMain.SuspendLayout();
            panel1.SuspendLayout();
            panelLateralPlegado.SuspendLayout();
            ((ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // panelLateral
            // 
            panelLateral.AutoScroll = true;
            panelLateral.BackColor = Color.FromArgb(58, 58, 58);
            panelLateral.Controls.Add(pictureBoxLogoDesplegado);
            panelLateral.Dock = DockStyle.Left;
            panelLateral.Location = new Point(70, 0);
            panelLateral.Name = "panelLateral";
            panelLateral.Size = new Size(200, 450);
            panelLateral.TabIndex = 10;
            panelLateral.Visible = false;
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
            panelMainSpace.Dock = DockStyle.Fill;
            panelMainSpace.Location = new Point(0, 60);
            panelMainSpace.Name = "panelMainSpace";
            panelMainSpace.Size = new Size(832, 390);
            panelMainSpace.TabIndex = 9;
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
            Load += ClienteForm_Load;
            panelLateral.ResumeLayout(false);
            ((ISupportInitialize)pictureBoxLogoDesplegado).EndInit();
            panelMain.ResumeLayout(false);
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
    }
}