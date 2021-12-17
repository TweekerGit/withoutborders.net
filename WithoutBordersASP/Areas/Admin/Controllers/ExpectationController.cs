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
    public class ExpectationController : Controller
    {
        private IRepository<int, Expectation> expRepo;
        private IRepository<int, MainEntity> mainRepo;

        public ExpectationController(IRepository<int, Expectation> expRepo, IRepository<int, MainEntity> mainRepo)
        {
            this.expRepo = expRepo;
            this.mainRepo = mainRepo;
        }

        [HttpGet("/expectations/create")]
        public IActionResult Create(int redirectId, int mainId)
        {
            ViewBag.Id = redirectId;
            ViewBag.mainId = mainId;
            var exp = new Expectation();
            return View(exp);
        }

        [HttpPost("/expectation/create")]
        public async Task<RedirectToActionResult> CreatePost(Expectation data, int redirectId)
        {
            expRepo.Create(data);
            await expRepo.SaveAsync();
            return RedirectToAction("ById", new {id = redirectId});
        }

        [HttpGet("/expectations/{id:int}")]
        public async Task<IActionResult> ById(int id, int returnId)
        {
            ViewBag.returnId = returnId;
            ViewBag.returnExpId = id;
            var data = await mainRepo.GetByIdAsync(id, m => m.Expectations);
            ViewBag.MainId = data.Id;
            return View(data.Expectations);
        }

        [HttpGet("/expectations/edit/{codeword}")]
        public async Task<IActionResult> Edit(string codeword, int redirectId, int mainId)
        {
            ViewBag.someId = redirectId;
            ViewBag.MainId = mainId;
            var data = await expRepo.GetByFilterAsync(e => e.Expression == codeword);
            return View(data.FirstOrDefault());
        }

        [HttpPost("/expectation/edit")]
        public async Task<RedirectToActionResult> EditPost(Expectation data, int redirectId)
        {
            // Console.WriteLine("IDIDIDIDIDIDIDI");
            expRepo.Update(data);
            await expRepo.SaveAsync();
            return RedirectToAction("ById", new {id = redirectId});
        }

        [HttpGet("/expectation/delete")]
        public async Task<RedirectToActionResult> Delete(int idDelete, int redirectId)
        {
            expRepo.Delete(new Expectation {Id = idDelete});
            await expRepo.SaveAsync();
            return RedirectToAction("ById", new {id = redirectId});
        }
    }
}