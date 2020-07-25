using AdFeed.Models;
using System.Collections.Generic;

namespace AdFeed.Services.Ads
{
    public interface IAdService
    {
        List<AdModel> GetAllAds(AdFilterModel model);
        AdCreateModel GetAdCreateModel();
        void CreateAd(AdCreateModel model, int userId);
        List<AdModel> GetAdsByUserId(AdFilterModel model, int id);
        AdModel GetAdById(int adId, int userId);
        void UpdateAdDate(int adId);
        void UpdateAd(AdCreateModel model, int userId);
        AdCreateModel GetAdForUpdate(int adId);
    }
}
