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


        public ApplicationDbContext(
            DbContextOptions options,
            IEntityConfigurationContainer entityConfigurationContainer) : base(options)
        {
            _entityConfigurationContainer = entityConfigurationContainer;

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
