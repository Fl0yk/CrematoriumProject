using Crematorium.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.Persistense.Data
{
    public class CrematoriumDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<RitualUrn> RitualUrns => Set<RitualUrn>();
        public DbSet<Corpose> Corposes => Set<Corpose>();
        public DbSet<Hall> Halls => Set<Hall>();

        public CrematoriumDbContext(DbContextOptions<CrematoriumDbContext> contextOptions)
            : base(contextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .HasAlternateKey(u => u.NumPassport);

            modelBuilder.Entity<User>()
                        .HasMany(u => u.Orders)
                        .WithOne(o => o.Customer);

            modelBuilder.Entity<Order>()
                        .HasOne(o => o.RitualUrnId);

            modelBuilder.Entity<Order>()
                        .HasOne(o => o.CorposeId);

            modelBuilder.Entity<Order>()
                        .HasOne(o => o.HallId);
        }
    }
}
