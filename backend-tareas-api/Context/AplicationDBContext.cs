using backend_tareas_api.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_tareas_api.Context
{
    public class AplicationDBContext: DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options): base(options)
        {

        }
        public DbSet <Tarea> Tareas { get; set; }
    }
}
