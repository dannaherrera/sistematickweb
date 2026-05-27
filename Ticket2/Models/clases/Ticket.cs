using System;

namespace Ticket2.Models.clases
{
    public class Ticket
    {
        public int Id { get; set; }

        public string Asunto { get; set; }

        public string Descripcion { get; set; }

        public string Tipo { get; set; }

        public string Prioridad { get; set; }

        public string Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}