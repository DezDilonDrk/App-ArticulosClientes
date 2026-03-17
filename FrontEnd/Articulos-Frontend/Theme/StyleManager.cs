using Articulos_Frontend.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace Articulos_Frontend.Theme
{
    public static class StyleManager
    {
        public static void StyleForm(Form form)
        {
            form.BackColor = ColorPalette.Background;
            form.ForeColor = ColorPalette.TextDark;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ResumeLayout(false);

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
                lbl.Font = new Font("Intercom", 9, FontStyle.Regular);
            }
            if (control is TextBox txt)
            {
                txt.BackColor = ColorPalette.TextBoxBackground;
                txt.ForeColor = ColorPalette.TextPrimary;
                txt.BorderStyle = BorderStyle.None;
                txt.Font = new Font("Intercom", 9, FontStyle.Regular);
            }
            if (control is GroupBox gb)
            {
                gb.ForeColor = ColorPalette.TextPrimary;
                gb.Font = new Font("Intercom", 8, FontStyle.Bold);
            }
            if (control is CheckBox chk) {
                chk.ForeColor = ColorPalette.TextPrimary;
                chk.Font = new Font("Intercom", 9, FontStyle.Regular);
            }
            if (control is DateTimePicker dtp) {
                dtp.CalendarForeColor = ColorPalette.TextPrimary;
                dtp.CalendarMonthBackground = ColorPalette.GridBackground;
                dtp.CalendarTitleBackColor = ColorPalette.GridHeader;
                dtp.CalendarTitleForeColor = ColorPalette.TextPrimary;
                dtp.CalendarTrailingForeColor = ColorPalette.TextDark;
                dtp.Font = new Font("Intercom", 9, FontStyle.Regular);
            }

            // BOTONES
            if (control is Button btn)
            {
                btn.BackColor = ColorPalette.ButtonBackground;
                btn.ForeColor = ColorPalette.ButtonText;

                btn.FlatStyle = FlatStyle.Standard;
                btn.FlatAppearance.BorderSize = 5;

                if (btn.Text.Trim() == "-" || btn.Text.Trim() == "+")
                {

                    btn.Font = new Font("Intercom", 12, FontStyle.Bold);
                }
                else
                {
                    btn.Font = new Font("Intercom", 9, FontStyle.Bold);

                }

                btn.MouseEnter += (s, e) =>
                    btn.BackColor = ColorPalette.ButtonEnter;

                btn.MouseLeave += (s, e) =>
                    btn.BackColor = ColorPalette.ButtonLeave;
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
                grid.ColumnHeadersDefaultCellStyle.Font = new Font("Intercom", 9, FontStyle.Bold);

                grid.DefaultCellStyle.Font = new Font("Intercom", 9, FontStyle.Regular);

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
