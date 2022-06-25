using Microsoft.AspNetCore.Mvc;
using My.DataAccess.Repository.IRepository;
using MyMVC.Models;
using MyMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SeasonController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeasonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int seasonPage = 1)
        {
            SeasonVM seasonVM = new SeasonVM()
            {
                Seasons = await _unitOfWork.Season.GetAllAsync()
            };

            var count = seasonVM.Seasons.Count();
            seasonVM.Seasons = seasonVM.Seasons.OrderBy(p => p.Name)
                .Skip((seasonPage - 1) * 2).Take(2).ToList();

            seasonVM.PagingInfo = new PagingInfo
            {
                CurrentPage = seasonPage,
                ItemsPerPage = 2,
                TotalItem = count,
                urlParam = "/Admin/Season/Index/"
            };

            return View(seasonVM);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Season season = new Season();
            if (id == null)
            {
                //this is for create
                return View(season);
            }
            //this is for edit
            season = await _unitOfWork.Season.GetAsync(id.GetValueOrDefault());
            if (season == null)
            {
                return NotFound();
            }
            return View(season);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Season season)
        {
            if (ModelState.IsValid)
            {
                if (season.Id == 0)
                {
                    await _unitOfWork.Season.AddAsync(season);

                }
                else
                {
                    _unitOfWork.Season.Update(season);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(season);
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.Season.GetAllAsync();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Season.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting Category";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.Season.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = "Category successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }

    }
}




#endregion