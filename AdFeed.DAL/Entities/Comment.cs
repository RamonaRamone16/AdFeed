using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL.Entities
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int AuthorId { get; set; }
        public int AdId { get; set; }


        public User Author { get; set; }
        public Ad Ad { get; set; }
    }
}
