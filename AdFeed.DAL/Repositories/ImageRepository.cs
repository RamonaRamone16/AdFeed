using AdFeed.DAL.Entities;
using AdFeed.DAL.Repositories.Contracts;

namespace AdFeed.DAL.Repositories
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Images;
        }
    }
}
