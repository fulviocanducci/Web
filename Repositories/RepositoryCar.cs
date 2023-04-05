using Canducci.Pagination;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;
namespace Repositories
{
   public class RepositoryCar : IRepositoryCar
   {
      private readonly DatabaseContext _context;

      public RepositoryCar(DatabaseContext context)
      {
         _context = context;
      }

      public IEnumerable<Car> All()
      {
         return _context.Car;
      }

      public async Task<IEnumerable<Car>> AllAsync()
      {
         return await _context.Car.ToListAsync();
      }

      public void Delete(Car model)
      {
         _context.Car.Remove(model);
      }

      public void Delete(IEnumerable<Car> models)
      {
         _context.Car.RemoveRange(models);
      }

      public Car? FirstOrDefault(params object[] keys)
      {
         return _context.Car.Find(keys);
      }

      public async Task<Car?> FirstOrDefaultAsync(params object[] keys)
      {
         return await _context.Car.FindAsync(keys);
      }

      public void Insert(Car model)
      {
         _context.Car.Add(model);
      }

      public async Task InsertAsync(Car Model)
      {
         await _context.Car.AddAsync(Model);
      }

      public Paginated<Car> Page<TKey>(int pageNumber, int pageSize = 10)
      {
         return _context.Car.ToPaginated(pageNumber, pageSize);
      }

      public Paginated<Car> Page<TKey>(Expression<Func<Car, TKey>> orderBy, int pageNumber, int pageSize = 10)
      {
         return _context.Car.OrderBy(orderBy).ToPaginated(pageNumber, pageSize);
      }

      public Paginated<Car> Page<TKey>(Expression<Func<Car, TKey>> orderBy, Expression<Func<Car, bool>> where, int pageNumber, int pageSize = 10)
      {
         return _context.Car.Where(where).OrderBy(orderBy).ToPaginated(pageNumber, pageSize);
      }

      public Task<Paginated<Car>> PageAsync<TKey>(int pageNumber, int pageSize = 10)
      {
         return _context.Car.ToPaginatedAsync(pageNumber, pageSize);
      }

      public Task<Paginated<Car>> PageAsync<TKey>(Expression<Func<Car, TKey>> orderBy, int pageNumber, int pageSize = 10)
      {
         return _context.Car.OrderBy(orderBy).ToPaginatedAsync(pageNumber, pageSize);
      }

      public Task<Paginated<Car>> PageAsync<TKey>(Expression<Func<Car, TKey>> orderBy, Expression<Func<Car, bool>> where, int pageNumber, int pageSize = 10)
      {
         return _context.Car.Where(where).OrderBy(orderBy).ToPaginatedAsync(pageNumber, pageSize);
      }

      public void Update(Car model)
      {
         _context.Car.Update(model);
      }
   }
}