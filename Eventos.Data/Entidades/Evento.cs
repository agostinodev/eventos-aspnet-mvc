using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Data.Entidades
{
    public class Evento
    {
        public int Id { get; set; }
        public string NombreEvento { get; set; } = "";
        public DateTime FechaEvento { get; set; }

    }
}
