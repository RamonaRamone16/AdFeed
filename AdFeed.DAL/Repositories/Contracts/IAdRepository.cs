using AdFeed.DAL.Entities;
using System.Collections.Generic;

namespace AdFeed.DAL.Repositories.Contracts
{
    public interface IAdRepository : IRepository<Ad>
    {
        IEnumerable<Ad> GetAllWithCategoryAndImages();
        IEnumerable<Ad> GetAllByUserId(int userId);
    }
}
