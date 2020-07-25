using AdFeed.DAL;
using AdFeed.DAL.Entities;
using AdFeed.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdFeed.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public CommentService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public List<CommentModel> GetAllComments(int adId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                List<Comment> comments = unitOfWork.Comments.GetAllByAdId(adId).ToList();

                return Mapper.Map<List<CommentModel>>(comments);
            }
        }

        public void CreateComment(CommentCreateModel model, int userId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                Comment comment = Mapper.Map<Comment>(model);
                comment.AuthorId = userId;

                unitOfWork.Comments.Create(comment);
            }
        }
    }
}
