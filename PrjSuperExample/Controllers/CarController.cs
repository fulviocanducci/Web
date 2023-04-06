using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
namespace PrjSuperExample.Controllers
{
   public class CarController : Controller
   {
      private readonly IRepositoryCar _repository;
      private readonly IUnitOfWork _unitOfWork;

      public CarController(IRepositoryCar repository, IUnitOfWork unitOfWork)
      {
         _repository = repository ?? throw new ArgumentNullException(nameof(repository));
         _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
      }

      #region Routines
      protected async Task<Car?> GetCarByIdAsync(int id)
      {
         return await _repository.FirstOrDefaultAsync(id);
      }

      protected async Task<ActionResult> GetCarViewAsync(int id)
      {
         var model = await GetCarByIdAsync(id);
         if (model != null)
         {
            return View(model);
         }
         return RedirectToAction(nameof(Index));
      }
      #endregion

      public async Task<ActionResult> Index(int? current)
      {
         var page = await _repository.PageAsync(o => o.Name, current ?? 1);
         return View(page);
      }

      public async Task<ActionResult> Details(int id)
      {
         return await GetCarViewAsync(id);
      }

      public ActionResult Create()
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Create(Car model)
      {
         try
         {
            if (ModelState.IsValid)
            {
               _repository.Insert(model);
               await _unitOfWork.CommitAsync();
               return RedirectToAction(nameof(Edit), new { model.Id });
            }
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View(model);
         }
      }

      public async Task<ActionResult> Edit(int id)
      {
         return await GetCarViewAsync(id);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Edit(Car model)
      {
         try
         {
            if (ModelState.IsValid)
            {
               _repository.Update(model);
               await _unitOfWork.CommitAsync();
            }
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View(model);
         }
      }

      public async Task<ActionResult> Delete(int id)
      {
         return await GetCarViewAsync(id);
      }

      [HttpPost]
      [ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> DeleteModel(int id)
      {
         try
         {
            _repository.Delete(id);
            await _unitOfWork.CommitAsync();
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }
   }
}
