using Articulos_Frontend.LogConfig;
using Articulos_Frontend.Theme;

namespace Articulos_Frontend
{
    public partial class Menu : Form
    {
        private ArticuloForm articuloForm;
        private ClienteForm clienteForm;
        public Menu()
        {
            InitializeComponent();
            StyleManager.StyleForm(this);
            Log.Info("Menú principal iniciado.");
        }
        public void Menu_Load(object sender, EventArgs e)
        {
            WindowManager.OnWindowsChanged += RefrescarMenuVentanas;
            RefrescarMenuVentanas();

        }
        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Info("Abriendo formulario de artículos.");
            string key = "ArticuloForm";

            WindowManager.ShowForm(key, this, () =>
            {
                return new ArticuloForm();
            });
        }
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Info("Abriendo formulario de clientes.");
            string key = "ClienteForm";

            WindowManager.ShowForm(key, this, () =>
            {
                return new ClienteForm();
            });
        }
        private void ventanasToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            RefrescarMenuVentanas();
        }
        private void RefrescarMenuVentanas()
        {
            ventanasToolStripMenuItem.DropDownItems.Clear();
            if (WindowManager.OpenWindows.Count == 0)
            {
                ventanasToolStripMenuItem.DropDownItems.Add(
                    new ToolStripMenuItem("(Sin ventanas)") { Enabled = false }
                );
                return;
            }
            foreach (var kvp in WindowManager.OpenWindows)
            {
                var key = kvp.Key;
                var form = kvp.Value.formularioHijo;
                var item = new ToolStripMenuItem(form.Text);
                item.Click += (s, e) => WindowManager.Activate(key);

                ventanasToolStripMenuItem.DropDownItems.Add(item);
            }
        }
        public int getMenuStripHeigth()
        {
            return this.menuStripAC.Height;
        }
        public int getMenuStripAbsoluteY()
        {
            return this.menuStripAC.PointToScreen(Point.Empty).Y;
        }

        private void buttonTerminal_Click(object sender, EventArgs e)
        {
            Log.Info("Abriendo terminal.");
            WindowManager.ShowForm("TerminalForm", this, () =>
            {
                return new ShowTerminal();
            });
        }
    }
}
