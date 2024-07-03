using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infracstructures.FluentAPIs;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable("Topic");

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

        //Description
        builder.Property(u => u.Description);

        //Image
        builder.Property(u => u.Image);

    }
}