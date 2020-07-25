using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdFeed.DAL.Entities;
using AdFeed.Models;
using AdFeed.Services.Ads;
using AutoMapper.Configuration.Conventions;
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

        public IActionResult Index(AdFilterModel model)
        {
            model.Ads = _adService.GetAllAds(model);
            return View(model);
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
        public async Task<ActionResult> GetUserAds(AdFilterModel model)
        {
            User user = await _userManager.GetUserAsync(User);
            model.Ads = _adService.GetAdsByUserId(model, user.Id);

            return View("Index", model);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            User user = await _userManager.GetUserAsync(User);
            AdModel model = _adService.GetAdById(id, user.Id);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdateDate(int adId)
        {
            _adService.UpdateAdDate(adId);

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Update(int id)
        {
            AdCreateModel model =_adService.GetAdForUpdate(id);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> UpdateAd(AdCreateModel model)
        {
            User user = await _userManager.GetUserAsync(User);
            _adService.UpdateAd(model, user.Id);

            return RedirectToAction("Index", new AdCreateModel());
        }
    }
}
