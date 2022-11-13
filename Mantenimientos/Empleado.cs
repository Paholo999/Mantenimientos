using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Mantenimientos
{
    public class Empleado : Conexion
    {
        int             idEmpleado;
        string          nombres;
        string          apellidos;
        string          direccion;
        string          telefono;
        string          email;
        SqlCommand      cmd = new SqlCommand();         // forma 1
        DataTable       dt  = new DataTable();          // forma 1
        SqlDataAdapter  da  = new SqlDataAdapter();     // forma 1
        //SqlCommand      cmd ;      // forma 2
        //DataTable       dt  ;      // forma 2
        //SqlDataAdapter  da ;       // forma 2

            
        int res;

        public Empleado()
        {
        }

        public int IdEmpleado
        {   
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }
        public string Nombres
        {
            get {return nombres;}
            set {nombres = value;}
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Eliminados el empleado en la BD por medio de su identificador (IdEmpleado)
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int Eliminar(string idEmpleado)
        {
            res = 0;
            cmd = new SqlCommand(@"delete empleado where idEmpleado = @idEmpleado", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);

            try
            {
                Abrir_cn();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Cerrar_cn();
                cmd.Dispose();
            }
            return res;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Grabamos el empleado en la BD, recibimos como parámetro un objeto de tipo empleado
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int Grabar(Empleado em)
        {
            res = 0;
            cmd = new SqlCommand(@"Insert into Empleado (nombres, apellidos, direccion,telefono, email) 
                values(@nombres, @apellidos, @direccion, @telefono, @email)", cn);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@nombres", em.Nombres);
            cmd.Parameters.AddWithValue("@apellidos", em.Apellidos);
            cmd.Parameters.AddWithValue("@direccion", em.Direccion);
            cmd.Parameters.AddWithValue("@telefono", em.Telefono);
            cmd.Parameters.AddWithValue("@email", em.Email);

            try
            {
                Abrir_cn();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            finally
            {
                Cerrar_cn();
                cmd.Dispose();
            }

            return res;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Actualizamos el empleado en la BD, recibimos como parámetro un objeto de tipo empleado
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int Actualizar(Empleado em)
        {
            res = 0;
            cmd = new SqlCommand(@"update empleado set 
                    nombres     = @nombres   ,
                    apellidos   = @apellidos ,
                    direccion   = @direccion ,
                    telefono    = @telefono  ,
                    email       = @email
                    where idEmpleado = @idEmpleado",cn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@idEmpleado", em.idEmpleado);
            cmd.Parameters.AddWithValue("@nombres", em.Nombres);
            cmd.Parameters.AddWithValue("@apellidos", em.Apellidos);
            cmd.Parameters.AddWithValue("@direccion", em.Direccion);
            cmd.Parameters.AddWithValue("@telefono", em.Telefono);
            cmd.Parameters.AddWithValue("@email", em.Email);

            try
            {
                Abrir_cn();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            finally
            {
                Cerrar_cn();
                cmd.Dispose();
            }
            return res;

        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Obtenemos algunos o todos los registros de la BD dependiendo el filtro de la consulta.
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable Consultar_todos(string strFiltro)
        {
            try
            {
                strFiltro = strFiltro.Trim();
                if (strFiltro=="TODOS")
                { 
                    cmd = new SqlCommand(@"select idEmpleado,nombres,apellidos,direccion,telefono,email
                                         from empleado order by idEmpleado", cn);
                } else
                {
                    cmd = new SqlCommand(@"select idEmpleado,nombres,apellidos,direccion,telefono,email
                                         from empleado where " + strFiltro + " order by idEmpleado", cn);


                }
                da = new SqlDataAdapter();
                dt = new DataTable();
                cmd.CommandType = CommandType.Text;

                Abrir_cn();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw new System.Exception(e.Message);
            }

            finally
            {
                Cerrar_cn();
                cmd.Dispose();
            }
            return dt;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Obtenemos los datos de un empleado 
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable Consultar(int IdEmpleado)
        {
            try
            {
                //cmd = new SqlCommand(@"select idEmpleado,nombres,apellidos,direccion,telefono,email
                //                     from empleado
                //                     where idEmpleado = @empleado",cn);   //forma 2 
                cmd.Connection = cn;  //forma 1
                cmd.CommandText = (@"select idEmpleado,nombres,apellidos,direccion,telefono,email from empleado where idEmpleado = @empleado"); //forma 1

                //da = new SqlDataAdapter();  //forma 2
                //dt = new DataTable(); //forma 2
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@empleado", IdEmpleado);

                Abrir_cn();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }

            catch (Exception e)
            {
                //throw new System.Exception(e.Message);
                MessageBox.Show(e.Message);
             }
            finally
            {
                Cerrar_cn();
                cmd.Dispose();
            }
            return dt;
        }


    }
}
