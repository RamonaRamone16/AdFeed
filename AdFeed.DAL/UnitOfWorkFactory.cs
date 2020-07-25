using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IApplicationDbContextFactory _applicationDbContextFactory;

        public UnitOfWorkFactory(IApplicationDbContextFactory applicationDbContextFactory)
        {
            if (applicationDbContextFactory == null)
                throw new ArgumentNullException(nameof(applicationDbContextFactory));
            _applicationDbContextFactory = applicationDbContextFactory;
        }

        public UnitOfWork Create()
        {
            return new UnitOfWork(_applicationDbContextFactory.Create());
        }
    }
}
