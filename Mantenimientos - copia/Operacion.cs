using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Mantenimientos
{
    class Operacion: Conexion
    {
        public SqlCommand cmd;
        public DataTable dt;
        public SqlDataAdapter da;

        
    }
}
