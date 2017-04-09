using APM.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APM.WebApi.Models;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace APM.WebApi.Repository
{
    public class ProductRepositoryTextImpl : IProductRepository
    {

        public ProductRepositoryTextImpl(IPathProvider pathProvider)
        {
            PathProvider = pathProvider;
        }

        public IPathProvider PathProvider { get;  set; }

        public Product Create()
        {
            Product product = new Product();
            product.ReleaseDate = DateTime.Now;
            return product;
        }

        public List<Product> Retrieve()
        {
            var path = PathProvider.MapPath("~/App_Data/products.json");
            var jsonData = System.IO.File.ReadAllText(path);
            List<Product> result =  JsonConvert.DeserializeObject<List<Product>>(jsonData);
            return result;
        }

        public void Save(Product product)
        {
            List<Product> list = this.Retrieve();
            var lastProduct = list.Max(p => p.ProductId);
            product.ProductId = lastProduct + 1;
            list.Add(product);
            WriteData(list);

        }

        private void WriteData(List<Product> list)
        {
            var path = PathProvider.MapPath("~/App_Data/products.json");
            var json = JsonConvert.SerializeObject(list, Formatting.Indented);
            System.IO.File.WriteAllText(path,json);
        }

        public void Save(int id, Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            Product product = null;
            if (id > 0)
            {
                product = this.Retrieve().Where(p => p.ProductId == id).SingleOrDefault();
            }
            else
            {
                product = this.Create();
            }
            return product;
        }
    }
}