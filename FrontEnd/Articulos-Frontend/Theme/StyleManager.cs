using Articulos_Frontend.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace Articulos_Frontend.Theme;

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
        /*if (control is Label lbl)
        {
            if (lbl.Text.Equals("ACTUALIZAR CLIENTE") || lbl.Text.Equals("CREAR CLIENTE"))
            {
                lbl.ForeColor = ColorPalette.TextPrimary;
                lbl.Font = new Font("Intercom", 18, FontStyle.Bold);
            }
            else
            {
                lbl.ForeColor = ColorPalette.TextPrimary;
                lbl.Font = new Font("Intercom", 9, FontStyle.Regular);
            }
        }*/
        if(control is StatusStrip ss) { 
            ss.BackColor = ColorPalette.GridHeader;
            ss.ForeColor = ColorPalette.TextPrimary;
            ss.Font = new Font("Intercom", 9, FontStyle.Regular);
        }
        if (control is Label lbl)
        {
            lbl.ForeColor = ColorPalette.TextPrimary;
            lbl.BackColor = ColorPalette.Background;
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
        if (control is CheckBox chk)
        {
            chk.ForeColor = ColorPalette.TextPrimary;
            chk.Font = new Font("Intercom", 9, FontStyle.Regular);
        }
        if (control is DateTimePicker dtp)
        {
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

            if (btn.Text.Trim().Equals("-") || btn.Text.Trim().Equals("+"))
            {

                btn.Font = new Font("Intercom", 12, FontStyle.Bold);
            }
            else
            {
                btn.Font = new Font("Intercom", 9, FontStyle.Bold);

            }

            btn.MouseEnter += (s, e) =>
                btn.BackColor = ColorPalette.ButtonEnter;
                btn.ForeColor = Color.White;
            btn.MouseLeave += (s, e) =>
                btn.BackColor = ColorPalette.ButtonLeave;
                btn.ForeColor = SystemColors.ControlLightLight;
        }
        // DATAGRIDVIEW
        if (control is DataGridView dgv)
        {
            dgv.BackgroundColor = ColorPalette.GridBackground;
            dgv.BorderStyle = BorderStyle.None;

            dgv.EnableHeadersVisualStyles = false;

            // Cabecera
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorPalette.GridHeader;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorPalette.TextPrimary;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Intercom", 9, FontStyle.Bold);

            dgv.DefaultCellStyle.Font = new Font("Intercom", 9, FontStyle.Regular);

            // Celdas
            dgv.DefaultCellStyle.BackColor = ColorPalette.GridBackground;
            dgv.DefaultCellStyle.ForeColor = ColorPalette.TextPrimary;
            dgv.DefaultCellStyle.SelectionBackColor = ColorPalette.Primary;
            dgv.DefaultCellStyle.SelectionForeColor = ColorPalette.TextPrimary;
            dgv.ReadOnly = true;

            // Apariencia
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = ColorPalette.GridHeader;
            dgv.RowHeadersDefaultCellStyle.BackColor = ColorPalette.GridHeader;

            dgv.CurrentCellChanged += FormMT.dgv_CurrentCellChanged;
            dgv.CellFormatting += FormMT.dgv_CellFormatting;

            dgv.RowTemplate.Height = 30;
        }

        if (control.Tag is string tag)
        {
            switch (tag)
            {
                case "title":
                    if (control is Label lbl2)
                        lbl2.Font = new Font("Intercom", 20, FontStyle.Bold);
                    break;
                case "normalText":
                    if (control is Label lbl3)
                        lbl3.Font = new Font("Intercom", 9, FontStyle.Bold);
                    break;
                case "modButton":
                    if (control is Button btn3)
                    {
                        btn3.Font = new Font("Intercom", 20, FontStyle.Bold);
                    }
                    break;
                case "menuStrip":
                    if (control is MenuStrip ms)
                    {
                        ms.BackColor = ColorPalette.GridHeader;
                        ms.ForeColor = ColorPalette.TextPrimary;
                        ms.Font = new Font("Intercom", 9, FontStyle.Regular);
                    }
                    break;
                case "titleTerminal":
                    if (control is Label lbl4)
                        lbl4.Font = new Font("Intercom", 30, FontStyle.Bold);
                    break;
                case "terminal":
                    if (control is Panel panel)
                    {
                        panel.ForeColor = ColorPalette.TextPrimary;
                        panel.BackColor = ColorPalette.GridBackground;
                    } else if (control is RichTextBox rTxt)
                    {
                        rTxt.BackColor = ColorPalette.GridBackground;
                        rTxt.ForeColor = ColorPalette.TextPrimary;
                        rTxt.Font = new Font("Intercom", 10, FontStyle.Bold);
                    }
                    break;
                case "comboBox":
                    if (control is ComboBox cb)
                    {
                        cb.BackColor = ColorPalette.TextBoxBackground;
                        cb.ForeColor = ColorPalette.TextPrimary;
                        cb.Font = new Font("Intercom", 9, FontStyle.Regular);
                    }
                    break;
                default:
                    if (control is TextBox txt2)
                        txt2.Font = new Font("Intercom", 9, FontStyle.Regular);
                    break;
            }
        }
        // Aplicar también a controles hijos
        foreach (Control child in control.Controls)
        {
            ApplyStyle(child);
        }
    }
}
