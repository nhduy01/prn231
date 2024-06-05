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
    internal class RoundConfiguration : IEntityTypeConfiguration<Round>
    {
        public void Configure(EntityTypeBuilder<Round> builder)
        {
            builder.ToTable("Round");

            //Id
            builder.HasKey(u => u.Id);

            //CreateTime
            builder.Property(u => u.CreatedTime);

            //CreateBy
            builder.Property(u => u.CreatedBy);

            //UpdateTime
            builder.Property(u => u.UpdatedTime);

            //UpdateBy
            builder.Property(u => u.UpdatedBy);

            //Status
            builder.Property(u => u.Status).HasDefaultValue("False");

            //StartTime
            builder.Property(u => u.StartTime);

            //EndTime
            builder.Property(u => u.EndTime);

            //Location
            builder.Property(u => u.Location);

            //Description
            builder.Property(u => u.Description);

            //EducationalLevel
            builder.Property(u => u.EducationalLevelId);




            builder.HasMany(u => u.Topic).WithOne(u => u.Round).HasForeignKey(u => u.RoundId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(u => u.Schedule).WithOne(u => u.Round).HasForeignKey(u => u.RoundId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(u => u.Painting).WithOne(u => u.Round).HasForeignKey(u => u.RoundId).OnDelete(DeleteBehavior.ClientSetNull); 
        }
    }
}
