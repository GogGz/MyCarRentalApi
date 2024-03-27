using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MyCarRentalApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.DAL.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(b => b.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder
                .Property(b => b.Surname)
                .IsRequired(true)
                .HasMaxLength(50);

            builder
                .Property(b => b.DrivingLicense)
                .IsRequired(true)
                .HasMaxLength(50);

        }
    }
}
