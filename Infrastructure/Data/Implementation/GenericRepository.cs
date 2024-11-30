using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Implementation
{
    public class GenericRepository<T>(EcommerceContext ecommerceContextg) : IgenericRepository<T> where T : BaseEntity
    {
        public void Add(T entity)
        {
            ecommerceContextg.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            ecommerceContextg.Set<T>().Remove(entity);
        }

        public bool Exists(int id)
        {
            return ecommerceContextg.Set<T>().Any(e =>e.Id == id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await ecommerceContextg.Set<T>().FindAsync(id);

        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await ecommerceContextg.Set<T>().ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await ecommerceContextg.SaveChangesAsync() >0 ;
        }

        public void Update(T entity)
        {
            ecommerceContextg.Set<T>().Attach(entity);
            ecommerceContextg.Entry(entity).State = EntityState.Modified;
        }
    }
}
