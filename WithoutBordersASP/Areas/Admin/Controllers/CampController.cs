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
    public class CampController : Controller
    {
        private readonly IRepository<int, Camp> campRepo;
        private readonly IRepository<int, Year> yearRepo;

        public CampController(IRepository<int, Camp> campRepo, IRepository<int, Year> yearRepo)
        {
            this.campRepo = campRepo;
            this.yearRepo = yearRepo;
        }

        [HttpGet("/camps/create")]
        public async Task<IActionResult> Create(int yearID)
        {
            var yearsList = await yearRepo.GetAllAsync();
            // IDictionary<int, string> years = new Dictionary<int, string>();
            // foreach (var yearTemp in yearsList) years.Add(yearTemp.Id, yearTemp.Name);
            // ViewData["years"] = years;
            var year = await yearRepo.GetByIdAsync(yearID, y => y.Camps);
            return View(new CampDto(new Camp(year)));
        }

        [HttpPost("camp/create")]
        public async Task<RedirectToActionResult> CreatePost(CampDto data)
        {
            // Console.WriteLine("==========");
            // Console.WriteLine(data.YearId);
            // Console.WriteLine("==========");

            // data.Year = await yearRepo.GetByIdAsync(yearId);
            campRepo.Create(data.ToEntitySimple());
            await campRepo.SaveAsync();
            return RedirectToAction("All", "Year");
        }

        [HttpGet("/camps/edit")]
        public async Task<IActionResult> Edit(int yearId, string codeWord)
        {
            var yearsList = await yearRepo.GetAllAsync();
            var years = yearsList.Select(year => year.Id).ToList();
            var selectList = new SelectList(years);
            // foreach (var iYear in years)
            // {
            //     Console.WriteLine("===================");
            //     Console.WriteLine($"Key => {iYear.Key}\nValue => {iYear.Value}");
            //     Console.WriteLine("===================");
            // }
            ViewData["years"] = selectList;
            var temp = await yearRepo.GetByIdAsync(yearId, y => y.Camps);
            var foreignId = temp.Id;
            var data = await campRepo.GetByFilterAsync(c => c.YearId == foreignId, c => c.Year);
            return View(new CampDto(data.FirstOrDefault(d => d.Place == codeWord)));
        }

        [HttpPost("/camp/edit")]
        public async Task<RedirectToActionResult> EditPost(CampDto data)
        {
            Console.WriteLine("=======================");
            // Console.WriteLine($"ID: {data.Id}");
            // Console.WriteLine($"Name: {data.Name}");
            // Console.WriteLine($"Place: {data.Place}");
            Console.WriteLine($"YearId: {data.YearId}");
            // Console.WriteLine($"ViewBag.el: {ViewBag.el}");
            Console.WriteLine("=======================");

            campRepo.Update(data.ToEntitySimple());
            await campRepo.SaveAsync();
            return RedirectToAction("All", "Year");
        }

        [HttpGet("/camp/delete")]
        public async Task<RedirectToActionResult> Delete(int deleteId)
        {
            campRepo.Delete(new Camp {Id = deleteId});
            await campRepo.SaveAsync();
            return RedirectToAction("All", "Year");
        }
    }
}