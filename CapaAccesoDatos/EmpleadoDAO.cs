using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatos
{
    class EmpleadoDAO
    {
        #region "PATRON SINGLETON"
        private static EmpleadoDAO daoEmpleado = null;
        private EmpleadoDAO ()
        {

        }
        public static EmpleadoDAO getInstance ()
        {
            if (daoEmpleado == null)
            {
                daoEmpleado = new EmpleadoDAO();
            }
            return daoEmpleado;
        }
        #endregion

        public Empleado AccesoSistema(String user, String pass)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Empleado objEmpleado = null;
            SqlDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spAccesoSistema", conexion);
            }
            catch (Exception e)
            {

            }
            finally
            {

            }
        }
    }
}
