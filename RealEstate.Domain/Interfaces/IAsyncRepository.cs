using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Domain.Interfaces
{
    public interface IAsyncGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetById(Guid id);
        Task<T> GetByIdWithIncludes(Guid id, List<string> includes);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);

        Task<IEnumerable<T>> GetAll(RequestPaginationQuery query);
        Task<IEnumerable<T>> GetWhere(RequestPaginationQuery query, Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllWithIncludes(RequestPaginationQuery query, List<string> includes);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}
