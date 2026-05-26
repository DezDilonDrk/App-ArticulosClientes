using Articulos_Frontend.Client;
using Articulos_Frontend.Theme;
using SesionMT;
using SesionMT.LogConfig;

namespace Articulos_Frontend.Forms.Seguridad
{
    public partial class RolForm : Form
    {
        RolApiClient api;
        StringValuesSP stringValuesSP = new StringValuesSP();
        public RolForm(RolApiClient apiRol)
        {
            InitializeComponent();
            StyleManager.StyleForm(this);
            Log.Info("Formulario de rol iniciado.");
            api = apiRol;
            labelRoles.Text = stringValuesSP.rolesUsuarios;
            MinimumSize = new Size(800, 600);
        }
        public async void RolForm_Load(object sender, EventArgs e)
        {
            await api.InitAsync(UrlMT.serverLocal);
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
