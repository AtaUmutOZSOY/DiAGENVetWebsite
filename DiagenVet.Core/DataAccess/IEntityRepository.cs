using DiagenVet.Core.Entities;
using System.Linq.Expressions;

namespace DiagenVet.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T? Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>>? filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Any(Expression<Func<T, bool>> filter);
        int Count(Expression<Func<T, bool>>? filter = null);
    }
} 