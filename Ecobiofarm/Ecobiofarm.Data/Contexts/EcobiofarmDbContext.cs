using Ecobiofarm.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecobiofarm.Data.Contexts
{
    public class EcobiofarmDbContext : DbContext
    {
        private DbContextOptions<EcobiofarmDbContext> options;

        public EcobiofarmDbContext(DbContextOptions<EcobiofarmDbContext> options)
            : base(options)
        {
            this.options = options ?? throw new ArgumentNullException("options");

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cut> Cuts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Cut>().ToTable("Cuts");
        }
    }
}
