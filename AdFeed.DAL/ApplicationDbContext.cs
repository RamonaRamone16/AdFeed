using AdFeed.DAL.Entities;
using AdFeed.DAL.EntitiesConfigurations.Contracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public readonly IEntityConfigurationContainer _entityConfigurationContainer;

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IEntityConfigurationContainer entityConfigurationContainer) : base(options)
        {
            _entityConfigurationContainer = entityConfigurationContainer;

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity(_entityConfigurationContainer.AdConfiguration.ProvideConfigurationAction());
            builder.Entity(_entityConfigurationContainer.CategoryConfiguration.ProvideConfigurationAction());
            builder.Entity(_entityConfigurationContainer.CommentConfiguration.ProvideConfigurationAction());
            builder.Entity(_entityConfigurationContainer.ImageConfiguration.ProvideConfigurationAction());
        }
    }
}
