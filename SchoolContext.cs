using Microsoft.EntityFrameworkCore;
using eUcionica.EntityLib;

namespace eUcionica.DBContext
{
    public class SchoolContext : DbContext
    {
        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<Oblast> Oblast { get; set; }
        public DbSet<Zadatak> Zadatak { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Predmet>()
                .Property(p => p.NazivPredmeta)
                .IsRequired();

            modelBuilder.Entity<Oblast>()
                .Property(o => o.NazivOblasti)
                .IsRequired();

            modelBuilder.Entity<Zadatak>()
                .Property(z => z.SadrzajZadatka)
                .IsRequired();

            modelBuilder.Entity<Oblast>()
                .HasOne(o => o.Predmet)
                .WithMany(p => p.Oblast)
                .HasForeignKey(o => o.PredmetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Zadatak>()
                .HasOne(z => z.Oblast)
                .WithMany(o => o.Zadatak)
                .HasForeignKey(z => z.OblastId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
