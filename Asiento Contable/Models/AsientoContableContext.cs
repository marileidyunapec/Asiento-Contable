using Microsoft.EntityFrameworkCore;

namespace Asiento_Contable.Models
{
    public class AsientoContableContext : DbContext
    {
        public AsientoContableContext()
        {
        }

        public AsientoContableContext(DbContextOptions<AsientoContableContext> options) : base(options)
        {
        }

        public virtual DbSet<ActivosFijos> ActivosFijos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }

}

