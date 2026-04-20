namespace Articulos_Frontend
{
    partial class PedidoDetailForm
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
        /*private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "PedidoDetailForm";
        }*/
        private TextBox textBoxDniCliente;
        private Label LabelDniCliente;
        private Label LabelMetodoPago;
        private Label LabelImpuestos;
        private Button BotonCrearC;
        private Label LabelTitulo;
        private Button button1;

        #endregion


        private ComboBox comboBoxImpuestos;
        private ComboBox comboBoxMetodoPago;
        private DataGridView dataGridViewArticulos;
        private Button button2;
        private Button button3;
        private Label labelTotal;
        private Label labelTotalCantidades;
        private Label label1;
        private ComboBox comboBoxEstado;
        private Button buttonCerrar;
        private Label label2;
        private DateTimePicker dateTimePickerFechaEnvio;
    }
}