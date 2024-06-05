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
    public class ContestConfiguration : IEntityTypeConfiguration<Contest>
    {
        public void Configure(EntityTypeBuilder<Contest> builder)
        {
            builder.ToTable("Contest");

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

            //Name
            builder.Property(u => u.Name);

            //Content
            builder.Property(u => u.Content);

            //Description
            builder.Property(u => u.Description);

            //EndTime
            builder.Property(u => u.EndTime);

            //StartTime
            builder.Property(u => u.StartTime);


            //Relation
            builder.HasMany(u => u.EducationalLevel).WithOne(u => u.Contest).HasForeignKey(u => u.ContestId).OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(u => u.Resources).WithOne(u => u.Contest).HasForeignKey(u => u.ContestId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
