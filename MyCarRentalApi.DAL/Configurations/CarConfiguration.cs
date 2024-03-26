using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCarRentalApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarRentalApi.DAL.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .Property(b => b.Number)
                .IsRequired(true);

            builder
               .Property(b => b.Model)
               .IsRequired(true)
               .HasMaxLength(50);

            builder
               .Property(b => b.IsAvailable)
               .HasDefaultValue(true);
        }
    }
}
