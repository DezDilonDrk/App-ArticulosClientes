namespace Articulos_Frontend.Forms.Seguridad
{
    partial class RolForm
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
            dataGridViewRoles = new DataGridView();
            labelRoles = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoles).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewRoles
            // 
            dataGridViewRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRoles.Location = new Point(12, 138);
            dataGridViewRoles.Name = "dataGridViewRoles";
            dataGridViewRoles.Size = new Size(776, 300);
            dataGridViewRoles.TabIndex = 0;
            dataGridViewRoles.DataBindingComplete += dataGridViewRoles_DataBindingComplete;
            // 
            // labelRoles
            // 
            labelRoles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelRoles.Location = new Point(258, 9);
            labelRoles.Name = "labelRoles";
            labelRoles.Size = new Size(300, 80);
            labelRoles.TabIndex = 1;
            labelRoles.Tag = "title";
            labelRoles.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelRoles);
            Controls.Add(dataGridViewRoles);
            Name = "RolForm";
            Text = "Rol";
            Load += RolForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewRoles;
        private Label labelRoles;
    }
}