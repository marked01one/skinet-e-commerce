using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  // Handles the logic for our query specifications
  public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
  {
    public static IQueryable<TEntity> GetQuery(
      IQueryable<TEntity> inputQuery,
      ISpecification<TEntity> spec
    )
    {
      var query = inputQuery;

      // Check if criteria has been given
      if (spec.Criteria != null)
      {
        // .Where() methods looks for items in query that satisfy the condition inside the brackets
        query = query.Where(spec.Criteria);
      }

      if (spec.OrderBy != null)
      {
        query = query.OrderBy(spec.OrderBy);
      }

      if (spec.OrderByDescending != null)
      {
        query = query.OrderByDescending(spec.OrderByDescending);
      }

      if (spec.IsPagingEnabled)
      {
        query = query.Skip(spec.Skip).Take(spec.Take);
      }
      // Aggregate our `Include` expressions, i.e. (x => x.ProductType)
      query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
      return query;
    }
  }
}