using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infracstructures.FluentAPIs
{
    public class EducationalLevelConfiguration : IEntityTypeConfiguration<EducationalLevel>
    {
        public void Configure(EntityTypeBuilder<EducationalLevel> builder)
        {
            builder.ToTable("EducationalLevel");

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

            //ContestId
            builder.Property(u => u.ContestId).IsRequired();

            //StartTime
            builder.Property(u => u.StartTime);

            //EndTime
            builder.Property(u => u.EndTime);

            //Description
            builder.Property(u => u.Description);

            //EducationLevel
            builder.Property(u => u.EducationLevel);


            //Relation
            builder.HasMany(u => u.Round).WithOne(u => u.EducationalLevel).HasForeignKey(u => u.EducationalLevelId).OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}

