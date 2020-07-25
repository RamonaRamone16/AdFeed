using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL
{
    public interface IApplicationDbContextFactory
    {
        ApplicationDbContext Create();
    }
}
