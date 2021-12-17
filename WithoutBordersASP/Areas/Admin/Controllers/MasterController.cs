using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WithoutBorders.Core.Repository;
using WithoutBorders.Data.Entities;
using WithoutBordersASP.Models.Dto;

namespace WithoutBordersASP.Areas.Admin.Controllers
{
    [Area("admin")]
    public class MasterController : Controller
    {
        private readonly IRepository<int, MainEntity> mainRepo;
        private readonly IRepository<int, SelectedMain> selectedRepo;

        public MasterController(IRepository<int, MainEntity> mainRepo, IRepository<int, SelectedMain> selectedRepo)
        {
            this.mainRepo = mainRepo;
            this.selectedRepo = selectedRepo;
        }
        
        [HttpGet("/masters")]
        public async Task<IActionResult> All()
        {
            // Console.WriteLine("=====================");
            // var qwerty = await selectedRepo.GetAllAsync();
            // SelectedMain? first = qwerty.FirstOrDefault();
            // Console.WriteLine(first.MainId);
            // Console.WriteLine("=====================");

            IEnumerable<MainEntity> data = await mainRepo.GetAllAsync(m => m.Expectations);
            return View(data.Select(d => new MainEntityDto(d)).ToList());
        }

        [HttpGet("/masters/create")]
        public IActionResult Create() => View(new MainEntityDto(new MainEntity()));

        [HttpPost]
        public async Task<IActionResult> CreatePost(MainEntityDto data)
        {
            mainRepo.Create(data.ToEntitySimple());
            await mainRepo.SaveAsync();
            return RedirectToAction("All");
        }

        [HttpGet("/masters/edit/{id:int?}")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.returnId = id;
            var entity = new MainEntityDto(await mainRepo.GetByIdAsync(id, m=>m.Expectations));
            return View(entity);
        }

        [HttpPost("/master/edit")]
        public async Task<IActionResult> EditPost(MainEntityDto main)
        {
            // Console.WriteLine("========================");
            // Console.WriteLine($"Id: {main.Id}");
            // Console.WriteLine($"Left: {main.LeftTitle}");
            // Console.WriteLine($"Right: {main.RightTitle}");
            // Console.WriteLine($"LeftPhoto: {main.LeftTitlePhoto}");
            // Console.WriteLine($"RightPhoto: {main.RightTitlePhoto}");
            // Console.WriteLine($"About: {main.About}");
            // Console.WriteLine($"AboutPhoto: {main.AboutPhoto}");
            // Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
            // for (int i = 0; i < main.Expectations.Count; i++)
            // {
            //     Console.WriteLine($"Expectation-{i}: {main.Expectations[i].Expression}");
            // }
            // Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
            // Console.WriteLine("========================");


            if (!ModelState.IsValid) return this.StatusCode(505);
            mainRepo.Update(main.ToEntitySimple());
            await mainRepo.SaveAsync();
            return RedirectToAction(nameof(All));
        }

        [HttpGet("/master/delete")]
        public async Task<RedirectToActionResult> Delete(int deleteId)
        {
            mainRepo.Delete(deleteId);
            await mainRepo.SaveAsync();
            return RedirectToAction("All");
        }

        [HttpGet("/masters/select")]
        public async Task<IActionResult> EditSelectedMain()
        {
            var data = await selectedRepo.GetAllAsync();
            var mains = await mainRepo.GetAllAsync();
            List<int> mainsId = new List<int>();
            foreach (var main in mains) mainsId.Add(main.Id);
            SelectList ids = new SelectList(mainsId);
            ViewData["mains"] = ids;
            return View(data.FirstOrDefault());
        }

        [HttpPost("masters/selected")]
        public async Task<RedirectToActionResult> EditSelectedPost(SelectedMain data)
        {
            selectedRepo.Update(data);
            await selectedRepo.SaveAsync();
            return RedirectToAction("All");
        }
        
    }
}