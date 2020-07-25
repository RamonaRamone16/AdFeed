using AdFeed.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL.EntitiesConfigurations.Contracts
{
    public interface IEntityConfigurationContainer
    {
        IEntityConfiguration<Ad> AdConfiguration { get; }
        IEntityConfiguration<Category> CategoryConfiguration { get; }
        IEntityConfiguration<Comment> CommentConfiguration { get; }
        IEntityConfiguration<Image> ImageConfiguration { get; }
    }
}
