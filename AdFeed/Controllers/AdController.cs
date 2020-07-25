using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdFeed.DAL.Entities;
using AdFeed.Models;
using AdFeed.Services.Ads;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdFeed.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdService _adService;
        private readonly UserManager<User> _userManager;

        public AdController(IAdService adService, UserManager<User> userManager)
        {
            if(adService == null)
                throw new ArgumentNullException(nameof(adService));
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));
            _adService = adService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<AdModel> models = _adService.GetAllAds();
            return View(models);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            AdCreateModel model = _adService.GetAdCreateModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateAd(AdCreateModel model)
        {
            User user = await _userManager.GetUserAsync(User);
            _adService.CreateAd(model, user.Id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetUserAds()
        {
            User user = await _userManager.GetUserAsync(User);
            List<AdModel> models = _adService.GetAdsByUserId(user.Id);

            return View("Index", models);
        }
    }
}
