using Articulos_Frontend.Theme;
using SesionMT.LogConfig;

namespace Articulos_Frontend
{
    public partial class ShowTerminal : Form
    {
        public ShowTerminal()
        {
            InitializeComponent();
            StyleManager.StyleForm(this);
            refreshList();
            Log.Info("El usuario ha abierto la terminal");
        }
        public void refreshList()
        {
            foreach (var log in Log.GetLogHistory())
            {
                AddLog(log);
            }
        }
        /* protected override void OnActivated(EventArgs e)
        {
            rtextBoxTerminal.Clear();
            refreshList();
            base.OnActivated(e);
        } */
        public void AddLog(string log)
        {
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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            rtextBoxTerminal.Clear();
            refreshList();
        }
    }
}
