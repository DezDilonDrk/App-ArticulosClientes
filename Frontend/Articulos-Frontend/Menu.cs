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

        private void mnuVentanas_Click(object sender, EventArgs e)
        {
            var dropDown = new ContextMenuStrip();

            if (WindowManager.OpenWindows.Count == 0)
            {
                dropDown.Items.Add("(Sin ventanas)").Enabled = false;
            }
            else
            {
                foreach (var kvp in WindowManager.OpenWindows)
                {
                    var key = kvp.Key;
                    var form = kvp.Value.formularioHijo;

                    var item = new ToolStripMenuItem(form.Text);
                    item.Click += (s, ev) => WindowManager.Activate(key);

                    dropDown.Items.Add(item);
                }
            }

            var parent = mnuVentanas.GetCurrentParent();
            var bounds = mnuVentanas.Bounds;

            dropDown.Show(parent, new Point(bounds.Left, bounds.Bottom));
        }
        private void RefrescarMenuVentanas()
        {
            mnuVentanas.DropDownItems.Clear();
            if (WindowManager.OpenWindows.Count == 0)
            {
                mnuVentanas.DropDownItems.Add(
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

                mnuVentanas.DropDownItems.Add(item);
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
