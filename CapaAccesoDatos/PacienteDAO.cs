using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;

namespace CapaAccesoDatos
{
    public class PacienteDAO
    {
        #region "PATRON SINGLETON"
        private static PacienteDAO daoPaciente = null;
        private PacienteDAO () {  }

        public static PacienteDAO getInstance ()
        {
            if (daoPaciente == null)
            {
                daoPaciente = new PacienteDAO();
            }
            return daoPaciente;
        }
        #endregion

        public bool RegistrarPaciente (Paciente objPaciente)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarPaciente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@prmNombres", objPaciente.Nombres);
                cmd.Parameters.Add("@prmApPaterno", objPaciente.ApPaterno);
                cmd.Parameters.Add("@prmApMaterno", objPaciente.ApMaterno);
                cmd.Parameters.Add("@prmEdad", objPaciente.Edad);
                cmd.Parameters.Add("@prmSexo", objPaciente.Sexo);
                cmd.Parameters.Add("@prmNroDoc", objPaciente.NroDocumento);
                cmd.Parameters.Add("@prmDireccion", objPaciente.Direccion);
                cmd.Parameters.Add("@prmTelefono", objPaciente.Telefono);
                cmd.Parameters.Add("@prmEstado", objPaciente.Estado);

                con.Open();

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0) response = true;

            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return response;
        }
    }
}
