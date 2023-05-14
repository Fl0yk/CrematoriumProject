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
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(o => o.Customer)
                .WithMany(o => o.Orders);
                

                entity.HasOne<RitualUrn>();
                entity.HasOne<Corpose>();
                entity.HasOne<Hall>();
            });

            modelBuilder.Entity<Hall>().HasMany(h => h.FreeDates);
        }
    }
}

