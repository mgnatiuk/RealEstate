using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected RealEstateDbContext Context;

        public AsyncRepository(RealEstateDbContext context)
        {
            Context = context;
        }

        public async Task<T> GetById(Guid id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task Add(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll(RequestPaginationQuery query)
        {
            return await GetQueryWithPagination(query, Context.Set<T>());
        }

        public async Task<IEnumerable<T>> GetWhere(RequestPaginationQuery query, Expression<Func<T, bool>> predicate)
        {
            return await GetQueryWithPagination(query, Context.Set<T>().Where(predicate));
        }

        public Task<int> CountAll()
        {
            return Context.Set<T>().CountAsync();
        }

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().CountAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllWithIncludes(RequestPaginationQuery query, List<string> includes)
        {
            var queryResult = Context.Set<T>().AsQueryable();

            foreach (string include in includes)
            {
                queryResult = queryResult.Include(include);
            }

            return await GetQueryWithPagination(query, queryResult);
        }

        private async Task<IEnumerable<T>> GetQueryWithPagination(RequestPaginationQuery query, IQueryable<T> queryData)
        {
            queryData = queryData
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .AsQueryable();

            return await queryData.ToListAsync();
        }
    }
}
