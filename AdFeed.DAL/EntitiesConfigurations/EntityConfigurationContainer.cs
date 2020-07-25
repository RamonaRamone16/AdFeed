using AdFeed.DAL.Entities;
using AdFeed.DAL.EntitiesConfigurations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL.EntitiesConfigurations
{
    public class EntityConfigurationContainer : IEntityConfigurationContainer
    {
        public IEntityConfiguration<Ad> AdConfiguration { get; set; }
        public IEntityConfiguration<Category> CategoryConfiguration { get; set; }
        public IEntityConfiguration<Comment> CommentConfiguration { get; set; }
        public IEntityConfiguration<Image> ImageConfiguration { get; set; }

        public EntityConfigurationContainer()
        {
            AdConfiguration = new AdConfiguration();
            CategoryConfiguration = new CategoryConfiguration();
            CommentConfiguration = new CommentConfiguration();
            ImageConfiguration = new ImageConfiguration();
        }
    }
}
