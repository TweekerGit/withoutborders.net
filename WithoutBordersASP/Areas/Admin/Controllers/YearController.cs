using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WithoutBorders.Core.Repository;
using WithoutBorders.Data.Entities;
using WithoutBordersASP.Models.Dto;

namespace WithoutBordersASP.Areas.Admin.Controllers
{
    [Area("admin")]
    public class YearController : Controller
    {
        private readonly IRepository<int, Year> yearRepo;

        public YearController(IRepository<int, Year> yearRepo) => this.yearRepo = yearRepo;

        [HttpGet("/years/create")]
        public IActionResult Create() => View(new YearDto(new Year()));

        [HttpPost("/year/create")]
        public async Task<RedirectToActionResult> Createpost(YearDto data)
        {
            yearRepo.Create(data.ToEntitySimple());
            await yearRepo.SaveAsync();
            return RedirectToAction("All");
        }

        [HttpGet("/years")]
        public async Task<IActionResult> All()
        {
            IEnumerable<Year> data = await yearRepo.GetAllAsync(y => y.Camps);
            return View(data.Select(d => new YearDto(d)));
        }

        [HttpGet("/year/edit/{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            // Console.WriteLine("YESSSSSSSSSSS");
            var entity = new YearDto(await yearRepo.GetByIdAsync(id));
            return View(entity);
        }
        
        [HttpPost("/year/edit")]
        public async Task<IActionResult> EditPost([FromForm] YearDto year)
        {
            yearRepo.Update(year.ToEntitySimple());
            await yearRepo.SaveAsync();
            return RedirectToAction("All");
        }

        [HttpGet("/year/delete")]
        public async Task<RedirectToActionResult> Delete(int deleteId)
        {
            yearRepo.Delete(new Year{Id = deleteId});
            await yearRepo.SaveAsync();
            return RedirectToAction("All");
        }
    }
}