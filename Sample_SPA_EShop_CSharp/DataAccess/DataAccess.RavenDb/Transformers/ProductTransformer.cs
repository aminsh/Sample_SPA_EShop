using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using DTO.ViewModels;
using Raven.Client.Indexes;

namespace DataAccess.RavenDb.Transformers
{
    public class ProductTransformer : AbstractTransformerCreationTask<Category>
    {
        public ProductTransformer()
        {
            TransformResults = categories => categories
                .SelectMany(c => c.Products)
                .Select(p => new ProductView
                {
                    id = p.Id.ToString(),
                    title = p.Name,
                    imageUrl = p.ImageUrl
                });
        }
    }
}
