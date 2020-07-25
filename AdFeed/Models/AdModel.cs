using AdFeed.DAL.Entities;
using System.Collections.Generic;

namespace AdFeed.Models
{
    public class AdModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public List<Image> Images { get; set; }
    }
}
