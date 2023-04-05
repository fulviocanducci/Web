namespace Repositories.Interfaces
{
   public interface IFirstOrDefault<T> where T : class, new()
   {
      T? FirstOrDefault(params object[] keys);
      Task<T?> FirstOrDefaultAsync(params object[] keys);
   }
}
