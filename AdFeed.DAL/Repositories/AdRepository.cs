using AdFeed.DAL.Entities;
using AdFeed.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL.Repositories
{
    public class AdRepository : Repository<Ad>, IAdRepository
    {
        public AdRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Ads;
        }
    }
}
