using Mantenimientos.Modelo;
using Mantenimientos.Modelo.Dao;
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
    public partial class formEmpleado : Form, IContract
    {
        EmpleadoDao empDao = new EmpleadoDao();

        public formEmpleado()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtEmpleado.Text = Convert.ToString(empDao.Id());
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Habilitamos/Deshabilitamos botones
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            btnNuevo.Enabled        = false;
            btnEditar.Enabled       = false;
            btnGrabar.Enabled       = true;
            btnCancelar.Enabled     = true;
            btnBuscar.Enabled       = false;
            btnEliminar.Enabled     = false;

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Habilitamos/Deshabilitamos textbox
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            txtEmpleado.Enabled     = false;
            txtNombres.Enabled      = true;
            txtApellidos.Enabled    = true;
            txtDireccion.Enabled    = true;
            txtTelefono.Enabled     = true;
            txtEmail.Enabled        = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Habilitamos/Deshabilitamos botones
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            btnNuevo.Enabled        = false;
            btnEditar.Enabled       = false;
            btnGrabar.Enabled       = true;
            btnCancelar.Enabled     = true;
            btnBuscar.Enabled       = false;
            btnEliminar.Enabled     = false;


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Habilitamos/Deshabilitamos textbox
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            txtEmpleado.Enabled     = false;
            txtNombres.Enabled      = true;
            txtApellidos.Enabled    = true;
            txtDireccion.Enabled    = true;
            txtTelefono.Enabled     = true;
            txtEmail.Enabled        = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Validamos que se hayan ingresado los datos en los textbox
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (txtNombres.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese un nombre", "validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtApellidos.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese un apellido", "validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Asignamos los valores de los textbox a la clase Empleado
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Modelo.Empleado em = new Modelo.Empleado();
            EmpleadoDao empDao = new EmpleadoDao();
            DataTable dt = new DataTable();

            if (txtEmpleado.Text == "" )
            {
                em.IdEmpleado = 0;
            } else
            {
                em.IdEmpleado = Convert.ToInt32(txtEmpleado.Text);
            }
            em.Nombre      = txtNombres.Text;
            em.Apellidos    = txtApellidos.Text;
            em.Direccion    = txtDireccion.Text;
            em.Telefono     = txtTelefono.Text;
            em.Email        = txtEmail.Text;

            dt = empDao.ConsultById(em.IdEmpleado);

            if(dt.Rows.Count > 0) 
            {
                empDao.Update(em);
                MessageBox.Show("Datos actualizados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            { 
                empDao.Insert(em);
                MessageBox.Show("Datos grabados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Limpiar_campos();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Verificamos si ya existe el registro en la BD
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //dt = em.Consultar(em.IdEmpleado);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Si existe el empleado entonces actualizamos los datos
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*if (dt.Rows.Count > 0)
            {
                if (em.Actualizar(em) > 0)
                {
                    MessageBox.Show("Datos actualizados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se actualizaron los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Limpiar_campos();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Si no existe el empleado entoces los grabados en la BD
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            else
            {
                if (em.Grabar(em) > 0)
                {
                    MessageBox.Show("Datos grabados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se grabaron los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Limpiar_campos();
            }*/


        }

        private void formEmpleado_Load(object sender, EventArgs e)
        {
            Limpiar_campos();
        }

        private void Limpiar_campos()
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Limpiamos los textbox
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            txtEmpleado.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //habilitamos/deshabilitamos los botones
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            btnNuevo.Enabled    = true;
            btnEditar.Enabled   = false;
            btnGrabar.Enabled   = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled   = true;
            btnEliminar.Enabled = false;

            Bloquear_Campos();

        }
        private void Bloquear_Campos()
        {

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Inhabilitamos los textbox
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            txtEmpleado.Enabled     = false;
            txtNombres.Enabled      = false;
            txtApellidos.Enabled    = false;
            txtDireccion.Enabled    = false;
            txtTelefono.Enabled     = false;
            txtEmail.Enabled        = false;
        }

        public void Empleado_Mostrar(Modelo.Empleado em)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Asignamos valores de la clase a los textbox desde una forma externa
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            txtEmpleado.Text    = Convert.ToString(em.IdEmpleado);
            txtNombres.Text     = em.Nombre;
            txtApellidos.Text   = em.Apellidos;
            txtDireccion.Text   = em.Direccion;
            txtTelefono.Text    = em.Telefono;
            txtEmail.Text       = em.Email;

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Habilitamos/Deshabilitamos botones
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            btnNuevo.Enabled    = true;
            btnEditar.Enabled   = true;
            btnGrabar.Enabled   = false;
            btnCancelar.Enabled = false;
            btnBuscar.Enabled   = true;
            btnEliminar.Enabled = true;

        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Eliminamos registro en tabla empleado
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string strMsj = "Está seguro de eliminar el empleado [" + Convert.ToString(txtEmpleado.Text) + "] "
                +  Convert.ToString(txtNombres.Text) + " " + Convert.ToString(txtApellidos.Text) + " ?";

            EmpleadoDao empDao = new EmpleadoDao();

            if (MessageBox.Show(strMsj, "validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                empDao.Delete(Convert.ToInt16(txtEmpleado.Text));
                MessageBox.Show("Datos eliminados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar_campos();
            }
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar_campos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            formBusquedaTipo formBusquedaTipo = new formBusquedaTipo();
            formBusquedaTipo.Contrato = this;
            formBusquedaTipo.ShowDialog();
        }
    }
}
