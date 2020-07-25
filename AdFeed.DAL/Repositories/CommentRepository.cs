using AdFeed.DAL.Entities;
using AdFeed.DAL.Repositories.Contracts;

namespace AdFeed.DAL.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Comments;
        }
    }
}
