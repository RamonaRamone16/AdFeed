using AdFeed.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL.EntitiesConfigurations
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Category> builder)
        {
            builder.Property(r => r.Name)
                .IsRequired();
        }

        protected override void ConfigureForeignKey(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.Ads)
                .WithOne(y => y.Category)
                .HasForeignKey(y => y.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
