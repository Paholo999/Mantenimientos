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
    public partial class formBusquedaTipo : Form
    {
        public IContract Contrato { get; set; }

        public formBusquedaTipo()
        {
            InitializeComponent();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            formInput formInput = new formInput();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Se ha seleccionado la busqueda por codigo de empleado
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (rdbCodigo.Checked) 
            {
                Modulo.strDescrip = "";
                formInput.lblMensaje.Text = "Ingrese Codigo: ";
                formInput.ShowDialog();
                if (Modulo.strDescrip.Trim() == "")
                {
                    return;
                }


                DataTable dt   = new DataTable();
                Empleado  em   = new Empleado();

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Se realiza la busqueda del empleado en la BD por IdEmpleado, si existe se muestran sus datos.
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                em.IdEmpleado = Convert.ToInt32(Modulo.strDescrip);

                dt = em.Consultar(em.IdEmpleado);
                if (dt.Rows.Count > 0 )
                {
                    em.Nombres      = dt.Rows[0]["Nombres"].ToString()  ;
                    em.Apellidos    = dt.Rows[0]["Apellidos"].ToString();
                    em.Direccion    = dt.Rows[0]["Direccion"].ToString();
                    em.Telefono     = dt.Rows[0]["Telefono"].ToString() ;
                    em.Email        = dt.Rows[0]["Email"].ToString() ;
                    Contrato.Empleado_Mostrar(em);
                    this.Close();
                } else
                {
                    MessageBox.Show("Empleado no existe", "Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Se ha seleccionado la busqueda por descripción (nombres y apellidos)
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (rdbDescripcion.Checked)
            {
                Modulo.strDescrip = "";
                formInput.lblMensaje.Text = "Ingrese Descripción";
                formInput.ShowDialog();

                if (Modulo.strDescrip.Trim() == "") {
                    return;
                }


                DataTable dt = new DataTable();
                Empleado  em = new Empleado();

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Se realiza la busqueda del empleado en la BD por nombres+apellidos, si existe se muestran sus datos.
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                dt = em.Consultar_todos(" nombres + ' ' + apellidos like '%"+ Modulo.strDescrip + "%'");
                if (dt.Rows.Count > 0)
                {
                        Modulo.strSeleccion = "";
                        formListaEmpleado formListaEmpleado = new formListaEmpleado();
                        formListaEmpleado.dgvLista.DataSource = dt;
                        formListaEmpleado.ShowDialog();

                    if (Modulo.strSeleccion != "")
                     {
                        DataRow[] result = dt.Select("IdEmpleado = " + Modulo.strSeleccion);
                        foreach (DataRow row in result)
                        {
                            em.IdEmpleado   = Convert.ToInt32(row[0]);
                            em.Nombres      = Convert.ToString(row[1]);
                            em.Apellidos    = Convert.ToString(row[2]);
                            em.Direccion    = Convert.ToString(row[3]);
                            em.Telefono     = Convert.ToString(row[4]);
                            em.Email        = Convert.ToString(row[5]);
                            Contrato.Empleado_Mostrar(em);
                        }
                    }
                    this.Close();
                } else
                {
                    MessageBox.Show("No se encontró ninguna coincidencia.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Se muestran todos los empleados para que el usuario pueda seleccionar uno
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (rdbTodos.Checked) {
                Empleado em = new Empleado();
                DataTable dt = new DataTable();
                dt = em.Consultar_todos("TODOS");

                if (dt.Rows.Count > 0)
                {
                    Modulo.strSeleccion = "";
                    formListaEmpleado formListaEmpleado = new formListaEmpleado();
                    formListaEmpleado.dgvLista.DataSource = dt;
                    formListaEmpleado.ShowDialog();

                    if (Modulo.strSeleccion == "")
                    {
                        return;
                    }

                    DataRow[] result = dt.Select("IdEmpleado = " + Modulo.strSeleccion);
                    foreach (DataRow row in result)
                    {
                        em.IdEmpleado   = Convert.ToInt32(row[0]);
                        em.Nombres      = Convert.ToString(row[1]);
                        em.Apellidos    = Convert.ToString(row[2]);
                        em.Direccion    = Convert.ToString(row[3]);
                        em.Telefono     = Convert.ToString(row[4]);
                        em.Email        = Convert.ToString(row[5]);
                        Contrato.Empleado_Mostrar(em);
                        this.Close();
                    }
                } 


            }



         }

        private void formBusquedaTipo_Load(object sender, EventArgs e)
        {

        }
    }


    }

