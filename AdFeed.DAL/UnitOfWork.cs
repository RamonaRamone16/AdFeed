using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;

        private bool disposed;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                _context.Dispose();

            disposed = true;
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
