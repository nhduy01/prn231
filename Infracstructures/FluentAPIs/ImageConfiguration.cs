using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infracstructures.FluentAPIs;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Image");

        //Id
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasDefaultValueSql("NEWID()");

        //URL
        builder.Property(u => u.Url);

        //Description
        builder.Property(u => u.Description);

        //PostId
        builder.Property(u => u.PostId).IsRequired();


        //Relation
        builder.HasOne(u => u.Post).WithMany(u => u.Images).HasForeignKey(u => u.PostId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}