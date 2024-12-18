using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISpecificRepository<T>
    {
        Expression<Func<T,bool>>? Criteria { get; }
        Expression<Func<T,object>>? Orderby { get; }
        Expression<Func<T,object>>? OrderbyDesending { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; } // For ThenInclude
        bool IsDistinvt {  get; }
        int Take {  get; }
        int Skip {  get; }
        bool IspagingEnable {  get; }

        IQueryable<T> ApplyCriteria(IQueryable<T> query);
       
    }
    public interface ISpecificRepository<T,Tresult> : ISpecificRepository<T>
    {
        Expression<Func<T, Tresult>>? Select { get; }
    }
}
