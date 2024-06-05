using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infracstructures.FluentAPIs
{
    public class AwardConfiguration : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> builder)
        {
            builder.ToTable("Award");

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

            //Rank
            builder.Property(u => u.Rank);

            //Quantity
            builder.Property(u => u.Quantity);

            //Cash
            builder.Property(u => u.Cash);

            //Artifact
            builder.Property(u => u.Artifact);

            //Description
            builder.Property(u => u.Description);

            //Relation
            //EducationLevel
            builder.HasOne(u => u.EducationalLevel)
                .WithMany(u => u.Award)
                .HasForeignKey(u => u.EducationalLevelId).OnDelete(DeleteBehavior.ClientSetNull);
                
        }
    }
}
