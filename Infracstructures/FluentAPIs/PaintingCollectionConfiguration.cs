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
    public class PaintingCollectionConfiguration : IEntityTypeConfiguration<PaintingCollection>
    {
        public void Configure(EntityTypeBuilder<PaintingCollection> builder)
        {
            builder.ToTable("PaintingCollection");

            //Id
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasDefaultValueSql("NEWID()");

            //CollectionId
            builder.Property(u => u.CollectionId).IsRequired();

            //PaintingId
            builder.Property(u => u.PaintingId).IsRequired();


            //Relation
            builder.HasOne(u => u.Painting).WithMany(u => u.PaintingCollection).HasForeignKey(u => u.PaintingId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
