using Microsoft.EntityFrameworkCore;
using MyCarRentalApi.DAL.Configurations;
using MyCarRentalApi.DAL.Entities;
using System;
using System.Collections.Generic;
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


        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
