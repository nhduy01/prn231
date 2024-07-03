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
    public class RoundTopicConfiguration : IEntityTypeConfiguration<RoundTopic>
    {
        public void Configure(EntityTypeBuilder<RoundTopic> builder)
        {
            builder.ToTable("RoundTopic");

            //Id
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasDefaultValueSql("NEWID()");

            //RoundId
            builder.Property(u => u.RoundId).IsRequired();

            //TopicId
            builder.Property(u => u.TopicId).IsRequired();


            //Relation
            builder.HasOne(u => u.Topic).WithMany(u => u.RoundTopic).HasForeignKey(u => u.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(u => u.Round).WithMany(u => u.RoundTopic).HasForeignKey(u => u.RoundId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(u => u.Painting).WithOne(u => u.RoundTopic).HasForeignKey(u => u.RoundTopicId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
