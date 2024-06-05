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
    public class GuardianConfiguration : IEntityTypeConfiguration<Guardian>
    {
        public void Configure(EntityTypeBuilder<Guardian> builder)
        {
            builder.ToTable("Guardian");

            //Id
            builder.HasKey(u => u.Id);

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

            //Relationship
            builder.Property(u => u.Relationship);

            //Phone
            builder.Property(u => u.Phone);

            //Email
            builder.Property(u => u.Email);

            //IdentifyNumber
            builder.Property(u => u.IdentifyNumber);

            //Avatar
            builder.Property(u => u.Avatar);

            //Gender
            builder.Property(u => u.Gender);

            //CompetitorId
            builder.Property(u => u.CompetitorId).IsRequired();


            //Relation
            builder.HasOne(u => u.Account).WithOne(u => u.Guardian).HasForeignKey<Guardian>(u => u.CompetitorId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
