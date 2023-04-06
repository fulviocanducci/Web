using Models.Extensions;
using Repositories.Extensions;
namespace PrjSuperExample
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);
         builder.Services.AddControllersWithViews();
         builder.Services.AddDbContextDatabaseContext();
         builder.Services.AddRepositories();
         builder.Services.Configure<RouteOptions>(options =>
         {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
         });
         var app = builder.Build();
         if (!app.Environment.IsDevelopment())
         {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
         }

         app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseRouting();
         app.UseAuthorization();
         app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
         app.Run();
      }
   }
}