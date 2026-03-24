using Articulos_Frontend.Theme;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articulos_Frontend
{
    public class FormMT
    {
        public Form formularioHijo { get; set; }
        public Form formularioPadre { get; set; }
        public FormMT(Form formularioPadre, Form formularioHijo)
        {
            this.formularioPadre = formularioPadre;
            this.formularioHijo = formularioHijo;
        }
        public static void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.CurrentCell != null && e.RowIndex == dgv.CurrentCell.RowIndex)
            {
                e.CellStyle.BackColor = ColorPalette.PrimaryLight;
                e.CellStyle.ForeColor = ColorPalette.TextPrimary;
            }
            else
            {
                e.CellStyle.BackColor = ColorPalette.GridBackground;
                e.CellStyle.ForeColor = ColorPalette.TextPrimary;
            }
        }
        public static void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            dgv.Invalidate();
        }
    }
}
