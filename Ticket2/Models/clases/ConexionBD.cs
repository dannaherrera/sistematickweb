using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SistemaTickets.Models.Clases
{
    public class ConexionBD
    {

        private static readonly string _connectionString;

        static ConexionBD()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["DefaultControl"]
                .ConnectionString;
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_connectionString);
        }

        public static bool Validar(string usuario, string contraseña)
        {
            bool respuesta = false;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.usp_ValidarUsuario", oconexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                        oconexion.Open();

                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null && Convert.ToInt32(resultado) == 1)
                        {
                            respuesta = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al validar el usuario: " + ex.Message);
            }

            return respuesta;
        }
    }
}

