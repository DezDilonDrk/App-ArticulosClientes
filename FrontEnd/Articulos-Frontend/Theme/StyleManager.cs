using System;
using System.Collections.Generic;
using System.Text;

namespace Articulos_Frontend.Theme
{
    public static class StyleManager
    {
        public static void StyleForm(Form form)
        {
            form.BackColor = ColorPalette.Background;
            form.ForeColor = ColorPalette.TextDark;

            foreach (Control control in form.Controls)
            {
                ApplyStyle(control);
            }
        }

        private static void ApplyStyle(Control control)
        {
            // LABELS
            if (control is Label lbl)
            {
                lbl.ForeColor = ColorPalette.TextPrimary;
                lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }

            if (control is TextBox txt)
            {
                txt.BackColor = ColorPalette.TextPrimary;
                txt.ForeColor = ColorPalette.TextDark;
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }

            if (control is GroupBox gb)
            {
                gb.ForeColor = ColorPalette.TextPrimary;
            }

            if (control is CheckBox chk) {
                chk.ForeColor = ColorPalette.TextPrimary;
                chk.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }

            if (control is DateTimePicker dtp) {
                dtp.CalendarForeColor = ColorPalette.TextPrimary;
                dtp.CalendarMonthBackground = ColorPalette.GridBackground;
                dtp.CalendarTitleBackColor = ColorPalette.GridHeader;
                dtp.CalendarTitleForeColor = ColorPalette.TextPrimary;
                dtp.CalendarTrailingForeColor = ColorPalette.TextDark;
                dtp.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }

            // BOTONES
            if (control is Button btn)
            {
                btn.BackColor = ColorPalette.ButtonBack;
                btn.ForeColor = ColorPalette.ButtonText;

                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;

                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                btn.MouseEnter += (s, e) =>
                    btn.BackColor = ColorPalette.ButtonHover;

                btn.MouseLeave += (s, e) =>
                    btn.BackColor = ColorPalette.ButtonBack;
            }

            // DATAGRIDVIEW
            if (control is DataGridView grid)
            {
                grid.BackgroundColor = ColorPalette.GridBackground;
                grid.BorderStyle = BorderStyle.None;

                grid.EnableHeadersVisualStyles = false;

                // Cabecera
                grid.ColumnHeadersDefaultCellStyle.BackColor = ColorPalette.GridHeader;
                grid.ColumnHeadersDefaultCellStyle.ForeColor = ColorPalette.TextPrimary;
                grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // Celdas
                grid.DefaultCellStyle.BackColor = ColorPalette.GridBackground;
                grid.DefaultCellStyle.ForeColor = ColorPalette.TextPrimary;
                grid.DefaultCellStyle.SelectionBackColor = ColorPalette.Primary;
                grid.DefaultCellStyle.SelectionForeColor = ColorPalette.TextPrimary;

                // Apariencia
                grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                grid.AllowUserToResizeRows = false;
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                grid.GridColor = ColorPalette.GridHeader;

                grid.RowTemplate.Height = 30;
            }

            // Aplicar también a controles hijos
            foreach (Control child in control.Controls)
            {
                ApplyStyle(child);
            }
        }

    }
}
