using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACWA.Services.DTO;
using ACWA.Services.Interfaces;
using ACWA.Web.ModelsView;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACWA.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ICatalogService Catalog { get; set; }

        public ProductController(ICatalogService catalogService)
        {
            this.Catalog = catalogService;
        }

        // POST api/auction/addproduct
        [Route("addproduct")]
        [HttpPost]
        public void AddPost([FromBody] ProductVM productView)
        {
            var product = Mapper.Map<ProductDTO>(productView);

            Catalog.Create(product);
        }
    }
}