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

        public void Menu_Load(object sender, EventArgs e)
        {
            WindowManager.OnWindowsChanged += RefrescarMenuVentanas;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string key = "ArticuloForm";

            WindowManager.ShowForm(key, this, () =>
            {
                var form = new ArticuloForm();

                form.Width = this.Width - 20;
                form.Height = this.Height - 140;
                form.Shown += (s, ev) =>
                {
                    form.Location = new Point(
                        this.Left + (this.Width - form.Width) / 2,
                        this.Top + (this.Height - form.Height) / 2
                    );
                };

                return form;
            });
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string key = "ClienteForm";

            WindowManager.ShowForm(key, this, () =>
            {
                var form = new ClienteForm();

                form.Width = this.Width - 20;
                form.Height = this.Height - 140;
                form.Shown += (s, ev) =>
                {
                    form.Location = new Point(
                        this.Left + (this.Width - form.Width) / 2,
                        this.Top + (this.Height - form.Height) / 2
                    );
                };

                return form;
            });
        }

        private void ventanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefrescarMenuVentanas();
        }

        private void RefrescarMenuVentanas()
        {
            ventanasToolStripMenuItem.DropDownItems.Clear();
            foreach(var kvp in WindowManager.OpenWindows)
            {
                var key = kvp.Key;
                var form = kvp.Value.formularioHijo;
                var item = new ToolStripMenuItem(form.Text);
                item.Click += (s, e) => WindowManager.Activate(key);
                var activeForm = Form.ActiveForm;
                item.Checked = (form == activeForm);

                ventanasToolStripMenuItem.DropDownItems.Add(item);
            }
        }
    }
}
