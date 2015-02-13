using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Data;
using Domain.Model;
using Raven.Client;

namespace DataAccess.RavenDB
{
    public class RavenRepository<TEntity> : IRepositoy<TEntity> where TEntity : EntityBase
    {
        private IDocumentSession Session { get; set; }

        public RavenRepository(IDocumentSession session)
        {
            Session = session;
        }

        public void Add(TEntity entity)
        {
            Session.Store(entity);
        }

        public void Modify(TEntity entity)
        {
            Session.Store(entity);
        }

        public void Delete(TEntity entity)
        {
            Session.Delete(entity);
        }

        public TEntity FindById(Guid id)
        {
           return Session.Load<TEntity>(id);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
           return Session.Query<TEntity>().First(expression);
        }

        public IQueryable<TEntity> Query()
        {
            return Session.Query<TEntity>();
        }
    }
}
