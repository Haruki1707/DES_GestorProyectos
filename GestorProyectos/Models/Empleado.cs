using System.ComponentModel.DataAnnotations;

namespace GestorProyectos.Models
{
    public class Empleado
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }

        [StringLength(50)]
        [Required]
        public string Apellido { get; set; }

        [Required]
        public DateOnly FechaContratacion { get; set; }

        [StringLength(50)]
        [Required]
        public string Puesto { get; set; }

        public ICollection<Asignacion>? Asignaciones { get; set; }
    }
}
