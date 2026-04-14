namespace Articulos_Frontend.Forms.Seguridad
{
    partial class UsuarioForm
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
            labelUsuario = new Label();
            textBoxUsuario = new TextBox();
            buttonAdd = new Button();
            buttonDel = new Button();
            dataGridViewUsuarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            SuspendLayout();
            // 
            // labelUsuario
            // 
            labelUsuario.Location = new Point(39, 26);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(103, 32);
            labelUsuario.TabIndex = 0;
            labelUsuario.Text = "Buscar:";
            // 
            // textBoxUsuario
            // 
            textBoxUsuario.Location = new Point(98, 23);
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.PlaceholderText = "Escribe aqui un usuario";
            textBoxUsuario.Size = new Size(143, 23);
            textBoxUsuario.TabIndex = 1;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAdd.Location = new Point(688, 26);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(48, 33);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "+";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonDel
            // 
            buttonDel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDel.Location = new Point(688, 70);
            buttonDel.Name = "buttonDel";
            buttonDel.Size = new Size(48, 29);
            buttonDel.TabIndex = 4;
            buttonDel.Text = "-";
            buttonDel.UseVisualStyleBackColor = true;
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Location = new Point(48, 117);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.Size = new Size(688, 302);
            dataGridViewUsuarios.TabIndex = 5;
            dataGridViewUsuarios.DataBindingComplete += dataGridViewUsuarios_DataBindingComplete;
            // 
            // UsuarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewUsuarios);
            Controls.Add(buttonDel);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxUsuario);
            Controls.Add(labelUsuario);
            Name = "UsuarioForm";
            Text = "UsuarioForm";
            Load += UsuarioForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUsuario;
        private TextBox textBoxUsuario;
        private Button buttonAdd;
        private Button buttonDel;
        private DataGridView dataGridViewUsuarios;
    }
}