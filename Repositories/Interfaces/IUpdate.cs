namespace Repositories.Interfaces
{
   public interface IUpdate<T> where T : class, new()
   {
      void Update(T model);      
   }
}
