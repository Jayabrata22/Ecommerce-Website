using Core.Interfaces;
using Infrastructure.Data.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Implementation
{
    public class BaseSpecificRepository<T>(Expression<Func<T, bool>>? criteria) : ISpecificRepository<T>
    {
        private readonly Expression<Func<T, bool>> criteria = criteria;
        protected BaseSpecificRepository() : this(null) { }
        public Expression<Func<T, bool>> Criteria => criteria;

        public Expression<Func<T, object>>? Orderby { get; private set; }

        public Expression<Func<T, object>>? OrderbyDesending { get; private set; }

        public bool IsDistinvt { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IspagingEnable { get; private set; }

        public List<Expression<Func<T, object>>> Includes { get; } = [];

        public List<string> IncludeStrings { get; } = [];

        public IQueryable<T> ApplyCriteria(IQueryable<T> query)
        {
            if (criteria != null)
            {
                query = query.Where(criteria);
            }
            return query;
        }

        protected void AddOrderby(Expression<Func<T, object>> orderByexpression)
        {
            Orderby = orderByexpression;

        }

        protected void AddOrderbyDesc(Expression<Func<T, object>> orderByDescxpression)
        {
            OrderbyDesending = orderByDescxpression;
        }
        protected void ApplyDistinct()
        {
            IsDistinvt = true;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IspagingEnable = true;
        }
    }

}

public class BaseSpecificRepository<T, TResult>(Expression<Func<T, bool>> criteria) : BaseSpecificRepository<T>(criteria), ISpecificRepository<T, TResult>
{
    protected BaseSpecificRepository() : this(null!) { }
    public Expression<Func<T, TResult>>? Select { get; private set; }

    protected void AddSelect(Expression<Func<T, TResult>> selectExpression)
    {
        Select = selectExpression;
    }

}
