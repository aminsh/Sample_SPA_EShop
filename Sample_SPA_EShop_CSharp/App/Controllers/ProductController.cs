using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DataAccess.Query;
using Domain.Data;
using Domain.Model;
using DTO.Params;
using Raven.Abstractions.Linq;

namespace App.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        private readonly IRepositoy<Category> _categoryRepositoy;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _categoryRepositoy = unitOfWork.GetRepository<Category>();
        }

        [Route("")]
        public HttpResponseMessage Get([FromUri]SearchParam param)
        {
            return Request.CreateResponse(ProductQuery.Search(param));
        }
    }

    
}