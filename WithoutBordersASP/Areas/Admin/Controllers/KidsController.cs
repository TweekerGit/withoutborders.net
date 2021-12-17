using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WithoutBorders.Core.Repository;
using WithoutBorders.Data.Entities;

namespace WithoutBordersASP.Areas.Admin.Controllers
{
    [Area("admin")]
    public class KidsController : Controller
    {
        private readonly IRepository<int, Kid> kidsRepo;

        public KidsController(IRepository<int, Kid> kidsRepo)
        {
            this.kidsRepo = kidsRepo;
        }

        [HttpGet("/kids")]
        public async Task<IActionResult> All()
        {
            var all = await this.kidsRepo.GetAllAsync();
            ViewBag.allKids = all.Count();
            return View(await kidsRepo.GetAllAsync());
        }

        [HttpGet("kids/edit/{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id) => View(await this.kidsRepo.GetByIdAsync(id));

        [HttpGet("kids/delete")]
        public async Task<RedirectToActionResult> Delete(int id)
        {
            this.kidsRepo.Delete(id);
            await this.kidsRepo.SaveAsync();
            return RedirectToAction("All");
        }

        [HttpPost("kid/edit")]
        public async Task<RedirectToActionResult> EditPost(Kid data)
        {
            this.kidsRepo.Update(data);
            await this.kidsRepo.SaveAsync();
            return RedirectToAction("All");
        }
    }
}