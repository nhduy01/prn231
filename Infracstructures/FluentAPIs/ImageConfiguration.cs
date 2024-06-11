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
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image");

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

            //URL
            builder.Property(u => u.Url);

            //Description
            builder.Property(u => u.Description);



            //Relation
            builder.HasMany(u => u.PostImage)
                .WithOne(u => u.Images)
                .HasForeignKey(u => u.ImageId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
