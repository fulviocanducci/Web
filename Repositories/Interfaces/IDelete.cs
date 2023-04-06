using Models;

namespace Repositories.Interfaces
{
   public interface IDelete<T> where T : class, new()
   {
      void Delete(T model);
      void Delete(IEnumerable<T> models);
      void Delete<TKey>(TKey value);
   }
}
