using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WithoutBorders.Core.Repository;
using WithoutBorders.Data.Entities;

namespace WithoutBordersASP.Areas.Admin.Controllers
{
    [Area("admin")]
    public class MentorsController : Controller
    {
        public readonly IRepository<int, Mentor> mentorRepo;

        public MentorsController(IRepository<int, Mentor> mentorRepo)
        {
            this.mentorRepo = mentorRepo;
        }

        [HttpGet("/mentors/all")]
        public async Task<IActionResult> All() => View(await mentorRepo.GetAllAsync());

        [HttpGet("/mentors/edit/{id:int}")]
        public async Task<IActionResult> Edit(int id) => View(await mentorRepo.GetByIdAsync(id));

        [HttpPost("/mentor/edit")]
        public async Task<RedirectToActionResult> EditPost(Mentor data)
        {
            mentorRepo.Update(data);
            await mentorRepo.SaveAsync();
            return RedirectToAction("All");
        }

        [HttpGet("/mentors/create")]
        public IActionResult Create() => View(new Mentor());

        [HttpPost("/mentor/create")]
        public async Task<RedirectToActionResult> CreatePost(Mentor data)
        {
            mentorRepo.Create(data);
            await mentorRepo.SaveAsync();
            return RedirectToAction("All");
        }

        [HttpGet("/mentors/delete")]
        public async Task<RedirectToActionResult> Delete(int id)
        {
            mentorRepo.Delete(id);
            await mentorRepo.SaveAsync();
            return RedirectToAction("All");
        }

    }
}