using Canducci.Pagination;
using Models;
using System.Linq.Expressions;
namespace Repositories.Interfaces
{
   public interface IPage<T> where T : class, new()
   {
      Paginated<T> Page(int pageNumber, int pageSize = 10);
      Paginated<T> Page<TKey>(Expression<Func<T, TKey>> orderBy, int pageNumber, int pageSize = 10);
      Paginated<T> Page<TKey>(Expression<Func<Car, TKey>> orderBy, Expression<Func<Car, bool>> where, int pageNumber, int pageSize = 10);
      Task<Paginated<T>> PageAsync(int pageNumber, int pageSize = 10);
      Task<Paginated<T>> PageAsync<TKey>(Expression<Func<Car, TKey>> orderBy, int pageNumber, int pageSize = 10);
      Task<Paginated<T>> PageAsync<TKey>(Expression<Func<Car, TKey>> orderBy, Expression<Func<Car, bool>> where, int pageNumber, int pageSize = 10);
   }
}