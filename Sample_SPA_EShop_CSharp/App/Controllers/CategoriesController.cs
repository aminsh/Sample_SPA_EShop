﻿using System;
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
        public Category Get(Guid id)
        {
            return _categoryRepositoy.FindById(id);
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post(IList<Category> categories)
        {
            
            var storedCats = _categoryRepositoy.Query().ToList();
            var updated = categories.Where(c => storedCats.Any(cat=> cat.Id == c.Id));
            var created = categories.Where(c => storedCats.All(cat => cat.Id != c.Id));
            var deleted = storedCats.Where(c => categories.All(cat => cat.Id != c.Id));

            updated.ForEach(item => _categoryService.Update(item));
            created.ForEach(item => _categoryService.Create(item));
            deleted.ForEach(item => _categoryService.Remove(item));

            if (_result.IsValid)
            {
                _unitOfWork.Commit();
                return Request.CreateResponse(_categoryRepositoy.Query().ToList());
            }

            return Request.ToExceptionResponse(_result);
        }
    }
}