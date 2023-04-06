using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Models.Extensions
{
   public static class DbContextExtension
   {
      public static IServiceCollection AddDbContextDatabaseContext(this IServiceCollection services)
      {
         services.AddDbContext<DatabaseContext>(config =>
         {
            config.UseMySql
            (
               "server=localhost;user=root;password=senha;database=schema_example",
               new MySqlServerVersion(new Version(8, 0, 31))
            );
         });
         return services;
      }
   }
}
