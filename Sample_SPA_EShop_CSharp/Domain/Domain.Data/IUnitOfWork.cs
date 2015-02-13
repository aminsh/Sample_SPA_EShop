using Domain.Model;

namespace Domain.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        IRepositoy<TEntity> GetRepository<TEntity>() where TEntity : EntityBase;     
    }
}
