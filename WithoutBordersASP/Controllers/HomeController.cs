using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WithoutBorders.Core.Repository;
using WithoutBorders.Data.Entities;
using WithoutBordersASP.Models;
using WithoutBordersASP.Models.Dto;

namespace WithoutBordersASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<int, Kid> kidRepo;
        private readonly IRepository<int, Mentor> mentorRepo;
        private readonly IRepository<int, MainEntity> mainRepo;
        private readonly IRepository<int, SelectedMain> selectedRepo;

        public HomeController(IRepository<int, Kid> kidRepo, IRepository<int, Mentor> mentorRepo, IRepository<int, MainEntity> mainRepo, IRepository<int, SelectedMain> selectedRepo)
        {
            this.kidRepo = kidRepo;
            this.mainRepo = mainRepo;
            this.mentorRepo = mentorRepo;
            this.selectedRepo = selectedRepo;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var select = await selectedRepo.GetAllAsync();
            SelectedMain? first = select.FirstOrDefault();
            MainEntity data = await mainRepo.GetByIdAsync(first.MainId,m=>m.Expectations);
            MainsKidModel model = new MainsKidModel
            {
                _main = new MainEntityDto(data),
                _kid = new Kid()
            };
            return View(model);
        }

        [HttpPost("/addKid")]
        public async Task<RedirectToActionResult> AddKid(MainsKidModel data)
        {
            // Console.WriteLine("================");
            // Console.WriteLine(data._kid.Name);
            // Console.WriteLine(data._kid.Surname);
            // Console.WriteLine(data._kid.Age);
            // Console.WriteLine(data._kid.Sex);
            // Console.WriteLine(data._kid.Alergy);
            // Console.WriteLine(data._kid.Id);
            // Console.WriteLine(data._kid.Number);

            kidRepo.Create(data._kid);
            await kidRepo.SaveAsync();
            return RedirectToAction("Index");
        }

        [HttpGet("mentors")]
        public async Task<IActionResult> Mentors()
        {
            if (mentorRepo is null) return this.StatusCode(500);

            IEnumerable <Mentor> data = await mentorRepo.GetAllAsync();
            return View(data.ToList());
        }
    }
}