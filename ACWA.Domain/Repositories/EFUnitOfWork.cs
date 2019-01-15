using ACWA.Domain.EF;
using ACWA.Domain.Interfaces;
using ACWA.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACWA.Domain.Repositories
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable

    {
        private AuctionContext db;

        private ProductRepository productRepository;
        
        private CategoryRepository categoryRepository;
       

        public EFUnitOfWork(AuctionContext auctionContext)
        {
            db = auctionContext ?? throw new ArgumentNullException("Context was not supplied");
        }
        public DbContext Context { get { return db; } }
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(db);
                }
                return productRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new CategoryRepository(db);
                }
                return categoryRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

