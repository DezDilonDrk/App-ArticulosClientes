namespace Articulos_Frontend
{
    partial class PedidoUpdateForm
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
        private TextBox textBoxDniCliente;
        private TextBox textBoxId;
        private TextBox textBoxEstado;
        private Label LabelIdPedido;
        private Label LabelDniCliente;
        private Label LabelMetodoPago;
        private Label LabelEstado;
        private Label LabelImpuestos;
        private Button BotonCrearC;
        private Label LabelTitulo;
        #endregion

        private ComboBox comboBoxEstado;
        private ComboBox comboBoxImpuestos;
        private ComboBox comboBoxMetodoPago;
    }
}