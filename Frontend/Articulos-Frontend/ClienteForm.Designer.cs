namespace Articulos_Frontend
{
    partial class ClienteForm
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

        private TextBox textBoxCliente;
        private Button BotonMasC;
        private Button BotonMenosC;
        private Label labelNombreCliente;
        private Button BotonBuscar;
        private DataGridView dgvCliente;
        private Button BotonHelpC;
        private DateTimePicker FechaDesde;
        private GroupBox FiltroFecha;
        private DateTimePicker FechaHasta;
        private Button Filtros;
        private Panel panelFiltros;
        private Label labelFechaMax;
        private Label labelFechaMin;
        private Panel panel1;
        private Panel panelV;
        private Panel PNR;
        private Panel panel2;
    }
}