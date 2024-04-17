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
    public class BaseConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder
                .Property(b => b.ModifiedDate)
                .IsRequired(true)
                .HasDefaultValue(DateTime.Now);
               builder
              .Property(b => b.CreationDate)
              .IsRequired(true)
              .HasDefaultValue(DateTime.Now);

        }
    }
}