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
    public class CompetitorConfiguration : IEntityTypeConfiguration<Competitor>
    {
        public void Configure(EntityTypeBuilder<Competitor> builder)
        {
            builder.ToTable("Competitor");

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

            //FirstName
            builder.Property(u => u.FirstName);

            //LastName
            builder.Property(u => u.LastName);

            //Phone
            builder.Property(u => u.Phone);

            //Email
            builder.Property(u => u.Email);

            //Avatar
            builder.Property(u => u.Avatar);

            //Gender
            builder.Property(u => u.Gender);

            //CompetitorId
            builder.Property(u => u.GuardianId).IsRequired();


            //Relation
            builder.HasOne(u => u.Account)
                .WithOne(u => u.Competitor)
                .HasForeignKey<Competitor>(u => u.GuardianId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(u => u.Account)
                .WithOne(u => u.Competitor)
                .HasForeignKey<Competitor>(u => u.GuardianId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(u => u.Collection)
                .WithOne(u => u.Competitor)
                .HasForeignKey(u => u.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
