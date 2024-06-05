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

            //GradeBy
            builder.Property(u => u.GradeBy);

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


            //Relation
            builder.HasOne(u => u.Account).WithMany(u => u.Painting).HasForeignKey(u => u.CompetitorId);
            builder.HasOne(u => u.Award).WithMany(u => u.Painting).HasForeignKey(u => u.AwardId);
        }
    }
}
