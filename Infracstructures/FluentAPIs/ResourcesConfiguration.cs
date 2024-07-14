using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infracstructures.FluentAPIs;

public class ResourcesConfiguration : IEntityTypeConfiguration<Resources>
{
    public void Configure(EntityTypeBuilder<Resources> builder)
    {
        builder.ToTable("Resources");

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

        //SponsorId
        builder.Property(u => u.SponsorId);

        //ContestId
        builder.Property(u => u.ContestId);

        //Sponsorship
        builder.Property(u => u.Sponsorship);

        //Relation
        builder.HasOne(u => u.Sponsor).WithMany(u => u.Resources).HasForeignKey(u => u.SponsorId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}