using Articulos_Frontend.Theme;
using Articulos_Frontend.LogConfig;
using MTCore_AC.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Articulos_Frontend
{
    public partial class ShowTerminal : Form
    {
        public ShowTerminal()
        {
            InitializeComponent();
            StyleManager.StyleForm(this);
            Log.OnLog += AddLog;
            foreach (var log in Log.GetLogHistory())
            {
                AddLog(log);
            }
            Log.Info("El usuario ha abierto la terminal");
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Log.OnLog -= AddLog;
            base.OnFormClosed(e);
        }
        public void AddLog(string log)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddLog), log);
                return;
            }
            Color color = Color.White;

            if (log.Contains("INFO"))
                color = ColorPalette.InfoColor;
            else if (log.Contains("ERROR"))
                color = ColorPalette.ErrorColor;
            else if (log.Contains("WARN"))
                color = ColorPalette.WarnColor;
            else if (log.Contains("DEBUG"))
                color = ColorPalette.DebugColor;

            rtextBoxTerminal.SelectionStart = rtextBoxTerminal.TextLength;
            rtextBoxTerminal.SelectionLength = 0;
            rtextBoxTerminal.SelectionColor = color;

            rtextBoxTerminal.AppendText(log + Environment.NewLine);

            rtextBoxTerminal.SelectionColor = rtextBoxTerminal.ForeColor;
        }
    }
}
