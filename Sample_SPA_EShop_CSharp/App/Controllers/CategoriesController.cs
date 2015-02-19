using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using DataAccess.RavenDB;
using Domain.Model;
using Domain.Service;
using Domain.Data;
using Raven.Abstractions.Extensions;

namespace App.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        private CategoryService CategoryService { get; set; }
        private IRepositoy<Category> CategoryRepositoy { get; set; }

        public IUnitOfWork UnitOfWork { get; set; }

        public CategoryController()
        {
            UnitOfWork = new RavenUnitOfWork();
            CategoryRepositoy = UnitOfWork.GetRepository<Category>();
            CategoryService = new CategoryService(CategoryRepositoy);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return CategoryRepositoy.Query().ToList();
            //return new List<Category>
            //{
            //    new Category {Id = 1, Name = "Cat 1"},
            //    new Category {Id = 2, Name = "Cat 2"},
            //    new Category {Id = 3, Name = "Cat 3"},
            //    new Category {Id = 4, Name = "Cat 4"}
            //}.AsQueryable();
        }

        [Route("{id}")]
        [HttpGet]
        public Category Get(int id)
        {
            return CategoryRepositoy.FindById(id);
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post(IList<Category> categories)
        {
            var storedCats = CategoryRepositoy.Query().ToList();
            var updated = categories.Where(c => storedCats.Any(cat=> cat.Id == c.Id));
            var created = categories.Where(c => storedCats.All(cat => cat.Id != c.Id));
            var deleted = storedCats.Where(c => categories.All(cat => cat.Id != c.Id));

            updated.ForEach(item => CategoryService.Update(item));
            created.ForEach(item => CategoryService.Create(item));
            deleted.ForEach(item => CategoryService.Remove(item));

            UnitOfWork.Commit();
            return Request.CreateResponse(Get());
        }
    }
}