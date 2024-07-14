using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infracstructures.FluentAPIs;

internal class SponsorConfiguration : IEntityTypeConfiguration<Sponsor>
{
    public void Configure(EntityTypeBuilder<Sponsor> builder)
    {
        builder.ToTable("Sponsor");

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

        //Address
        builder.Property(u => u.Address);

        //Delegate
        builder.Property(u => u.Delegate);

        //PhoneNumber
        builder.Property(u => u.PhoneNumber);

        //Logo
        builder.Property(u => u.Logo);
    }
}