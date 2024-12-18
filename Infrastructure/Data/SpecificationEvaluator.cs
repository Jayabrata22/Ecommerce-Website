using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public  class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> getQuery(IQueryable<T> query, ISpecificRepository<T> sepc)
        {
            if(sepc.Criteria != null)
            {
                query = query.Where(sepc.Criteria);
            }

            if(sepc.Orderby != null)
            {
                query = query.OrderBy(sepc.Orderby);
            } 

            if(sepc.OrderbyDesending != null)
            {
                query = query.OrderByDescending(sepc.OrderbyDesending);
            }
            if (sepc.IsDistinvt)
            {
                query = query.Distinct();
            }

            if (sepc.IspagingEnable)
            {
                query = query.Skip(sepc.Skip).Take(sepc.Take);
            }
           
            return query;
        }
        public static IQueryable<TResult> getQuery<TSpec,TResult>(IQueryable<T> query, ISpecificRepository<T , TResult> sepc)
        {
            if (sepc.Criteria != null)
            {
                query = query.Where(sepc.Criteria);
            }

            if (sepc.Orderby != null)
            {
                query = query.OrderBy(sepc.Orderby);
            }

            if (sepc.OrderbyDesending != null)
            {
                query = query.OrderByDescending(sepc.OrderbyDesending);
            }

            var selectQuery = query as IQueryable<TResult>;
            if(sepc.Select != null)
            {
                selectQuery = query.Select(sepc.Select);
            }

            if (sepc.IsDistinvt)
            {
                selectQuery = selectQuery?.Distinct();
            }
            if (sepc.IspagingEnable)
            {
                selectQuery = selectQuery?.Skip(sepc.Skip).Take(sepc.Take);
            }
            return selectQuery ?? query.Cast<TResult>();
        }
    }
}
