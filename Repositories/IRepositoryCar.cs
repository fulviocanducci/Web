using Models;
using Repositories.Interfaces;

namespace Repositories
{
   public interface IRepositoryCar: IInsert<Car>, IUpdate<Car>, IDelete<Car>, IAll<Car>, IFirstOrDefault<Car>, IPage<Car>
   {

   }
}