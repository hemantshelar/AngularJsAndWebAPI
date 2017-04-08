using APM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APM.WebApi.Interfaces
{
    public interface IProductRepository
    {
        IPathProvider PathProvider { get; set; }
        Product Create();

        List<Product> Retrieve();

        void Save(Product product);

        void Save(int id, Product product);
    }
}