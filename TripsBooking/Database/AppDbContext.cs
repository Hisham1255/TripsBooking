using Microsoft.EntityFrameworkCore;
using TripsBooking.Models;

namespace TripsBooking.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<SalaryItem> SalaryItems { get; set; }

        public DbSet<Menha> Menha { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SalaryItem>(entity =>
            {
                entity.ToTable("QTOUTSAL24");
                entity.HasKey(x => x.EmployeeId);
            });

            modelBuilder.Entity<Menha>(entity =>
            {
                entity.ToTable("QTOUT_MENHA");
                entity.HasKey(x => x.EmployeeId);
            });
        }
    }
}