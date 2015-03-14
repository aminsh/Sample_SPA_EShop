using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace DataAccess.RavenDb
{
    public class ProductCountIndex : AbstractIndexCreationTask<Category, ProductCount>
    {
        public ProductCountIndex()
        {
            Map = categories => categories.Select(cat => new {CategoryId = cat.Id, Count = 1});
            Reduce = results => results.GroupBy(x => x.CategoryId)
                                   .Select(g =>
                                               new
                                               {
                                                   CategoryId = g.Key,
                                                   Count = g.Sum(x => x.Count)
                                               });
        }
    }

    public class ProductCount
    {
        public int CategoryId { get; set; }
        public int Count { get; set; }
    }
}
