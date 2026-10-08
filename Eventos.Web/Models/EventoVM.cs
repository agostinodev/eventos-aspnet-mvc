using System.ComponentModel.DataAnnotations;

namespace Eventos.Web.Models
{
    public class EventoVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del evento es obligatorio")]
        [StringLength(10, ErrorMessage = "Campo con mas de 10 caracteres")]
        public string NombreEvento { get; set; } = "";

        [Required(ErrorMessage = "La fecha del evento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaEvento { get; set; }

    }
}
