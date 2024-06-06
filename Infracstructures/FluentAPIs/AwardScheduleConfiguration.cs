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
    public class AwardScheduleConfiguration : IEntityTypeConfiguration<AwardSchedule>
    {
        public void Configure(EntityTypeBuilder<AwardSchedule> builder)
        {
            builder.ToTable("AwardSchedule");

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

            //Quantity
            builder.Property(u => u.Quantity);

            //AwardId
            builder.Property(u => u.AwardId);

            //ScheduleId
            builder.Property(u => u.ScheduleId);

            //Relation
            
            builder.HasOne(u => u.Award)
                .WithMany(u => u.AwardSchedule)
                .HasForeignKey(u => u.AwardId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(u => u.Schedule)
                .WithMany(u => u.AwardSchedule)
                .HasForeignKey(u => u.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
