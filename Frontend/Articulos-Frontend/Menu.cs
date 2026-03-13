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
            articuloForm.Width = this.Width - 20;
            articuloForm.Height = this.Height - 140;
            articuloForm.Shown += (s, ev) =>
            {
                articuloForm.Location = new Point(
                    this.Left + (this.Width - articuloForm.Width) / 2,
                    this.Top + (this.Height - articuloForm.Height) / 2
                );
            };
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
