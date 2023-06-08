using KyivRP.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KyivRP.EntityFramework.Infrastracture
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        public async  Task CreateOrUpdate(T model)
        {
            using (var ctx = new DatabaseContext())
            {
                var existingEntity = await ctx.Set<T>().FirstOrDefaultAsync(x=>x.Id == model.Id);
                if (existingEntity != null)
                {
                    ctx.Entry(existingEntity).CurrentValues.SetValues(model);
                }
                else
                {
                    ctx.Set<T>().Add(model);
                }

                await ctx.SaveChangesAsync();
            }
        }

        public async Task Delete(T model)
        {
            using (var ctx = new DatabaseContext())
            {
                var existingEntity = await ctx.Set<T>().FirstOrDefaultAsync(x => x.Id == model.Id);
                if (existingEntity != null)
                {
                    ctx.Remove(existingEntity);
                    await ctx.SaveChangesAsync();
                }
            }
        }

        public async Task<T[]> Getall()
        {
            using (var ctx = new DatabaseContext())
            {
                return await ctx.Set<T>().ToArrayAsync();
            }
        }

        public async Task<T> GetById(Guid id)
        {
            using (var ctx = new DatabaseContext())
            {
                return await ctx.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}
