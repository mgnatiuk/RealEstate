using System;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;

namespace RealEstate.Infrastructure.Data
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Estate>()
                .HasOne(d => d.Address)
                .WithOne(p => p.Estate)
                .OnDelete(DeleteBehavior.Cascade);

            

            builder.Entity<Apartment>();
            builder.Entity<PrivateHouse>();

            base.OnModelCreating(builder);
        }
 
        public DbSet<Estate> Estates { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<PrivateHouse> PrivateHouses { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
