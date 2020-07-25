using AdFeed.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL.EntitiesConfigurations
{
    class CommentConfiguration : BaseEntityConfiguration<Comment>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(r => r.Content)
                .IsRequired();
        }

        protected override void ConfigureForeignKey(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.Author)
                .WithMany(y => y.Comments)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Ad)
                .WithMany(y => y.Comments)
                .HasForeignKey(x => x.AdId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
