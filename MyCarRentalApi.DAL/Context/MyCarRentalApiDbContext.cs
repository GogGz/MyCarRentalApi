using Microsoft.EntityFrameworkCore;
using MyCarRentalApi.DAL.Configurations;
using MyCarRentalApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.DAL.Context
{
    public class MyCarRentalApiDbContext : DbContext
    {

        public MyCarRentalApiDbContext(DbContextOptions<MyCarRentalApiDbContext> options)
          : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            modelBuilder.Entity<Car>().HasData(
               new() { Id = 1, Model = "BMW", Number = "123er56" },
               new() { Id = 2, Model = "Mercedes", Number = "098gfr765" }
            );  ;

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
