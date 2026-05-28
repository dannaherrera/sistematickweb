using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace Ticket2.Models.clases
{
    public class RepositorioBase
    {
        private readonly string _connectionString;

        public RepositorioBase()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["Ticket2Connection"]
                .ConnectionString;
        }

        public List<Ticket> ObtenerTodos()
        {
            List<Ticket> tickets = new List<Ticket>();

            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT Id, Asunto, Descripcion, Tipo, Prioridad, Estado, FechaCreacion
                    FROM Tickets
                    ORDER BY FechaCreacion DESC";

                SqlCommand comando = new SqlCommand(query, conexion);

                conexion.Open();

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Ticket ticket = new Ticket
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Asunto = reader["Asunto"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Tipo = reader["Tipo"].ToString(),
                        Prioridad = reader["Prioridad"].ToString(),
                        Estado = reader["Estado"].ToString(),
                        FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"])
                    };

                    tickets.Add(ticket);
                }
            }

            return tickets;
        }

        public void Crear(Ticket ticket)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                string query = @"
            INSERT INTO Tickets
            (Asunto, Descripcion, Tipo, Prioridad, Estado, FechaCreacion)
            VALUES
            (@Asunto, @Descripcion, @Tipo, @Prioridad, @Estado, @FechaCreacion)";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Asunto", ticket.Asunto);
                comando.Parameters.AddWithValue("@Descripcion", ticket.Descripcion ?? "");
                comando.Parameters.AddWithValue("@Tipo", ticket.Tipo);
                comando.Parameters.AddWithValue("@Prioridad", ticket.Prioridad);
                comando.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(ticket.Estado) ? "Abierto" : ticket.Estado);
                comando.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Tickets WHERE Id = @Id";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Id", id);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }
    }
}