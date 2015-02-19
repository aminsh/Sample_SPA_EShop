using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.RavenDB;
using Domain.Model;
using Domain.Data;

namespace Domain.Service
{
    public class CategoryService
    {
        private readonly IRepositoy<Category> _categoryRepository;
        public CategoryService(IRepositoy<Category> categoryRepositoy)
        {
            _categoryRepository = categoryRepositoy;
        }
        public void Create(Category category)
        {
            GerarateIdForProduct(category);
                            
            _categoryRepository.Add(category);
        }

        public void Update(Category category)
        {
            GerarateIdForProduct(category);

            var item = _categoryRepository.FindById(category.Id);
            item.ImageUrl = category.ImageUrl;
            item.Name = category.Name;
            item.Products = category.Products;

            _categoryRepository.Modify(item);
        }

        public void Remove(Category category)
        {
            _categoryRepository.Delete(category);
        }

        private static void GerarateIdForProduct(Category category)
        {
            category.Products.ToList()
                .ForEach(p =>
                {
                    if (p.Id == 0)
                        p.Id =
                            Convert.ToInt32(
                                String.Format("{0}{1}", 
                                category.Id, 
                                category.Products.ToList().IndexOf(p)));
                });
        }
    }
}
