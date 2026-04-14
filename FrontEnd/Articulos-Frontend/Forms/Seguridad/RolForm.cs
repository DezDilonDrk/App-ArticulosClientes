using Articulos_Frontend.Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Articulos_Frontend.LogConfig;
using Articulos_Frontend.Client;

namespace Articulos_Frontend.Forms.Seguridad
{
    public partial class RolForm : Form
    {
        RolApiClient api;
        public RolForm(RolApiClient apiRol)
        {
            InitializeComponent();
            StyleManager.StyleForm(this);
            Log.Info("Formulario de rol iniciado.");
            api = apiRol;
            MinimumSize = new Size(800, 600);
        }

        public void RolForm_Load(object sender, EventArgs e)
        {
            cargarRoles();
        }

        public async void cargarRoles()
        {
            var roles = await api.ObtenerRoles();
            if (roles != null)
            {
                dataGridViewRoles.DataSource = roles;
            }
        }

        public void dataGridViewRoles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridViewRoles.Columns.Contains("colVacia"))
            {
                dataGridViewRoles.Columns.Remove("colVacia");
            }
            if (dataGridViewRoles.Columns.Count == 0) return;
            
            dataGridViewRoles.Columns[0].Width = 40;
            dataGridViewRoles.Columns[1].Width = 140;
            dataGridViewRoles.Columns[2].Width = 400;

            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = "colVacia";
            col.HeaderText = "";
            dataGridViewRoles.Columns.Add(col);
            dataGridViewRoles.Columns["colVacia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
