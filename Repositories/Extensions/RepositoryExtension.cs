using Microsoft.Extensions.DependencyInjection;

namespace Repositories.Extensions
{
   public static class RepositoryExtension
   {
      public static IServiceCollection AddRepositories(this IServiceCollection services)
      {
         services.AddScoped<IUnitOfWork, UnitOfWork>();
         services.AddScoped<IRepositoryCar, RepositoryCar>();
         return services;
      }      
   }
}
