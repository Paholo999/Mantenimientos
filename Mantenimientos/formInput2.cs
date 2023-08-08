using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mantenimientos
{
    public partial class formInput2 : Form
    {
        public formInput2()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Modulo.strNombres = txtIngreso1.Text.Trim();
            Modulo.strApellidos = txtIngreso2.Text.Trim();
            this.Close();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
