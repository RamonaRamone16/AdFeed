using AdFeed.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdFeed.Services.Ads
{
    public static class AdFilterEntentions
    {
        public static IEnumerable<Ad> ByKeyWord(this IEnumerable<Ad> products, string keyWord)
        {
            if (!string.IsNullOrWhiteSpace(keyWord))
                return products.Where(x => x.Title.Contains(keyWord) || x.Description.Contains(keyWord));
            return products;
        }

        public static IEnumerable<Ad> ByCategory(this IEnumerable<Ad> products, int? categoryId)
        {
            if (categoryId.HasValue)
                return products.Where(x => x.CategoryId == categoryId.Value);
            return products;
        }

        public static IEnumerable<Ad> ByImages(this IEnumerable<Ad> products, bool onlyWithImages)
        {
            if (onlyWithImages)
                return products.Where(x => x.Images.Count>0);
            return products;
        }

        public static IEnumerable<Ad> ByPriceFrom(this IEnumerable<Ad> products, decimal? priceTo)
        {
            if (priceTo.HasValue)
                return products.Where(p => p.Price >= priceTo.Value);
            return products;
        }
        public static IEnumerable<Ad> ByPriceTo(this IEnumerable<Ad> products, decimal? priceFrom)
        {
            if (priceFrom.HasValue)
                return products.Where(x => x.Price <= priceFrom.Value);
            return products;
        }

    }
}
