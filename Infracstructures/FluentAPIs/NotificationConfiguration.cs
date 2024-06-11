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
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notification");

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

            //Title
            builder.Property(u => u.Title);

            //Message
            builder.Property(u => u.Message);

            //IsRead
            builder.Property(u => u.IsReaded);

            //AccountId
            builder.Property(u => u.AccountId).IsRequired();

            //Relation
            builder.HasOne(u => u.Account).WithMany(u => u.Notifications).HasForeignKey(u => u.AccountId).OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
