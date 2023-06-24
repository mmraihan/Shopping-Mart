using Microsoft.EntityFrameworkCore;
using ShoppingMart.Core.Entities;
using ShoppingMart.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMart.Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria is not null)
            {
                query = query.Where(spec.Criteria);
            }
            query = spec.Includes.Aggregate(query,(current, include)=>current.Include(include));
            return query;

        }
    }
}
