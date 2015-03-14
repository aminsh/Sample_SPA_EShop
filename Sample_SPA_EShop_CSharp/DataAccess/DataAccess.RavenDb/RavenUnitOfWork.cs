using System;
using System.Linq;
using System.Security.Cryptography;
using DataAccess.RavenDb;
using DataAccess.RavenDb.Transformers;
using Domain.Data;
using Domain.Model;
using Raven.Abstractions.Extensions;
using Raven.Abstractions.Indexing;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace DataAccess.RavenDB
{
    public class RavenUnitOfWork : IUnitOfWork
    {
        private static readonly IDocumentStore DocumentStore;
        private IDocumentSession Session { get; set; }

        static RavenUnitOfWork()
        {
            DocumentStore = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "EshopDb"
            }.Initialize();
        }

        public RavenUnitOfWork()
        {
            Session = DocumentStore.OpenSession();
        }

        public void Commit()
        {
            Session.SaveChanges();
        }

        public IRepositoy<TEntity> GetRepository<TEntity>() where TEntity : EntityBase
        {
            return new RavenRepository<TEntity>(Session);
        }
    }
}
