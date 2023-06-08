using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KyivRP.Domain.Interfaces
{
    internal interface IRepository<T>
    {
        Task CreateOrUpdate(T model);

        Task<T[]> Getall();

        Task<T> GetById(Guid id);

        Task<T> Delete(T model);
    }
}
