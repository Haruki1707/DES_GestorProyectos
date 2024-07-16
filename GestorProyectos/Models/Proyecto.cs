using System.ComponentModel.DataAnnotations;

namespace GestorProyectos.Models
{
    public class Proyecto
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }

        [StringLength(250)]
        [Required]
        public string Descripcion { get; set; }

        [Required]
        public DateOnly FechaInicio { get; set; }

        public ICollection<Asignacion>? Asignaciones { get; set; }
    }
}
