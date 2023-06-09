using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KyivRP.Domain.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateOrUpdate(T model);

        Task<T[]> Getall();

        Task<T> GetById(Guid id);

        Task<T> GetByPredicate(Expression<Func<T, bool>> predicate);

        Task Delete(T model);
    }
}
