using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Ad> Ads { get; set; }
    }
}
