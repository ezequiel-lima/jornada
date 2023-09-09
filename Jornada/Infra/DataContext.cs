using Jornada.Infra.Mappings;
using Jornada.Models;
using Microsoft.EntityFrameworkCore;

namespace Jornada.Infra
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Declaracao> Declaracoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeclaracaoMap());
        }
    }
}
