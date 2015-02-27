using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using App.Utility;
using App.ViewModels;
using Core;
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
        private readonly CategoryService _categoryService;
        private readonly IRepositoy<Category> _categoryRepositoy;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IResult _result;

        public CategoryController(IUnitOfWork unitOfWork , IResult result, CategoryService categoryService)
        {
            _unitOfWork = unitOfWork;
            _categoryRepositoy = _unitOfWork.GetRepository<Category>();
            _categoryService = categoryService;
            _result = result;
        }

        [Route("")]
        [HttpGet]
        public object Get()
        {
            return _categoryRepositoy.Query().ToList().Select(c => new
            {
                c.Id,
                c.Name,
                c.Products,
                Image = ImageView.Map(c.ImageKey)
            });
        }

        [Route("{id}")]
        [HttpGet]
        public object Get(Guid id)
        {
            var cat = _categoryRepositoy.FindById(id);

            return new
            {
                cat.Id,
                cat.Name,
                cat.Products,
                Image = ImageView.Map(cat.ImageKey)
            };
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post(Category category)
        {
            _categoryService.Create(category);

            if (!_result.IsValid) return Request.ToExceptionResponse(_result);

            _unitOfWork.Commit();
            return Request.CreateResponse();
        }

        [Route("")]
        [HttpPut]
        public HttpResponseMessage Put(Category category)
        {
            _categoryService.Update(category);

            if (!_result.IsValid) return Request.ToExceptionResponse(_result);

            _unitOfWork.Commit();
            return Request.CreateResponse();
        }

        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage Remove(Guid id)
        {
            _categoryService.Remove(id);

            if (!_result.IsValid) return Request.ToExceptionResponse(_result);

            _unitOfWork.Commit();
            return Request.CreateResponse();
        }
    }
}