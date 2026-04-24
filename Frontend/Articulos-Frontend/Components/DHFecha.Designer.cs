namespace Articulos_Frontend.Components
{
    partial class DHFecha
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            FiltroFechaCreacion = new GroupBox();
            labelFechaMax = new Label();
            labelFechaMin = new Label();
            FechaHasta = new DateTimePicker();
            FechaDesde = new DateTimePicker();
            FiltroFechaCreacion.SuspendLayout();
            SuspendLayout();
            // 
            // FiltroFechaCreacion
            // 
            FiltroFechaCreacion.BackColor = Color.Transparent;
            FiltroFechaCreacion.Controls.Add(labelFechaMax);
            FiltroFechaCreacion.Controls.Add(labelFechaMin);
            FiltroFechaCreacion.Controls.Add(FechaHasta);
            FiltroFechaCreacion.Controls.Add(FechaDesde);
            FiltroFechaCreacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            FiltroFechaCreacion.ForeColor = Color.FromArgb(242, 242, 242);
            FiltroFechaCreacion.Location = new Point(3, 3);
            FiltroFechaCreacion.Name = "FiltroFechaCreacion";
            FiltroFechaCreacion.Size = new Size(200, 85);
            FiltroFechaCreacion.TabIndex = 8;
            FiltroFechaCreacion.TabStop = false;
            FiltroFechaCreacion.Text = "Filtrar por Fecha de Creación";
            // 
            // labelFechaMax
            // 
            labelFechaMax.AutoSize = true;
            labelFechaMax.Location = new Point(10, 57);
            labelFechaMax.Name = "labelFechaMax";
            labelFechaMax.Size = new Size(86, 15);
            labelFechaMax.TabIndex = 9;
            labelFechaMax.Text = "Fecha Máxima";
            // 
            // labelFechaMin
            // 
            labelFechaMin.AutoSize = true;
            labelFechaMin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFechaMin.Location = new Point(10, 27);
            labelFechaMin.Name = "labelFechaMin";
            labelFechaMin.Size = new Size(83, 15);
            labelFechaMin.TabIndex = 8;
            labelFechaMin.Text = "Fecha Mínima";
            // 
            // FechaHasta
            // 
            FechaHasta.CalendarForeColor = Color.Black;
            FechaHasta.CalendarMonthBackground = SystemColors.GrayText;
            FechaHasta.CalendarTitleForeColor = Color.Black;
            FechaHasta.Format = DateTimePickerFormat.Short;
            FechaHasta.Location = new Point(99, 51);
            FechaHasta.Name = "FechaHasta";
            FechaHasta.Size = new Size(97, 23);
            FechaHasta.TabIndex = 7;
            FechaHasta.Value = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            // 
            // FechaDesde
            // 
            FechaDesde.AllowDrop = true;
            FechaDesde.CalendarForeColor = Color.Black;
            FechaDesde.CalendarMonthBackground = SystemColors.GrayText;
            FechaDesde.CalendarTitleForeColor = Color.Black;
            FechaDesde.Format = DateTimePickerFormat.Short;
            FechaDesde.Location = new Point(99, 22);
            FechaDesde.Name = "FechaDesde";
            FechaDesde.Size = new Size(97, 23);
            FechaDesde.TabIndex = 6;
            FechaDesde.Value = new DateTime(1979, 8, 10, 0, 0, 0, 0);
            // 
            // DHFecha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(FiltroFechaCreacion);
            Name = "DHFecha";
            Size = new Size(218, 100);
            FiltroFechaCreacion.ResumeLayout(false);
            FiltroFechaCreacion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox FiltroFechaCreacion;
        private Label labelFechaMax;
        private Label labelFechaMin;
        private DateTimePicker FechaHasta;
        private DateTimePicker FechaDesde;
    }
}
