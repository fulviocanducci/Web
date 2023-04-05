namespace Repositories.Interfaces
{
   public interface IInsert<T> where T : class, new()
   {
      void Insert(T model);
      Task InsertAsync(T Model);
   }
}
