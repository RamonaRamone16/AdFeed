using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdFeed.DAL.Entities;
using AdFeed.Models;
using AdFeed.Services.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdFeed.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userManager;

        public CommentController(ICommentService commentService, UserManager<User> userManager)
        {
            if (commentService == null)
                throw new ArgumentNullException(nameof(commentService));
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));
            _commentService = commentService;
            _userManager = userManager;
        }
        public IActionResult Index(int adId)
        {
            List<CommentModel> models = _commentService.GetAllComments(adId);
            return PartialView("_AllComments", models);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CommentCreateModel model)
        {
            User user = await _userManager.GetUserAsync(User);
            _commentService.CreateComment(model, user.Id);

            List<CommentModel> models = _commentService.GetAllComments(model.AdId);
            return PartialView("_AllComments", models);
        }
    }
}
