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
using System.Web.Mvc;

namespace APM.WebApi.Controllers
{
    [EnableCorsAttribute("http://localhost:100","*","*")]
    public class ProductController : ApiController
    {
        IProductRepository productRepository = new ProductRepositoryTextImpl(new ServerPathProvider());
        public List<Product> Get()
        {
            return productRepository.Retrieve();

        }
    }
}