using ACWA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACWA.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        void Save();
    }
}
