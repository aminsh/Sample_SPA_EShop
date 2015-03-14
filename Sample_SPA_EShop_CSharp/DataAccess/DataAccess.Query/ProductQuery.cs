using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.RavenDb.Transformers;
using Domain.Model;
using DTO.Params;
using DTO.ViewModels;
using Raven.Abstractions.Linq;
using Raven.Client;
using Raven.Client.Document;
using Raven.Imports.Newtonsoft.Json.Linq;

namespace DataAccess.Query
{
    public static class ProductQuery
    {
        private static readonly IDocumentStore DocumentStore;

        static ProductQuery()
        {
            DocumentStore = DocumentStoreFactory.Instance();
        }
        public static IEnumerable<ProductView> Search(SearchParam param)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<Category>()
                    .TransformWith<ProductTransformer, ProductView>();
            }
        }
    }

    
}
