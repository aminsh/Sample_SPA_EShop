using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using Domain.Model;

namespace App.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IQueryable<Category> Get()
        {
            return new List<Category>
            {
                new Category {Id = 1, Name = "Cat 1"},
                new Category {Id = 2, Name = "Cat 2"},
                new Category {Id = 3, Name = "Cat 3"},
                new Category {Id = 4, Name = "Cat 4"}
            }.AsQueryable();
        }

        [Route("{id}")]
        [HttpGet]
        public Category Get(int id)
        {
            return Get().ToList().First(c => c.Id == id);
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post(IEnumerable<Category> categories)
        {
            return Request.CreateResponse(categories);
        }
    }
}