using AdFeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdFeed.Services.Ads
{
    public interface IAdService
    {
        List<AdModel> GetAllAds();
        AdCreateModel GetAdCreateModel();
        void CreateAd(AdCreateModel model, int userId);
        List<AdModel> GetAdsByUserId(int id);
    }
}
