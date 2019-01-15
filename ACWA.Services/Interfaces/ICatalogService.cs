using ACWA.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACWA.Services.Interfaces
{
    public interface ICatalogService
    {
        void Create(ProductDTO productDTO);

        void Delete(int id);

        ProductDTO GetProduct(int? id);

        IEnumerable<ProductDTO> GetProducts();

        void Dispose();
    }
}
