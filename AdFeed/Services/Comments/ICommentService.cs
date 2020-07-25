using AdFeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdFeed.Services.Comments
{
    public interface ICommentService
    {
        List<CommentModel> GetAllComments(int adId);
        void CreateComment(CommentCreateModel model, int userId);
    }
}
