using Microsoft.EntityFrameworkCore;

namespace GestorProyectos.Models
{
    public class GestorProyectosDBContext : DbContext
    {
        public GestorProyectosDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
    }
}
