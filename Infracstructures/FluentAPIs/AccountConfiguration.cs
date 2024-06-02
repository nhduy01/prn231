using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infracstructures.FluentAPIs
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            //Id
            builder.HasKey(u => u.Id);

            //Email
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Email).IsUnique();

            //Password
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);

            //Phone
            builder.Property(u => u.Phone).HasMaxLength(10);

        }
    }
}