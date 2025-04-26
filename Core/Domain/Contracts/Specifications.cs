using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public abstract class Specifications<T> where T : class
    {
        public Expression<Func<T,bool>>? Criteria { get; } //Where 
        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = new();
        protected Specifications(Expression<Func<T, bool>>? criteria)
        {
            Criteria = criteria;
        }
        protected void AddInclude(Expression<Func<T, object>> expression)
        {
            IncludeExpressions.Add(expression);
        }

        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDesc { get; private set; }
        protected void SetOrderBy(Expression<Func<T, object>> expression)
        {
            OrderBy = expression;
        }
        protected void SetOrderByDesc(Expression<Func<T, object>> expression)
        {
            OrderByDesc = expression;
        }

        public int Skip { get; private set; }
        public int Take { get; private set; }
        public bool IsPaginated { get; private set; }
        protected void ApplyPagination(int PageIndex , int PageSize)
        {
            IsPaginated = true;
            Take = PageSize;
            Skip = (PageIndex - 1) * PageSize;
        }
    }
}
