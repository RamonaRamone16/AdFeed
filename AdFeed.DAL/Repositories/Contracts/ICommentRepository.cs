using AdFeed.DAL.Entities;
using System.Collections.Generic;

namespace AdFeed.DAL.Repositories.Contracts
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetAllByAdId(int adId);
    }
}
