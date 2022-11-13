using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Mantenimientos
{
    public class Conexion
    {
        public static SqlConnection cn;

        
        public Conexion()
        {
            cn = new SqlConnection("Server=DESKTOP-UFN58GD;Database=Hospital1;Trusted_Connection=True;");
        }

        public void Abrir_cn()
        {
            try
            {
                if (cn.State == ConnectionState.Broken || cn.State == ConnectionState.Closed)
                    cn.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Cerrar_cn()
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }



    }


}

