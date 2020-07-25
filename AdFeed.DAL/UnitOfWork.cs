using AdFeed.DAL.Repositories;
using AdFeed.DAL.Repositories.Contracts;
using System;

namespace AdFeed.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;

        private bool disposed;

        public IAdRepository Ads { get; }
        public ICategoryRepository Categories { get; }
        public ICommentRepository Comments { get; }
        public IImageRepository Images { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Ads = new AdRepository(context);
            Categories = new CategoryRepository(context);
            Comments = new CommentRepository(context);
            Images = new ImageRepository(context);
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
