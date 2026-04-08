using Articulos_Frontend.Client;
using Articulos_Frontend.LogConfig;
using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;

namespace Articulos_Frontend
{
    public partial class Menu : Form
    {
        private ArticuloForm articuloForm;
        private ClienteForm clienteForm;
        ShowTerminal terminal;
        private Usuario user;
        public Menu(UsuarioApiClient api, Usuario usuario)
        {
            InitializeComponent();
            StyleManager.StyleForm(this);
            Log.Info("Menú principal iniciado.");
            user = usuario;
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
                return new ArticuloForm(user);
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
            Log.Info("Prueba Info");
            Log.Debug("Prueba Debug");
            Log.Warn("Prueba Warn");
            Log.Error("Prueba Error");
        }
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string key = "PedidoForm";

            WindowManager.ShowForm(key, this, () =>
            {
                return new PedidoForm();
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
                terminal = new ShowTerminal();
                return terminal;
            });
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            WindowManager.ShowForm("LoginForm", this, () => new LoginForm());

            var abiertos = WindowManager.OpenWindows.Values.ToList();
            foreach (var entry in abiertos)
            {
                try { entry.formularioHijo.Close(); }
                catch { }
            }

            this.Close();
        }
    }
}
