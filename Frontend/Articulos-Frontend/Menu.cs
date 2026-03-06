namespace Articulos_Frontend
{
    public partial class Menu : Form
    {
        private ArticuloForm articuloForm;
        private ClienteForm clienteForm;
        public Menu()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(articuloForm == null || articuloForm.IsDisposed)
                articuloForm = new ArticuloForm();
            articuloForm.Show();
            articuloForm.BringToFront();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clienteForm == null || clienteForm.IsDisposed)
                clienteForm = new ClienteForm();

            clienteForm.Show();
            clienteForm.BringToFront();
        }
    }
}
