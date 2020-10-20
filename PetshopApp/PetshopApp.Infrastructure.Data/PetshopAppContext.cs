using Microsoft.EntityFrameworkCore;
using PetshopApp.Core.Entity;

namespace PetshopApp.Infrastructure.Data
{
    public class PetshopAppContext : DbContext
    {
        public PetshopAppContext(DbContextOptions<PetshopAppContext> opt)
            : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Owner>()
            //    .HasOne(o => o.Type)
            //    .WithMany(ow => ow.Owners)
            //    .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(c => c.Pets)
                .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<OrderLine>()
            //    .HasKey(ol => new { ol.ProductId, ol.OrderId });

            //modelBuilder.Entity<OrderLine>()
            //    .HasOne(ol => ol.Order)
            //    .WithMany(o => o.OrderLines)
            //    .HasForeignKey(ol => ol.OrderId);

            //modelBuilder.Entity<OrderLine>()
            //    .HasOne(ol => ol.Product)
            //    .WithMany(p => p.OrderLines)
            //    .HasForeignKey(ol => ol.ProductId);
        }

        public Microsoft.EntityFrameworkCore.DbSet<Owner> Customers { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }

}
