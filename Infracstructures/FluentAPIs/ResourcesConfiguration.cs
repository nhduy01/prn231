﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.FluentAPIs
{
    public class ResourcesConfiguration : IEntityTypeConfiguration<Resources>
    {
        public void Configure(EntityTypeBuilder<Resources> builder)
        {
            builder.ToTable("Resources");

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

            //Cash
            builder.Property(u => u.Cash);

            //Artifact
            builder.Property(u => u.Artifact);

            //SponsorId
            builder.Property(u => u.SponsorId);

            //ContestId
            builder.Property(u => u.ContestId);



            //Relation
            builder.HasOne(u => u.Sponsor).WithMany(u => u.Resources).HasForeignKey(u => u.SponsorId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
