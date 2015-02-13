using Domain.Data;
using Domain.Model;
using Raven.Client;
using Raven.Client.Document;

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
