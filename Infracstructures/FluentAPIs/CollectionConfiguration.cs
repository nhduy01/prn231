using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infracstructures.FluentAPIs
{
    public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.ToTable("Collection");

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

            //Name
            builder.Property(u => u.Name);

            //Image
            builder.Property(u => u.Image);

            //Description
            builder.Property(u => u.Description);



            //Relation
            builder.HasMany(u => u.PaintingCollection)
                .WithOne(u => u.Collection)
                .HasForeignKey(u => u.CollectionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            

        }
    }
}

