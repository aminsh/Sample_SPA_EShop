using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.RavenDb.Transformers;
using Raven.Client;
using Raven.Client.Document;

namespace DataAccess.Query
{
    public static class DocumentStoreFactory
    {
        public static IDocumentStore Instance()
        {
            var store = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "EshopDb"
            }.Initialize();

            store.ExecuteTransformer(new ProductTransformer());

            return store;
        }
    }
}
