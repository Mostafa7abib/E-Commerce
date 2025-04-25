using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<T> GetQuery<T>(IQueryable<T> inputQuery, Specifications<T> specifications) where T : class
        {
            var query = inputQuery;
            if (specifications.Criteria is { })
            {
                query = query.Where(specifications.Criteria);
            }
            foreach (var item in specifications.IncludeExpressions)
            {
                query = query.Include(item);
            }
            if (specifications.OrderBy is { })
            {
                query = query.OrderBy(specifications.OrderBy);
            }
            else if (specifications.OrderByDesc is { })
            {
                query = query.OrderByDescending(specifications.OrderByDesc);
            }
            if(specifications.IsPaginated)
            {
                query = query.Skip(specifications.Skip).Take(specifications.Take);
            } 
            return query; 
        }
    }
}
