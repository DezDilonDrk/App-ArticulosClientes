using Articulos_Frontend.Client;
using Articulos_Frontend.Forms.main;
using Articulos_Frontend.Forms.Seguridad;
using Articulos_Frontend.LogConfig;
using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;

namespace Articulos_Frontend
{
    public partial class Menu : Form
    {
        ShowTerminal terminal;
        AjustesForm ajustes;
        private Usuario user;
        public Menu(UsuarioApiClient api, Usuario usuario)
        {
            InitializeComponent();
            StyleManager.StyleForm(this);
            Log.Info("Menú principal iniciado.");
            user = usuario;
            this.Text = stringValuesSP.menu;
            this.mnuVentanas.Text = stringValuesSP.ventanas;
            this.buttonTerminal.Text = stringValuesSP.terminal;
            this.buttonLogout.Text = stringValuesSP.logout;
            toolStripStatusLabelUser.Text = $"Usuario: {usuario.Nombre}  |";
            toolStripStatusLabelEmail.Text = $"|  Email: {usuario.CorreoElectronico}";
            if (!AppState.Roles.Contains(Roles.AdminAlmacen) && !AppState.Roles.Contains(Roles.UserAlmacen))
            {
                almacenToolStripMenuItem.Enabled = false;
            }
            if (!AppState.Roles.Contains(Roles.AdminVentas) && !AppState.Roles.Contains(Roles.UserVentas))
            {
                ventasToolStripMenuItem.Enabled = false;
            }
            if (!AppState.Roles.Contains(Roles.AdminSeguridad))
            {
                seguridadToolStripMenuItem.Enabled = false;
            }
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
                return new PedidoForm("SeccionPedido");
            });
        }
        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dropDown = new ContextMenuStrip();
            var usuarioItem = new ToolStripMenuItem(stringValuesSP.seccionUsuarios);
            var rolItem = new ToolStripMenuItem(stringValuesSP.seccionRoles);
            usuarioItem.Click += (s, ev) =>
            {
                WindowManager.ShowForm(stringValuesSP.seccionUsuarios, this, () => new UsuarioForm(new UsuarioApiClient(), user));
            };
            rolItem.Click += (s, ev) =>
            {
                WindowManager.ShowForm(stringValuesSP.seccionRoles, this, () => new RolForm(new RolApiClient()));
            };
            dropDown.Items.Add(usuarioItem);
            dropDown.Items.Add(rolItem);
            var parent = seguridadToolStripMenuItem.GetCurrentParent();
            var bounds = seguridadToolStripMenuItem.Bounds;
            dropDown.Show(parent, new Point(bounds.Left, bounds.Bottom));
        }

        private void almacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dropDown = new ContextMenuStrip();
            var articuloItem = new ToolStripMenuItem(stringValuesSP.listaArticulos);
            articuloItem.Click += (s, ev) =>
            {
                WindowManager.ShowForm(stringValuesSP.listaArticulos, this, () => new ArticuloForm(user));
            };

            dropDown.Items.Add(articuloItem);
            var parent = almacenToolStripMenuItem.GetCurrentParent();
            var bounds = almacenToolStripMenuItem.Bounds;
            dropDown.Show(parent, new Point(bounds.Left, bounds.Bottom));
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dropDown = new ContextMenuStrip();
            var clienteItem = new ToolStripMenuItem(stringValuesSP.listaClientes);
            var pedidoItem = new ToolStripMenuItem(stringValuesSP.listaPedidos);
            var enviadoItem = new ToolStripMenuItem(stringValuesSP.seccionEnvios);
            clienteItem.Click += (s, ev) =>
            {
                WindowManager.ShowForm(stringValuesSP.listaClientes, this, () => new ClienteForm());
            };
            pedidoItem.Click += (s, ev) =>
            {
                WindowManager.ShowForm(stringValuesSP.listaPedidos, this, () => new PedidoForm("SeccionPedido"));
            };
            enviadoItem.Click += (s, ev) =>
            {
                WindowManager.ShowForm(stringValuesSP.seccionEnvios, this, () => new PedidoForm("SeccionEnviado"));
            };
            dropDown.Items.Add(clienteItem);
            dropDown.Items.Add(pedidoItem);
            dropDown.Items.Add(enviadoItem);
            var parent = ventasToolStripMenuItem.GetCurrentParent();
            var bounds = ventasToolStripMenuItem.Bounds;
            dropDown.Show(parent, new Point(bounds.Left, bounds.Bottom));
        }



        private void mnuVentanas_Click(object sender, EventArgs e)
        {
            var dropDown = new ContextMenuStrip();

            if (WindowManager.OpenWindows.Count == 1)
            {
                dropDown.Items.Add("(Sin ventanas)").Enabled = false;
            }
            else
            {
                foreach (var kvp in WindowManager.OpenWindows)
                {
                    var key = kvp.Key;
                    var form = kvp.Value.formularioHijo;
                    if (!form.Visible) continue;
                    if (form.GetType() == typeof(LoginForm)) continue;
                    if (string.IsNullOrWhiteSpace(form.Text)) continue;

                    var item = new ToolStripMenuItem(form.Text);
                    item.Click += (s, ev) => WindowManager.Activate(key);
                    if (item.Text != "Menú")
                    {
                        dropDown.Items.Add(item);
                    }
                }
                ;
            }

            var parent = mnuVentanas.GetCurrentParent();
            var bounds = mnuVentanas.Bounds;

            dropDown.Show(parent, new Point(bounds.Left, bounds.Bottom));
        }
        private void Ajustes_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;
            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImage(btn.Image, rect);
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
            WindowManager.ShowForm(stringValuesSP.terminal, this, () =>
            {
                terminal = new ShowTerminal();
                return terminal;
            });
        }
        private void buttonAjustes_Click(object sender, EventArgs e)
        {
            Log.Info("Abriendo Ajustes.");
            WindowManager.ShowForm(stringValuesSP.ajustes, this, () =>
            {
                ajustes = new AjustesForm();
                return ajustes;
            });
        }
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            WindowManager.ShowForm(stringValuesSP.apartadoIniciarSesion, this, () => new LoginForm());

            var abiertos = WindowManager.OpenWindows.Values.ToList();
            foreach (var entry in abiertos)
            {
                try { entry.formularioHijo.Close(); }
                catch (Exception ex ) {
                    Log.Error("Error al cerrar la ventana: " + ex.Message);
                }
            }
            this.Close();
        }
    }
}
