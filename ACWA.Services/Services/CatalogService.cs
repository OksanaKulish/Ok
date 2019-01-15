using ACWA.Domain.Interfaces;
using ACWA.Domain.Models;
using ACWA.Services.DTO;
using ACWA.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ACWA.Services.Services
{
    class CatalogService : ICatalogService
    {
        private IUnitOfWork Db { get; set; }

        public CatalogService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public void Create(ProductDTO productDTO)
        {
            var product = Mapper.Map<Product>(productDTO);

            Db.Products.Create(product);
            Db.Save();
        }

        public void Delete(int id)
        {
            //var product = Db.Products.Find(x=> x.ProductId == id);
            //var product = Db.Products.Get(productDTO.Id);
            //if (product != null)
            //{
            // Mapper.Map(productDTO, product);
            Db.Products.Delete(id);
            Db.Save();
            // }
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            //var mapper = new MapperConfiguration(cfn => cfn.CreateMap<Product, ProductDTO>()).CreateMapper();
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Db.Products.GetAll());

        }

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Product is null");
            //var products = Db.Products.GetAll();
            var product = Db.Products.Get(id.Value);
            if (product == null)
                throw new ValidationException("Product was not founded");
            return Mapper.Map<Product, ProductDTO>(product);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
