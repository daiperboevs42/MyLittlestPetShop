using Microsoft.EntityFrameworkCore;
using MyLittlestPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLittlestPetshop.Infrastructure.SQL.Data
{
    public class PetshopAppContext: DbContext
    {
        public PetshopAppContext(DbContextOptions<PetshopAppContext> opt): base(opt)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasOne(o => o.Owner).WithMany(c => c.Pets).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Pet>().HasOne(t => t.PetType);
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
    }
}
