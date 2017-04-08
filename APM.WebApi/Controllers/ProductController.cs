using APM.WebApi.Interfaces;
using APM.WebApi.Models;
using APM.WebApi.Repository;
using APM.WebApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Mvc;

namespace APM.WebApi.Controllers
{
    [EnableCorsAttribute("http://localhost:100","*","*")]
    public class ProductController : ApiController
    {
        IProductRepository productRepository = new ProductRepositoryTextImpl(new ServerPathProvider());
        [EnableQuery()]
        public IQueryable<Product> Get()
        {
            return productRepository.Retrieve().AsQueryable<Product>();
        }

        [EnableQuery()]
        public IQueryable<Product> Get(string search)
        {
            var result = productRepository.Retrieve().Where(p => p.ProductCode.StartsWith(search)).AsQueryable<Product>();
            return result;
        }
    }
}