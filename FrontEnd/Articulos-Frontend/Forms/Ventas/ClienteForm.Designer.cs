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
        private Button Filtros;
        private Panel panelFiltros;
        private GroupBox FiltroFecha;
        private Label labelFechaMax;
        private Label labelFechaMin;
        private DateTimePicker FechaHasta;
        private DateTimePicker FechaDesde;
        private Panel panelMain;
        private Panel panelDGV;
        private Panel panel1;
        private GroupBox BuscarNombre;
    }
}