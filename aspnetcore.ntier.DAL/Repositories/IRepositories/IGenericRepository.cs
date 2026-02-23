using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using X.PagedList;

namespace aspnetcore.ntier.DAL.Repositories.IRepositories;

public interface IGenericRepository<T> where T : class, new()
{
    Task<T> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, CancellationToken cancellationToken = default);
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<int> DeleteAsync(T entity);
    Task<List<T>> AddRangeAsync(List<T> entity);
    Task<List<T>> UpdateRangeAsync(List<T> entity);
    Task<int> DeleteRangeAsync(Expression<Func<T, bool>> filter);
    void ClearChangeTracker();
    IPagedList<T> GetListPaginationAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, CancellationToken cancellationToken = default, int pageNumber = 1, int pageSize = 100);
}
