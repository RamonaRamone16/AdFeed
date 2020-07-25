using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdFeed.Models
{
    public class AdFilterModel
    {
        [Display(Name = "Key Word")]
        public string KeyWord { get; set; }

        [Display(Name = "Price From")]
        public decimal? PriceFrom { get; set; }

        [Display(Name = "Price To")]
        public decimal? PriceTo { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public SelectList CategorySelect { get; set; }
        public bool OnlyWithImages { get; set; }
        public List<AdModel> Ads { get; set; }
    }
}
