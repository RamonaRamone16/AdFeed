using AdFeed.DAL;
using AdFeed.DAL.Entities;
using AdFeed.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdFeed.Services.Ads
{
    public class AdService : IAdService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public AdService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public List<AdModel> GetAllAds()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                List<Ad> ads = unitOfWork.Ads.GetAllWithCategoryAndImages().ToList();
                return Mapper.Map<List<AdModel>>(ads);
            }
        }

        public List<AdModel> GetAdsByUserId(int userId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                List<Ad> ads = unitOfWork.Ads.GetAllByUserId(userId).ToList();
                return Mapper.Map<List<AdModel>>(ads); 
            }
        }

        public void CreateAd(AdCreateModel model, int userId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                Ad ad = Mapper.Map<Ad>(model);
                ad.AuthorId = userId;
                unitOfWork.Ads.Create(ad);

                if (model.Images.Count > 0)
                {
                    int adId = unitOfWork.Ads.GetAll().Last().Id;

                    for (int i = 0; i < model.Images.Count; i++)
                    {
                        var image = new Image()
                        {
                            AdId = adId,
                            Picture = GetImageBytes(model.Images[i]),
                            Main = i == 0 ? true : false
                        };
                        unitOfWork.Images.Create(image);
                    }
                }
            }
        }

        public AdCreateModel GetAdCreateModel()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                List<Category> categories = unitOfWork.Categories.GetAll().ToList();
                return new AdCreateModel()
                { 
                    CategorySelect = new SelectList(categories, nameof(Category.Id), nameof(Category.Name))
                };
            }
        }

        private byte[] GetImageBytes(IFormFile formFile)
        {
            using (var binaryReader = new BinaryReader(formFile.OpenReadStream()))
            {
                return binaryReader.ReadBytes((int)formFile.Length);
            }
        }
    }
}
