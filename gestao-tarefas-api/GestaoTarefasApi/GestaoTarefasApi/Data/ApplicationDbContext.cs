using GestaoTarefasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoTarefasApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Tarefa> Tarefas => Set<Tarefa>();
    }
}
