using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using Domain.Model;

namespace App.Controllers
{
    //public class ProductsController : EntitySetController<Product, int>
    //{
    //    public override IQueryable<Product> Get()
    //    {
    //        var products = new List<Product>
    //        {
    //            new Product {Id = 1, Name = "Pro1",Price = 2500},
    //            new Product {Id = 2, Name = "Pro2",Price = 3500},
    //            new Product {Id = 3, Name = "Pro3",Price = 4500},
    //            new Product {Id = 4, Name = "Pro4",Price = 5500},
    //        };
    //        return products.AsQueryable();
    //    }

    //    public override HttpResponseMessage Post(Product entity)
    //    {
    //        return Request.CreateResponse(entity);
    //    }

    //    public override void Delete(int key)
    //    {
    //        base.Delete(key);
    //    }
    //}

    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IQueryable<Product> Get()
        {
            var products = new List<Product>
            {
                new Product {Id = 1, Name = "Pro1",Price = 2500},
                new Product {Id = 2, Name = "Pro2",Price = 3500},
                new Product {Id = 3, Name = "Pro3",Price = 4500},
                new Product {Id = 4, Name = "Pro4",Price = 5500},
            };
            return products.AsQueryable();
        }

        [Route("{id:int}/category")]
        public Category GetCategory(int id)
        {
            return new Category();
        }
    }
}
