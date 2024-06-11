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
    public class PaintingConfiguration : IEntityTypeConfiguration<Painting>
    {
        public void Configure(EntityTypeBuilder<Painting> builder)
        {
            builder.ToTable("Painting");

            //Id
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasDefaultValueSql("NEWID()");

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

            //Image
            builder.Property(u => u.Image);

            //Name
            builder.Property(u => u.Name);

            //Description
            builder.Property(u => u.Description);

            //SubmitTime
            builder.Property(u => u.SubmitTime);

            //AwardId
            builder.Property(u => u.AwardId).IsRequired();

            //RoundId
            builder.Property(u => u.RoundId).IsRequired();

            //CompetitorId
            builder.Property(u => u.CompetitorId).IsRequired();

            //TopicId
            builder.Property(u => u.TopicId).IsRequired();

            //ScheduleId
            builder.Property(u => u.ScheduleId).IsRequired();

            //Code
            builder.Property(u => u.Code);

            //Relation

            builder.HasOne(u => u.Competitor)
                .WithMany(u => u.Painting)
                .HasForeignKey(u => u.CompetitorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(u => u.Award)
                .WithMany(u => u.Painting)
                .HasForeignKey(u => u.AwardId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(u => u.Schedule)
                .WithMany(u => u.Painting)
                .HasForeignKey(u => u.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
