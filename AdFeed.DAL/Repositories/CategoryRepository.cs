using AdFeed.DAL.Entities;
using AdFeed.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Categories;
        }
    }
}
