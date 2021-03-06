﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DataAccess.RavenDB;
using Domain.Model;
using Domain.Data;
using Domain.Service.Utility;

namespace Domain.Service
{
    public class CategoryService
    {
        private readonly IRepositoy<Category> _categoryRepository;
        private readonly IResult _result;

        public CategoryService(IUnitOfWork unitOfWork, IResult result)
        {
            _categoryRepository = unitOfWork.GetRepository<Category>();
            _result = result;
        }

        public void Create(Category category)
        {
            category.Id = Guid.NewGuid();
            GerarateIdForProduct(category);
            
            if(string.IsNullOrWhiteSpace(category.Name))
                _result.Errors.Add(new Error{Message = "نام گروه خالی است"});
            Repository<Category>.Instance.Add(category);
        }

        public void Update(Category category)
        {
            var categoryRepository = Repository<Category>.Instance;
            GerarateIdForProduct(category);

            var item = categoryRepository.FindById(category.Id);
            item.ImageKey = category.ImageKey;
            item.Name = category.Name;
            item.Products = category.Products;

            categoryRepository.Modify(item);
        }

        public void Remove(Guid id)
        {
            var category = Repository<Category>.Instance.FindById(id);
            Repository<Category>.Instance.Delete(category);
        }

        private static void GerarateIdForProduct(Category category)
        {
            category.Products.ToList()
                .ForEach(p =>
                {
                    if (p.Id == Guid.Empty)
                        p.Id = Guid.NewGuid();
                });
        }
    }
}
