using System.ComponentModel.DataAnnotations;

namespace GestorProyectos.Models
{
    public class Asignacion
    {
        public int ID { get; set; }

        [Required]
        public int? EmpleadoId { get; set; }
        public Empleado? Empleado { get; set; }

        [Required]
        public int? ProyectoId { get; set; }
        public Proyecto? Proyecto { get; set; }

        [Required]
        public DateOnly FechaAsignacion { get; set; } = new DateOnly();

        [StringLength(50)]
        [Required]
        public string rol { get; set; }
    }
}
