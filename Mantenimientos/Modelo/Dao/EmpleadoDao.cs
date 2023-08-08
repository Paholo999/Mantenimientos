using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mantenimientos.Modelo.Dao
{
    public class EmpleadoDao
    {
        DataClasses1DataContext dblib = new DataClasses1DataContext();
        DataTable dt;

        public void Insert(Empleado em)
        {
            dblib.Empleados.InsertOnSubmit(em);
            dblib.SubmitChanges();
        }

        public int Id()
        {
            int id = dblib.Empleados.Count();

            return id + 1;
        }

        public DataTable ConsultById(int id)
        {
            dt = new DataTable();
            try
            {
                
            
                var empleado = dblib.Empleados.Where(emp => emp.IdEmpleado == id).FirstOrDefault();

                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Nombres", typeof(string));
                dt.Columns.Add("Apellidos", typeof(string));
                dt.Columns.Add("Direccion", typeof(string));
                dt.Columns.Add("Telefono", typeof(string));
                dt.Columns.Add("Email", typeof(string));

                if (empleado != null)
                {
                    dt.Rows.Add(empleado.IdEmpleado, empleado.Nombre, empleado.Apellidos, empleado.Direccion, empleado.Telefono, empleado.Email);
                }
                

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public DataTable ConsultByDescription(string nombres, string apellidos) 
        {
            dt = new DataTable();

            try
            {


                var empleado = dblib.Empleados.Where(emp => emp.Nombre==nombres && emp.Apellidos==apellidos).FirstOrDefault();

                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Nombres", typeof(string));
                dt.Columns.Add("Apellidos", typeof(string));
                dt.Columns.Add("Direccion", typeof(string));
                dt.Columns.Add("Telefono", typeof(string));
                dt.Columns.Add("Email", typeof(string));

                if (empleado != null)
                {
                    dt.Rows.Add(empleado.IdEmpleado, empleado.Nombre, empleado.Apellidos, empleado.Direccion, empleado.Telefono, empleado.Email);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

        public DataTable ConsultAll()
        {
            dt = new DataTable();
            try
            {


                var empleadoList = dblib.Empleados.ToList();
             

                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Nombres", typeof(string));
                dt.Columns.Add("Apellidos", typeof(string));
                dt.Columns.Add("Direccion", typeof(string));
                dt.Columns.Add("Telefono", typeof(string));
                dt.Columns.Add("Email", typeof(string));

                foreach (Empleado empleado in empleadoList) 
                { 
                    dt.Rows.Add(empleado.IdEmpleado, empleado.Nombre, empleado.Apellidos, empleado.Direccion, empleado.Telefono, empleado.Email);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return dt;
        }

        public void Update(Empleado empleado) 
        { 

            try
            {
                Empleado empleadoupdate = dblib.Empleados.FirstOrDefault(em => em.IdEmpleado == empleado.IdEmpleado);


                if (empleado != null) 
                { 
                    empleadoupdate.Nombre = empleado.Nombre;
                    empleadoupdate.Apellidos = empleado.Apellidos;
                    empleadoupdate.Direccion = empleado.Direccion;
                    empleadoupdate.Telefono = empleado.Telefono;
                    empleadoupdate.Email = empleado.Email;

                    dblib.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        public void Delete(int id) 
        {
            try
            {
                Empleado empleadodelete = dblib.Empleados.FirstOrDefault(em => em.IdEmpleado == id);

                dblib.Empleados.DeleteOnSubmit(empleadodelete);

                dblib.SubmitChanges();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
