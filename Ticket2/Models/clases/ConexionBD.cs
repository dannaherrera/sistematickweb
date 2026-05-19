using System.Configuration;
using System.Data.SqlClient;

namespace SistemaTickets.Models.Clases
{

    public class ConexionBD
    {

        private readonly string _connectionString;
        public ConexionBD()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_connectionString);
        }
    }
}


