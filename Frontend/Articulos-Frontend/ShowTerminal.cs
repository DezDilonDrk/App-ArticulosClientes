using Articulos_Frontend.Theme;
using Articulos_Frontend.LogConfig;
using MTCore_AC.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Articulos_Frontend
{
    public partial class ShowTerminal : Form
    {
        public ShowTerminal()
        {
            InitializeComponent();
            StyleManager.StyleForm(this);
            Log.Info("El usuario ha abierto la terminal");
        }
    }
}
