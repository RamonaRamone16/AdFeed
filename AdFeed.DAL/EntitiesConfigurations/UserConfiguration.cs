using AdFeed.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdFeed.DAL.EntitiesConfigurations
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<User> builder)
        {
        }

        protected override void ConfigureForeignKey(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.Ads)
               .WithOne(y => y.Author)
               .HasForeignKey(y => y.AuthorId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            builder.HasMany(x => x.Comments)
               .WithOne(y => y.Author)
               .HasForeignKey(y => y.AuthorId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();
        }
    }
}
