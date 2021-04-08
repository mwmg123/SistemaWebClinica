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

        // Mostrar pacientes en una tabla.
        public List<Paciente> listarPacientes ()
        {
            List<Paciente> Lista = new List<Paciente>();

            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarPacientes", con);
                cmd.CommandType = CommandType.StoredProcedure;

                dr = cmd.ExecuteReader();

                // Mientras se encuentre datos (filas en la base de datos) por leer hacer lo siguiente.
                while (dr.Read())
                {
                    // Crear Objetos de tipo paciente
                    Paciente objPaciente = new Paciente();
                    objPaciente.IdPaciente = Convert.ToInt32(dr["idPaciente"].ToString());
                    objPaciente.Nombres = dr["nombres"].ToString();
                    objPaciente.ApPaterno = dr["apPaterno"].ToString();
                    objPaciente.ApMaterno = dr["apMaterno"].ToString();
                    objPaciente.Edad = Convert.ToInt32(dr["edad"].ToString());
                    objPaciente.Sexo = Convert.ToChar(dr["sexo"].ToString());
                    objPaciente.NroDocumento = dr["nroDocumento"].ToString();
                    objPaciente.Direccion = dr["direccion"].ToString();
                    objPaciente.Estado = true;

                    // Añadir a la lista de objetos
                    Lista.Add(objPaciente);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return Lista;
        }
    }
}
