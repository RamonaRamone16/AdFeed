using AdFeed.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdFeed.DAL.EntitiesConfigurations
{
    public class ImageConfiguration : BaseEntityConfiguration<Image>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Image> builder)
        {
            builder.Property(r => r.Picture)
                .IsRequired();
        }

        protected override void ConfigureForeignKey(EntityTypeBuilder<Image> builder)
        {
            builder.HasOne(x => x.Ad)
                .WithMany(y => y.Images)
                .HasForeignKey(x => x.AdId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
