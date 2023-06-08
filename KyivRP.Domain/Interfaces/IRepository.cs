using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KyivRP.Domain.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateOrUpdate(T model);

        Task<T[]> Getall();

        Task<T> GetById(Guid id);

        Task Delete(T model);
    }
}
