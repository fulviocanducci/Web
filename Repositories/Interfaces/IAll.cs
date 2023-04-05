namespace Repositories.Interfaces
{
   public interface IAll<T> where T : class, new()
   {
      IEnumerable<T> All();
      Task<IEnumerable<T>> AllAsync();
   }
}
