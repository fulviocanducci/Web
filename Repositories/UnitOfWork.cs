using Models;
namespace Repositories
{
   public sealed class UnitOfWork : IUnitOfWork
   {
      private readonly DatabaseContext _context;

      public UnitOfWork(DatabaseContext context)
      {
         _context = context;
      }

      public int Commit()
      {
         return _context.SaveChanges();
      }

      public int Commit(bool acceptAllChangesOnSuccess)
      {
         return _context.SaveChanges(acceptAllChangesOnSuccess);
      }

      public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
      {
         return await _context.SaveChangesAsync(cancellationToken);
      }

      public async Task<int> Commit(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
      {
         return await _context.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
      }
   }
}
