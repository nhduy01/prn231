using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.FluentAPIs
{
    public class CategoryConfiguration
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            //Id
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasDefaultValueSql("NEWID()");

            //Name
            builder.Property(u => u.Name);

            //Description
            builder.Property(u => u.Description);
        }
    }
}
