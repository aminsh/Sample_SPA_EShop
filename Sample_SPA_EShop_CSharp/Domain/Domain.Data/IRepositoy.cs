using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Model;

namespace Domain.Data
{
    public interface IRepositoy<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity entity);
        void Modify(TEntity entity);
        void Delete(TEntity entity);
        TEntity FindById(Guid id);
        TEntity Find(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> Query();
    }
}
