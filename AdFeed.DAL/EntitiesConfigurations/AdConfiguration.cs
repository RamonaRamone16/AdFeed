using AdFeed.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdFeed.DAL.EntitiesConfigurations
{
    public class AdConfiguration : BaseEntityConfiguration<Ad>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Ad> builder)
        {
            builder.Property(r => r.Title)
                .IsRequired();

            builder.Property(r => r.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(r => r.PhoneNumber)
                .IsRequired();
        }

        protected override void ConfigureForeignKey(EntityTypeBuilder<Ad> builder)
        {
            builder.HasOne(x => x.Author)
                .WithMany(y => y.Ads)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(y => y.Ads)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasMany(x => x.Images)
               .WithOne(y => y.Ad)
               .HasForeignKey(y => y.AdId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            builder.HasMany(x => x.Comments)
               .WithOne(y => y.Ad)
               .HasForeignKey(y => y.AdId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();
        }
    }
}
