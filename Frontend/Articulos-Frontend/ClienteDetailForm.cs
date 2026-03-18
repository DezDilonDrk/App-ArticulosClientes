
using Articulos_Frontend.Client;
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
    public ClienteDetailForm(Cliente cliente)
    {
        InitializeComponent();
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
        LabelDni.AutoSize = true;
        LabelDni.BackColor = Color.Transparent;
        LabelDni.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        LabelDni.Location = new Point(149, 92);
        LabelDni.Name = "LabelDni";
        LabelDni.Size = new Size(45, 21);
        LabelDni.TabIndex = 4;
        LabelDni.Text = "Dni: ";
        LabelDni.TextAlign = ContentAlignment.MiddleRight;
        // 
        // LabelNombre
        // 
        LabelNombre.AutoSize = true;
        LabelNombre.BackColor = Color.Transparent;
        LabelNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        LabelNombre.Location = new Point(115, 121);
        LabelNombre.Name = "LabelNombre";
        LabelNombre.Size = new Size(81, 21);
        LabelNombre.TabIndex = 5;
        LabelNombre.Text = "Nombre: ";
        LabelNombre.TextAlign = ContentAlignment.MiddleRight;
        // 
        // LabelApellidos
        // 
        LabelApellidos.AutoSize = true;
        LabelApellidos.BackColor = Color.Transparent;
        LabelApellidos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        LabelApellidos.Location = new Point(104, 150);
        LabelApellidos.Name = "LabelApellidos";
        LabelApellidos.Size = new Size(90, 21);
        LabelApellidos.TabIndex = 6;
        LabelApellidos.Text = "Apellidos: ";
        LabelApellidos.TextAlign = ContentAlignment.MiddleRight;
        // 
        // LabelEmail
        // 
        LabelEmail.AutoSize = true;
        LabelEmail.BackColor = Color.Transparent;
        LabelEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        LabelEmail.Location = new Point(135, 179);
        LabelEmail.Name = "LabelEmail";
        LabelEmail.Size = new Size(61, 21);
        LabelEmail.TabIndex = 7;
        LabelEmail.Text = "Email: ";
        LabelEmail.TextAlign = ContentAlignment.MiddleRight;
        // 
        // BotonCrearC
        // 
        BotonCrearC.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        BotonCrearC.AutoSize = true;
        BotonCrearC.BackColor = SystemColors.MenuHighlight;
        BotonCrearC.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        BotonCrearC.ForeColor = SystemColors.ControlLightLight;
        BotonCrearC.Location = new Point(301, 246);
        BotonCrearC.Name = "BotonCrearC";
        BotonCrearC.Size = new Size(150, 30);
        BotonCrearC.TabIndex = 5;
        BotonCrearC.Text = "Crear";
        BotonCrearC.UseVisualStyleBackColor = false;
        BotonCrearC.Click += BotonCrearC_Click;
        BotonCrearC.MouseEnter += Boton_MouseEnter;
        BotonCrearC.MouseLeave += Boton_MouseLeave;
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
        LabelTitulo.Text = "Crear Cliente";
        LabelTitulo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // button1
        // 
        button1.BackColor = Color.Chartreuse;
        button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        button1.ForeColor = SystemColors.ActiveCaptionText;
        button1.Location = new Point(104, 250);
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
        Text = "Crear Cliente";
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
                    MessageBox.Show("El DNI introducido ya existe. Por favor, introduzca un DNI único.", "DNI duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                existeDni = false;
            }
            if (existeDni) return;
            Cliente cliente = new Cliente(textBoxDni.Text.ToUpper(), textBoxNombre.Text, textBoxApellidos.Text, textBoxEmail.Text.ToLower(), DateTime.Now, null);
            clienteApiClient.Crear(cliente);
            MessageBox.Show("Cliente creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClienteCreadoCorrectamente?.Invoke(cliente);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al crear el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private bool validarCamposLlenos()
    {
        if (!string.IsNullOrEmpty(textBoxDni.Text) && !string.IsNullOrEmpty(textBoxNombre.Text) && !string.IsNullOrEmpty(textBoxApellidos.Text) && !string.IsNullOrEmpty(textBoxEmail.Text))
        {
            return true;
        }
        MessageBox.Show("Por favor, rellene todos los campos para crear el cliente.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }
    private bool ValidarEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
            this.Close();
        }
        catch
        {
            MessageBox.Show("Por favor, introduzca un email válido con el formato: {usuario}@{proveedor}.{dominio}", "Email no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
    }
    private bool ValidarDni(string dni)
    {
        if (textBoxDni.Text.Length != 9)
        {
            MessageBox.Show("El DNI debe tener 9 caracteres, 8 números y una letra mayúscula al final. Ejemplo: 12345678A", "DNI no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(dni, @"^\d{8}[A-Za-z]$"))
        {
            MessageBox.Show("El DNI debe tener 9 caracteres, 8 números y una letra mayúscula al final. Ejemplo: 12345678A", "DNI no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
        int numero;
        try
        { numero = int.Parse(dni.Substring(0, 8)); }
        catch
        {
            MessageBox.Show("Los primeros 8 caracteres del DNI deben ser números. Ejemplo: 12345678A", "DNI no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        char letraCalculada = letras[numero % 23];
        if (char.ToUpper(dni[8]) != letraCalculada)
        {
            MessageBox.Show("La letra del DNI no es correcta. Ejemplo: 12345678A", "DNI no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }
    public Cliente getCliente()
    {
        return this.cliente;
    }
    private void Boton_MouseEnter(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (btn != null)
        {
            btn.BackColor = Color.LightSkyBlue;
            btn.ForeColor = Color.RoyalBlue;
        }
    }
    private void Boton_MouseLeave(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (btn != null)
        {
            btn.BackColor = Color.DodgerBlue;
            btn.ForeColor = SystemColors.ControlLightLight;
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        this.textBoxNombre.Text = "Federico";
        this.textBoxApellidos.Text = "Pérez García";
        this.textBoxDni.Text = "12345678Z";
        this.textBoxEmail.Text = "federicogarcia@gmail.com";
    }
}