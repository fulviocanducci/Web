using Microsoft.EntityFrameworkCore;
using Models.Mappings;

namespace Models
{
   public sealed class DatabaseContext : DbContext
   {
      public DatabaseContext(DbContextOptions options) : base(options)
      {
      }

      public DbSet<Car> Car { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new CarMapping());
      }
   }
}
