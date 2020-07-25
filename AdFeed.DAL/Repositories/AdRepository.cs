using AdFeed.DAL.Entities;
using AdFeed.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AdFeed.DAL.Repositories
{
    public class AdRepository : Repository<Ad>, IAdRepository
    {
        public AdRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Ads;
        }

        public IEnumerable<Ad> GetAllByUserId(int userId)
        {
            return entities.Include(x => x.Category).Include(x => x.Images).Where(x => x.AuthorId == userId);
        }

        public IEnumerable<Ad> GetAllWithCategoryAndImages()
        {
            return entities.Include(x => x.Category).Include(x => x.Images);
        }
    }
}
