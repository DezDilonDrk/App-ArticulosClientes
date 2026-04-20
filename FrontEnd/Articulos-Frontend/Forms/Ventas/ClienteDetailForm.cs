
using Articulos_Frontend.Client;
using Articulos_Frontend.LogConfig;
using Articulos_Frontend.Theme;
using MTCore_AC.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Articulos_Frontend;

public partial class ClienteDetailForm : Form
{
    private ClienteApiClient clienteApiClient;
    private Cliente cliente;
    public event Action<Cliente> ClienteCreadoCorrectamente;
    private StringValuesSP stringValuesSP = new StringValuesSP();
    public ClienteDetailForm(Cliente cliente)
    {
        InitializeComponent();
        Text = stringValuesSP.crearCliente;
        LabelTitulo.Text = stringValuesSP.crearCliente;
        this.cliente = cliente;
        string connStr = "Server=localhost;Database=PracticasDB;Trusted_Connection=True;TrustServerCertificate=True;";
        clienteApiClient = new ClienteApiClient();
        StyleManager.StyleForm(this);
    }


    private void InitializeComponent()
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(ClienteDetailForm));
        textBoxDni = new TextBox();
        textBoxNombre = new TextBox();
        textBoxApellidos = new TextBox();
        textBoxEmail = new TextBox();
        LabelDni = new Label();
        LabelNombre = new Label();
        LabelApellidos = new Label();
        LabelEmail = new Label();
        BotonCrearC = new Button();
        LabelTitulo = new Label();
        button1 = new Button();
        SuspendLayout();
        // 
        // textBoxDni
        // 
        textBoxDni.Location = new Point(204, 92);
        textBoxDni.Name = "textBoxDni";
        textBoxDni.PlaceholderText = "Introduzca el dni";
        textBoxDni.Size = new Size(247, 23);
        textBoxDni.TabIndex = 0;
        // 
        // textBoxNombre
        // 
        textBoxNombre.Location = new Point(204, 121);
        textBoxNombre.Name = "textBoxNombre";
        textBoxNombre.PlaceholderText = "Introduzca el nombre";
        textBoxNombre.Size = new Size(247, 23);
        textBoxNombre.TabIndex = 1;
        // 
        // textBoxApellidos
        // 
        textBoxApellidos.Location = new Point(204, 150);
        textBoxApellidos.Name = "textBoxApellidos";
        textBoxApellidos.PlaceholderText = "Introduzca el/los apellidos";
        textBoxApellidos.Size = new Size(247, 23);
        textBoxApellidos.TabIndex = 2;
        // 
        // textBoxEmail
        // 
        textBoxEmail.Location = new Point(204, 179);
        textBoxEmail.Name = "textBoxEmail";
        textBoxEmail.PlaceholderText = "Introduzca el email";
        textBoxEmail.Size = new Size(247, 23);
        textBoxEmail.TabIndex = 3;
        // 
        // LabelDni
        // 
        LabelDni.BackColor = Color.Transparent;
        LabelDni.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        LabelDni.Location = new Point(104, 92);
        LabelDni.Name = "LabelDni";
        LabelDni.Size = new Size(90, 21);
        LabelDni.TabIndex = 4;
        LabelDni.Tag = "normalText";
        LabelDni.Text = "Dni: ";
        LabelDni.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // LabelNombre
        // 
        LabelNombre.BackColor = Color.Transparent;
        LabelNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        LabelNombre.Location = new Point(104, 121);
        LabelNombre.Name = "LabelNombre";
        LabelNombre.Size = new Size(90, 21);
        LabelNombre.TabIndex = 5;
        LabelNombre.Tag = "normalText";
        LabelNombre.Text = "Nombre: ";
        LabelNombre.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // LabelApellidos
        // 
        LabelApellidos.BackColor = Color.Transparent;
        LabelApellidos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        LabelApellidos.Location = new Point(104, 150);
        LabelApellidos.Name = "LabelApellidos";
        LabelApellidos.Size = new Size(94, 21);
        LabelApellidos.TabIndex = 6;
        LabelApellidos.Tag = "normalText";
        LabelApellidos.Text = "Apellidos: ";
        LabelApellidos.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // LabelEmail
        // 
        LabelEmail.BackColor = Color.Transparent;
        LabelEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        LabelEmail.Location = new Point(104, 179);
        LabelEmail.Name = "LabelEmail";
        LabelEmail.Size = new Size(94, 21);
        LabelEmail.TabIndex = 7;
        LabelEmail.Tag = "normalText";
        LabelEmail.Text = "Email: ";
        LabelEmail.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // BotonCrearC
        // 
        BotonCrearC.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        BotonCrearC.AutoSize = true;
        BotonCrearC.BackColor = SystemColors.MenuHighlight;
        BotonCrearC.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        BotonCrearC.ForeColor = SystemColors.ControlLightLight;
        BotonCrearC.Location = new Point(301, 247);
        BotonCrearC.Name = "BotonCrearC";
        BotonCrearC.Size = new Size(150, 30);
        BotonCrearC.TabIndex = 5;
        BotonCrearC.Text = "Crear";
        BotonCrearC.UseVisualStyleBackColor = false;
        BotonCrearC.Click += BotonCrearC_Click;
        // 
        // LabelTitulo
        // 
        LabelTitulo.BackColor = Color.Transparent;
        LabelTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        LabelTitulo.Location = new Point(135, 18);
        LabelTitulo.Name = "LabelTitulo";
        LabelTitulo.Size = new Size(316, 36);
        LabelTitulo.TabIndex = 0;
        LabelTitulo.Tag = "title";
        LabelTitulo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // button1
        // 
        button1.BackColor = Color.Chartreuse;
        button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        button1.ForeColor = SystemColors.ActiveCaptionText;
        button1.Location = new Point(104, 251);
        button1.Name = "button1";
        button1.Size = new Size(90, 23);
        button1.TabIndex = 8;
        button1.Text = "debug";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // ClienteDetailForm
        // 
        ClientSize = new Size(580, 363);
        Controls.Add(button1);
        Controls.Add(LabelTitulo);
        Controls.Add(BotonCrearC);
        Controls.Add(LabelEmail);
        Controls.Add(LabelApellidos);
        Controls.Add(LabelNombre);
        Controls.Add(LabelDni);
        Controls.Add(textBoxEmail);
        Controls.Add(textBoxApellidos);
        Controls.Add(textBoxNombre);
        Controls.Add(textBoxDni);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MaximumSize = new Size(596, 402);
        MinimumSize = new Size(596, 402);
        Name = "ClienteDetailForm";
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);
        PerformLayout();

    }

    private async void BotonCrearC_Click(object sender, EventArgs e)
    {
        if (!validarCamposLlenos() || !ValidarDni(textBoxDni.Text) || !ValidarEmail(textBoxEmail.Text)) return;
        try
        {
            bool existeDni = false;
            try
            {
                Cliente comprobar = await clienteApiClient.ObtenerPorDni(textBoxDni.Text.ToUpper());
                if (comprobar != null)
                {
                    existeDni = true;
                    Log.Warn($"Intento de crear cliente con DNI duplicado: {textBoxDni.Text.ToUpper()}.");
                    Alerta alertaa = new Alerta(Alerta.AlertaTipo.Error, new DuplicateNameException("Cliente duplicado"));
                    alertaa.ShowDialog();
                    return;
                }
            }
            catch (Exception ex)
            {
                existeDni = false;
            }
            if (existeDni) return;
            Cliente cliente = new Cliente(textBoxDni.Text.ToUpper(), textBoxNombre.Text, textBoxApellidos.Text, textBoxEmail.Text.ToLower(), DateTime.Now, null);
            clienteApiClient.Crear(cliente);
            EmailSender emailSender = new EmailSender();
            emailSender.SendEmail("leandro.santilario@mthelmets.com", "Bienvenido a nuestro servicio", $"Hola {cliente.Nombre},\n\nGracias por registrarte en nuestro servicio. Estamos encantados de tenerte con nosotros.\n\nSaludos cordiales,\nEl equipo de MTHelmets-AC");
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Info, new Exception("Se ha creado el articulo correctamente"));
            alerta.ShowDialog();
            if (alerta.resultado)
            {
                this.Close();
            }
            else
            {
                this.Close();
            }
            ClienteCreadoCorrectamente?.Invoke(cliente);
        }
        catch (Exception ex)
        {
            Log.Error($"Error al crear el cliente: {ex.Message}", ex);
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
            alerta.ShowDialog();
            if (alerta.resultado)
            {
                return;
            }
            else
            {
                return;
            }
            
        }
    }
    private bool validarCamposLlenos()
    {
        if (!string.IsNullOrEmpty(textBoxDni.Text) && !string.IsNullOrEmpty(textBoxNombre.Text) && !string.IsNullOrEmpty(textBoxApellidos.Text) && !string.IsNullOrEmpty(textBoxEmail.Text))
        {
            return true;
        }
        Log.Warn("Intento de crear cliente con campos incompletos.");
        Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new MissingFieldException("Campos sin rellenar"));
        alerta.ShowDialog();
        if (alerta.resultado)
        {
            return false;
        }
        return false;
    }
    private bool ValidarEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            Log.Warn($"Intento de crear cliente con email no válido: {email}.");
            Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, new DuplicateNameException("Formato {usuario}@{proveedor}.{dominio} erroneo\", \"Email no válido"));
            alerta.ShowDialog();
            if (alerta.resultado)
            {
                return false;
            }
            return false;
        }
    }
    private bool ValidarDni(string dni)
    {
        if (textBoxDni.Text.Length != 9)
        {
            Log.Warn($"Intento de crear cliente con DNI de longitud incorrecta: {dni}.");
            MessageBox.Show("El DNI debe tener 9 caracteres, 8 números y una letra mayúscula al final. Ejemplo: 12345678A", "DNI no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(dni, @"^\d{8}[A-Za-z]$"))
        {
            Log.Warn($"Intento de crear cliente con DNI con formato incorrecto: {dni}.");
            MessageBox.Show("El DNI debe tener 9 caracteres, 8 números y una letra mayúscula al final. Ejemplo: 12345678A", "DNI no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
        int numero;
        try
        { numero = int.Parse(dni.Substring(0, 8)); }
        catch
        {
            Log.Warn($"Intento de crear cliente con DNI cuyos primeros 8 caracteres no son numéricos: {dni}.");
            MessageBox.Show("Los primeros 8 caracteres del DNI deben ser números. Ejemplo: 12345678A", "DNI no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        char letraCalculada = letras[numero % 23];
        if (char.ToUpper(dni[8]) != letraCalculada)
        {
            Log.Warn($"Intento de crear cliente con DNI cuya letra ({letraCalculada}) no coincide con el número: {dni}.");
            MessageBox.Show("La letra del DNI no es correcta. Ejemplo: 12345678A", "DNI no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }
    public Cliente getCliente()
    {
        return this.cliente;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Log.Info("Rellenando campos de cliente con la opción debug.");
        this.textBoxNombre.Text = "Federico";
        this.textBoxApellidos.Text = "Pérez García";
        this.textBoxDni.Text = "12345678Z";
        this.textBoxEmail.Text = "federicogarcia@gmail.com";
    }
}