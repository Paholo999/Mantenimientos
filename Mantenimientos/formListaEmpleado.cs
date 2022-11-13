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
    public partial class formListaEmpleado : Form
    {
        public formListaEmpleado()
        {
            InitializeComponent();
        }


        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formListaEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLista_DoubleClick(object sender, EventArgs e)
        {


        }

        private void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            Modulo.strSeleccion = dgvLista.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            this.Close();
        }
    }
}
