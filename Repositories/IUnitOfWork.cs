namespace Repositories
{
   public interface IUnitOfWork
   {
      int Commit();
      int Commit(bool acceptAllChangesOnSuccess);
      Task<int> Commit(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
      Task<int> CommitAsync(CancellationToken cancellationToken = default);
   }
}