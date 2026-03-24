namespace Articulos_Frontend
{
    partial class Alerta
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
            imagenAlerta = new PictureBox();
            titulolAlerta = new Label();
            descripcionAlerta = new Label();
            excepcionAlerta = new Label();
            lineaAlerta = new Label();
            buttonConfirm = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)imagenAlerta).BeginInit();
            SuspendLayout();
            // 
            // imagenAlerta
            // 
            imagenAlerta.BackgroundImage = Properties.Resources.Yellow_Emoji_Face_meme_4;
            imagenAlerta.BackgroundImageLayout = ImageLayout.Stretch;
            imagenAlerta.Location = new Point(12, 12);
            imagenAlerta.Name = "imagenAlerta";
            imagenAlerta.Size = new Size(90, 84);
            imagenAlerta.TabIndex = 0;
            imagenAlerta.TabStop = false;
            // 
            // titulolAlerta
            // 
            titulolAlerta.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titulolAlerta.Location = new Point(117, 12);
            titulolAlerta.Name = "titulolAlerta";
            titulolAlerta.Size = new Size(293, 63);
            titulolAlerta.TabIndex = 1;
            titulolAlerta.Tag = "title";
            titulolAlerta.Text = "textoAlerta";
            // 
            // descripcionAlerta
            // 
            descripcionAlerta.Font = new Font("Segoe UI", 10F);
            descripcionAlerta.Location = new Point(117, 75);
            descripcionAlerta.Name = "descripcionAlerta";
            descripcionAlerta.Size = new Size(293, 141);
            descripcionAlerta.TabIndex = 2;
            descripcionAlerta.Text = "descripcionAlerta";
            // 
            // excepcionAlerta
            // 
            excepcionAlerta.Location = new Point(12, 99);
            excepcionAlerta.Name = "excepcionAlerta";
            excepcionAlerta.Size = new Size(99, 87);
            excepcionAlerta.TabIndex = 3;
            excepcionAlerta.Text = "excepcionAlerta";
            // 
            // lineaAlerta
            // 
            lineaAlerta.Location = new Point(12, 204);
            lineaAlerta.Name = "lineaAlerta";
            lineaAlerta.Size = new Size(99, 38);
            lineaAlerta.TabIndex = 4;
            lineaAlerta.Text = "lineaAlerta";
            lineaAlerta.Click += label1_Click;
            // 
            // buttonConfirm
            // 
            buttonConfirm.Location = new Point(229, 239);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(75, 23);
            buttonConfirm.TabIndex = 5;
            buttonConfirm.Text = "Aceptar";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(313, 239);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Cancelar";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // Alerta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 285);
            Controls.Add(buttonCancel);
            Controls.Add(buttonConfirm);
            Controls.Add(lineaAlerta);
            Controls.Add(excepcionAlerta);
            Controls.Add(descripcionAlerta);
            Controls.Add(titulolAlerta);
            Controls.Add(imagenAlerta);
            Name = "Alerta";
            Text = "Alerta";
            ((System.ComponentModel.ISupportInitialize)imagenAlerta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox imagenAlerta;
        private Label titulolAlerta;
        private Label descripcionAlerta;
        private Label excepcionAlerta;
        private Label lineaAlerta;
        private Button buttonConfirm;
        private Button buttonCancel;
    }
}