using AdFeed.DAL.Entities;
using AdFeed.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AdFeed.DAL.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Comments;
        }

        public IEnumerable<Comment> GetAllByAdId(int adId)
        {
            return entities.Include(x => x.Author).Where(x => x.AdId == adId);
        }
    }
}
