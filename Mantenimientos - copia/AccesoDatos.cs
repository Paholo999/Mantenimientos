using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Mantenimientos
{
    class AccesoDatos: Conexion
    {

        public int SqlCommand(string strSql)
        {
            SqlCommand sqlCmd = new SqlCommand();
            int Resultado = 0;

            sqlCmd.CommandText = strSql;
            sqlCmd.Connection = cn;

            try
            {
                Abrir_cn();
                sqlCmd.ExecuteNonQuery();
                Resultado = 1;
            }
            catch
            {
                throw new Exception();
                Resultado = 0;
            }

            finally
            {
                Cerrar_cn();
                sqlCmd.Dispose();
            }

            return Resultado;
        }

        public DataTable Datos(string strSql)
        {
            SqlCommand sqlCmd = new SqlCommand();
            DataTable dts = new DataTable();

            sqlCmd.CommandText = strSql;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Connection = cn;

            SqlDataAdapter sqlda = new SqlDataAdapter(sqlCmd);

            try
            {
                Abrir_cn();
                sqlda.Fill(dts);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                Cerrar_cn();
                sqlCmd.Dispose();
            }

            return dts;

        }

    }



}

