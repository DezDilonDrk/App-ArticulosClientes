using Articulos_Frontend.Client;
using Articulos_Frontend.Forms.main;
using Articulos_Frontend.Forms.Seguridad;
using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.LogConfig;
using System.DirectoryServices.ActiveDirectory;
using static MTCore_AC.DTO.LoginDtos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Articulos_Frontend
{
    public partial class Menu : Form
    {
        ShowTerminal terminal;
        AjustesForm ajustes;
        private Usuario user;
        UsuarioApiClient api;
        ConfiguracionApiClient configuracionApiClient;
        public Menu(UsuarioApiClient api, Usuario usuario)
        {
            InitializeComponent();
            StyleManager.StyleForm(this);
            Log.Info("Menú principal iniciado.");
            user = usuario;
            this.api = api;
            this.Text = stringValuesSP.menu;
            this.mnuVentanas.Text = stringValuesSP.ventanas;
            toolStripStatusLabelUser.Text = $"Usuario: {usuario.Nombre}  ";
            toolStripStatusLabelEmail.Text = $"|  Email: {usuario.CorreoElectronico}  ";
            StStatusLServidor.Text = $"|  Servidor: {AppState.getServer()}";
            if (!AppState.getUserSession().getRoles().Contains(Roles.AdminAlmacen) && !AppState.getUserSession().getRoles().Contains(Roles.UserAlmacen))
            {
                almacenToolStripMenuItem.Enabled = false;
            }
            if (!AppState.getUserSession().getRoles().Contains(Roles.AdminVentas) && !AppState.getUserSession().getRoles().Contains(Roles.UserVentas))
            {
                ventasToolStripMenuItem.Enabled = false;
            }
            if (!AppState.getUserSession().getRoles().Contains(Roles.AdminSeguridad))
            {
                seguridadToolStripMenuItem.Enabled = false;
            }
            configuracionApiClient = new ConfiguracionApiClient(AppState.getUserSession());
            this.Load += Menu_Load;
            this.Shown += Menu_Shown;
            labelRolesTitulo.Text = stringValuesSP.roles;
        }
        private async Task initAsync()
        {
            try
            {
                UserSession userSession = AppState.getUserSession();
                string email = userSession.getEmail();
                string contrasena = userSession.getContrasena();
                var loginResponse = AppState.getLoginResponse();
                if (AppState.getLoginResponse() == null){
                    var loginRequest = new LoginRequest { Email = email, Password = contrasena};
                    loginResponse = await api.LoginAsync(loginRequest);
                    AppState.setLoginResponse(loginResponse);
                    if (loginResponse != null)
                    {
                        Log.Info($"Usuario {email} ha iniciado sesión exitosamente."); // Con Token
                    }
                    else { 
                        Log.Error($"Intento de login fallido para el usuario {email}.");
                    }
                }
                if (loginResponse == null) { return; }
                if (loginResponse.token != null)
                {
                    AppState.getUserSession().setToken(loginResponse.token);
                    await ConfigurationSet(AppState.getUserSession().getEmail());
                }
                else
                {
                    Log.Warn($"Intento de login fallido para el usuario {email}.");
                    Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new Exception("Credenciales incorrectas."));
                    alerta.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error durante el proceso de login automático: {ex.Message}");
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new Exception("Ocurrió un error durante el inicio de sesión automático. Por favor, inicie sesión manualmente."));
                alerta.ShowDialog();
            }
        }
        public async void Menu_Load(object sender, EventArgs e)
        {
            WindowManager.OnWindowsChanged += RefrescarMenuVentanas;
            await ConfigurationSet(AppState.getUserSession().getEmail());
            RegistrarClicks(this);
        }
        public async void Menu_Shown(object sender, EventArgs e)
        {
            Enabled = false;
            await configuracionApiClient.InitAsync(AppState.getServer());
            await api.InitAsync(AppState.getServer());
            await ConfigurationSet(AppState.getUserSession().getEmail());
            await initAsync();
            Enabled = true;
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
            var usuarioItem = new ToolStripMenuItem("UsuarioForm");
            var rolItem = new ToolStripMenuItem("RolForm");
            usuarioItem.Click += (s, ev) =>
            {
                WindowManager.ShowForm(stringValuesSP.seccionUsuarios, this, () => new UsuarioForm(new UsuarioApiClient(AppState.getUserSession()), user));
            };
            rolItem.Click += (s, ev) =>
            {
                WindowManager.ShowForm(stringValuesSP.seccionRoles, this, () => new RolForm(new RolApiClient(AppState.getUserSession())));
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
                WindowManager.ShowForm(stringValuesSP.listaPedidos, this, () => new PedidoForm("Pedidos"));
            };
            enviadoItem.Click += (s, ev) =>
            {
                WindowManager.ShowForm(stringValuesSP.seccionEnvios, this, () => new PedidoForm("Envios"));
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
            }

            var parent = mnuVentanas.GetCurrentParent();
            var bounds = mnuVentanas.Bounds;

            dropDown.Show(parent, new Point(bounds.Left, bounds.Bottom));
        }
        private async void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dropDown = new ContextMenuStrip();
            var notificationSettingsItem = new ToolStripMenuItem(stringValuesSP.ajustesNotificacion);
            var accountSettingsItem = new ToolStripMenuItem(stringValuesSP.ajustesCuenta);
            var cambiarContrasenaItem = new ToolStripMenuItem(stringValuesSP.cambiarContrasena);
            var cerrarSesionItem = new ToolStripMenuItem(stringValuesSP.logout);
            var stringValue = AppState.getConfiguracion().SendNotifications ? stringValuesSP.notificacionesEmailSi : stringValuesSP.notificacionesEmailNo;
            var checkNotificaciones = new ToolStripMenuItem(stringValue);

            cambiarContrasenaItem.Click += (s, ev) => {
                WindowManager.ShowForm(stringValuesSP.cambiarContrasena, this, () => new CambiarContrasenaForm(user.CorreoElectronico));
            };
            cerrarSesionItem.Click += buttonLogout_Click;
            checkNotificaciones.Click += (s, ev) =>
            {
                if (AppState.getConfiguracion().SendNotifications){
                    Log.Info("Desactivando notificaciones por email.");
                    AppState.changeCheckNotifications();
                    try
                    {
                        configuracionApiClient.GuardarConfiguracionPorCorreo(user.CorreoElectronico, AppState.getConfiguracion());

                    }
                    catch (Exception ex)
                    {
                        Log.Error("Error al guardar la configuración de notificaciones: " + ex.Message);
                        Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                        alerta.ShowDialog();
                        return;
                    }
                    MessageBox.Show("Las notificaciones por email han sido desactivadas.\n\nNotifications: OFF", "Notificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Log.Info("Activando notificaciones por email.");
                    AppState.changeCheckNotifications();
                    try
                    {
                        configuracionApiClient.GuardarConfiguracionPorCorreo(user.CorreoElectronico, AppState.getConfiguracion());

                    }
                    catch (Exception ex)
                    {
                        Log.Error("Error al guardar la configuración de notificaciones: " + ex.Message);
                        Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                        alerta.ShowDialog();
                        return;
                    }
                    MessageBox.Show("Las notificaciones por email han sido activadas.\n\nNotifications: ON", "Notificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                checkNotificaciones.Text = !AppState.getConfiguracion().SendNotifications ? stringValuesSP.notificacionesEmailSi : stringValuesSP.notificacionesEmailNo;
            };
            notificationSettingsItem.DropDownItems.Add(checkNotificaciones);
            accountSettingsItem.DropDownItems.Add(cambiarContrasenaItem);
            accountSettingsItem.DropDownItems.Add(cerrarSesionItem);
            dropDown.Items.Add(accountSettingsItem);
            dropDown.Items.Add(notificationSettingsItem);
            var parent = usuarioToolStripMenuItem.GetCurrentParent();
            var bounds = usuarioToolStripMenuItem.Bounds;
            dropDown.Show(parent, new Point(bounds.Left, bounds.Bottom));
        }
        private void aplicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dropDown = new ContextMenuStrip();
            var debugItem = new ToolStripMenuItem(stringValuesSP.debugSection);
            var terminalItem = new ToolStripMenuItem(stringValuesSP.terminal);
            var terminalDebugItem = new ToolStripMenuItem(stringValuesSP.terminal);
            terminalItem.Click += buttonTerminal_Click;
            terminalDebugItem.Click += buttonTerminal_Click;
            debugItem.DropDownItems.Add(terminalDebugItem);
            var debugServer = new ToolStripMenuItem();
            dropDown.Items.Add(debugItem);
            var parent = aplicacionToolStripMenuItem.GetCurrentParent();
            var bounds = aplicacionToolStripMenuItem.Bounds;
            dropDown.Show(parent, new Point(bounds.Left, bounds.Bottom));
        }
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            AppState.tokenHelper.BorrarToken();
            var form = new LoginForm();
            this.FormClosing += (s, args) => form.Show(); //Si ha iniciado sesión por login, podrá acceder de nuevo si se cierra sesión, de lo contrario directamente se cerraría
            var abiertos = WindowManager.OpenWindows.Values.ToList();
            foreach (var entry in abiertos)
            {
                try { entry.formularioHijo.Close(); }
                catch (Exception ex)
                {
                    Log.Error("Error al cerrar la ventana: " + ex.Message);
                }
            }
            this.Close();
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
        private void RolesClick(object sender, EventArgs e)
        {
            Log.Info("Abriendo panel de roles.");
            LabelListaRoles.Text = "";
            foreach (string rol in AppState.getUserSession().getRoles())
            {
                LabelListaRoles.Text = $"{LabelListaRoles.Text}\n\n{rol}";
            }
            panelRolesUsuario.Visible = true;
        }
        private void RegistrarClicks(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c == panelRolesUsuario)
                    continue;
                c.Click += CerrarPanelClickFuera;
                if (c.HasChildren)
                    RegistrarClicks(c);
            }
            parent.Click += CerrarPanelClickFuera;
            foreach (Control c in parent.Controls)
            {
                if (c == panelRolesUsuario || c.Name == toolStripStatusLabelUser.Name)
                    continue;

                c.Click += CerrarPanelClickFuera;

                if (c.HasChildren)
                    RegistrarClicks(c);
            }
            parent.Click += CerrarPanelClickFuera;
        }
        private void CerrarPanelClickFuera(object sender, EventArgs e)
        {
            if (panelRolesUsuario.Visible)
            {
                Point mousePos = this.PointToClient(Cursor.Position);

                if (!panelRolesUsuario.Bounds.Contains(mousePos))
                {
                    panelRolesUsuario.Visible = false;
                    Log.Info("Cerrando panel de filtros al hacer clic fuera del panel.");
                    panelRolesUsuario.Text = "▼  Abrir Filtros";
                }
            }
        }
        private void buttonAjustes_Click(object sender, EventArgs e)
        {
            Log.Info("Abriendo Ajustes.");
            WindowManager.ShowForm(stringValuesSP.ajustes, this, () =>
            {
                ajustes = new AjustesForm();
                ajustes.Owner = this;
                return ajustes;
            });
        }
        private async Task ConfigurationSet(string email)
        {
            await configuracionApiClient.InitAsync(UrlMT.serverLocal);
            var config = await configuracionApiClient.ObtenerConfiguracionPorCorreo(email);
            if (config != null)
            {
                AppState.setConfiguracion(config);
                try
                {
                    configuracionApiClient.GuardarConfiguracionPorCorreo(email, config);

                }
                catch (Exception ex)
                {
                    Log.Error("Error al guardar la configuración de notificaciones: " + ex.Message);
                    Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                    alerta.ShowDialog();
                    return;
                }
            }
            else
            {
                Log.Warn($"No se encontró configuración para el usuario {email}. Se establecerá la configuración predeterminada.");
                config = new ConfiguracionModel { SendNotifications = true };
                AppState.setConfiguracion(config);
                try
                {
                    configuracionApiClient.GuardarConfiguracionPorCorreo(email, config);

                }
                catch (Exception ex)
                {
                    Log.Error("Error al guardar la configuración de notificaciones: " + ex.Message);
                    Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                    alerta.ShowDialog();
                    return;
                }
            }
        }
    }
}
