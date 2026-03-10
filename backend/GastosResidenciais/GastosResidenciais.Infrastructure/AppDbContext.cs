using GastosResidenciais.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GastosResidenciais.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {

                    case EntityState.Added:
                        if (entry.Entity.CriadoEm == default)
                            entry.Property(x => x.CriadoEm).CurrentValue = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Property(x => x.EditadoEm).CurrentValue = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChanges();
        }
    }
}
