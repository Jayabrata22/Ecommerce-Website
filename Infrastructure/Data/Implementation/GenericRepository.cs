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

        public async Task<int> CountAsync(ISpecificRepository<T> specific)
        {
            var query = ecommerceContextg.Set<T>().AsQueryable();
            query = specific.ApplyCriteria(query);

            return await query.CountAsync();
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

        public async Task<T?> getEntitywithSpecification(ISpecificRepository<T> spec)
        {
            return await ApplySpecifation(spec).FirstOrDefaultAsync();
        }

        public async Task<TResult?> getEntitywithSpecification<TResult>(ISpecificRepository<T, TResult> spec)
        {
            return  await ApplySpecifationn(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await ecommerceContextg.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecificRepository<T> spec)
        {
            return await ApplySpecifation(spec).ToListAsync();
        }

        public async Task<IReadOnlyList<TResult>> ListAlllAsync<TResult>(ISpecificRepository<T, TResult> spec)
        {
            return  await ApplySpecifationn(spec).ToListAsync();
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

        private IQueryable<T> ApplySpecifation(ISpecificRepository<T> spec)
        {
            return SpecificationEvaluator<T>.getQuery(ecommerceContextg.Set<T>().AsQueryable(), spec);
        }

        private IQueryable<TResult> ApplySpecifationn<TResult>(ISpecificRepository<T, TResult> spec)
        {
            return SpecificationEvaluator<T>.getQuery<T,TResult>(ecommerceContextg.Set<T>().AsQueryable(), spec);
        }

        public Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecificRepository<T, TResult> spec)
        {
            throw new NotImplementedException();
        }
    }
}
