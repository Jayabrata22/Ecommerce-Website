using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IgenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecificRepository<T> spec);
        Task<T?> getEntitywithSpecification(ISpecificRepository<T> spec);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveAllAsync();
        bool Exists(int id);
        Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecificRepository<T , TResult> spec);
        Task<TResult?> getEntitywithSpecification<TResult>(ISpecificRepository<T, TResult> spec);
    }
}
