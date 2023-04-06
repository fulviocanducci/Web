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
      
      public async Task<ActionResult> Index(int? current)
      {
         var page = await _repository.PageAsync(o => o.Name, current ?? 1);
         return View(page);
      }

      public async Task<ActionResult> Details(int id)
      {
         Car? model = await _repository.FirstOrDefaultAsync(id);
         if (model != null)
         {
            return View(model);
         }
         return RedirectToAction(nameof(Index));
      }

      public ActionResult Create()
      {
         return View("CreateOrUpdate");
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
         Car? model = await _repository.FirstOrDefaultAsync(id);
         if (model != null)
         {
            return View("CreateOrUpdate", model);
         }
         return RedirectToAction(nameof(Index));
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
         Car? model = await _repository.FirstOrDefaultAsync(id);
         if (model != null)
         {
            return View(model);
         }
         return RedirectToAction(nameof(Index));
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
