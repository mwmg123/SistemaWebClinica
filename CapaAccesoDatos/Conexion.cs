using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class Conexion
    {
        #region "PATRON SINGLETON"
        private static Conexion conexion = null;
        private Conexion()
        {

        }
        // Retorna una conexion
        public static Conexion getInstance()
        {
            // Si no esta "instanciada" entonces crea un nuevo objeto de la clase conexion.
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }

        #endregion

        public SqlConnection ConexionBD()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "Data Source=DESKTOP-K03FTIO\\MWMG;Initial Catalog=DBClinica; Integrated Security = True";
            return conexion;
        }
    }
}
