using Articulos_Frontend.Client;
using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.LogConfig;
using static MTCore_AC.DTO.LoginDtos;

namespace Articulos_Frontend;

public partial class LoginForm : Form
{
    private UsuarioApiClient api;
    private ConfiguracionApiClient configApi;
    private StringValuesSP stringValuesSP = new StringValuesSP();
    public LoginForm()
    {
        InitializeComponent();
        api = new UsuarioApiClient();
        configApi = new ConfiguracionApiClient();
        StyleManager.StyleForm(this);
        Log.Info("Formulario de login iniciado.");
        this.Text = stringValuesSP.login;
    }
    public async void loginButton_Click(object sender, EventArgs e)
    {
        string email = emailText.Text;
        string contrasena = contrasenaText.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contrasena))
        {
            Log.Warn("Intento de login con campos vacíos.");
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new Exception("Por favor, complete ambos campos."));
            alerta.ShowDialog();
            return;
        }
        try
        {
            var loginRequest = new LoginRequest { Email = email, Password = contrasena };
            var loginResponse = await api.LoginAsync(loginRequest);
            
            if (loginResponse != null)
            {
                AppState.getUserSession().setToken(loginResponse.token);
                AppState.getUserSession().setRoles(loginResponse.Roles);
                UserSession userSession = new UserSession(UrlMT.serverLocal, AppState.getUserSession().CargarToken());
                userSession.GuardarToken();
                Log.Info($"Usuario {email} ha iniciado sesión exitosamente.");

                await ConfigurationSet(AppState.getUserSession().getEmail());
                WindowManager.ShowForm(
                    "MainForm",
                    this,
                    () =>
                    {
                        var form = new Menu(api, loginResponse.Usuario);
                        form.FormClosed += (s, args) => this.Show();
                        return form;
                    }
                );
                this.Hide();
            }
            else
            {
                Log.Warn($"Intento de login fallido para el usuario {email}.");
                Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new Exception("Credenciales incorrectas."));
                alerta.ShowDialog();
            }
            emailText.Text = "";
            contrasenaText.Text = "";
        }
        catch (Exception ex)
        {
            Log.Error("Error durante el proceso de login: " + ex.Message);
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
            alerta.ShowDialog();
        }
    }
    private void emailText_keyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            loginButton_Click(sender, e);
        }
    }
    private void contrasenaText_keyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            loginButton_Click(sender, e);
        }
    }
    public async Task LoginForm_Load(object sender, EventArgs e)
    {
        try
        {
            await api.InitAsync(UrlMT.serverLocal);
            await configApi.InitAsync(UrlMT.serverLocal);
        }
        catch (Exception ex)
        {
            Log.Error("Error con el InitAsync del api en Login Form.", ex);
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
            alerta.ShowDialog();
        }
    }
    private async Task ConfigurationSet(string email) {

        await configApi.InitAsync(UrlMT.serverLocal);
        var config = await configApi.ObtenerConfiguracionPorCorreo(email);
        if (config != null)
        {
            AppState.setConfiguracion(config);
            await configApi.GuardarConfiguracionPorCorreo(email, config);
        }
        else
        {
            Log.Warn($"No se encontró configuración para el usuario {email}. Se establecerá la configuración predeterminada.");
            config = new ConfiguracionModel { SendNotifications = true };
            AppState.setConfiguracion(config);
            await configApi.GuardarConfiguracionPorCorreo(email, config);
        }
    }
}