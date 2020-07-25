using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL
{
    public interface IUnitOfWorkFactory
    {
        UnitOfWork Create();
    }
}
