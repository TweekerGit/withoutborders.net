using System;
using System.Collections;
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
    public class PhotoController : Controller
    {
        private readonly IRepository<int, Photo> photoRepo;
        private readonly IRepository<int, Year> yearRepo;
        private readonly IRepository<int, Camp> campRepo;

        public PhotoController(IRepository<int, Photo> photoRepo,
            IRepository<int, Year> yearRepo, IRepository<int, Camp> campRepo)
        {
            this.photoRepo = photoRepo;
            this.campRepo = campRepo;
            this.yearRepo = yearRepo;
        }

        [HttpGet("/photos/create")]
        public IActionResult Create(int id, int returnId)
        {
            ViewBag.CampId = id;
            ViewBag.returnId = returnId;
            return View(new Photo());
        }

        [HttpPost("/photo/create")]
        public async Task<RedirectToActionResult> CreatePost(Photo data, int redirectId)
        {
            // Console.WriteLine("==============");
            // Console.WriteLine(data.Id);
            // Console.WriteLine(data.Url);
            // Console.WriteLine(data.CampId);
            // Console.WriteLine("==============");

            photoRepo.Create(data);
            await photoRepo.SaveAsync();
            return RedirectToAction("One", new {Id = redirectId});
        }

        [HttpGet("/photos")]
        public async Task<IActionResult> All()
        {
            IEnumerable<Year> data = await yearRepo.GetAllAsync(y => y.Camps);
            return View(data.Select(d => new YearDto(d)));
        }

        [HttpGet("/photos/{id}")]
        public async Task<IActionResult> One(int id)
        {
            ViewBag.id = id;
            Camp camp = await campRepo.GetByIdAsync(id, c => c.Photos);
            IEnumerable<Photo> data = camp.Photos;
            ViewBag.campId = camp.Id;
            return View(data.ToList());
        }

        [HttpGet("/photos/delete")]
        public async Task<RedirectToActionResult> Delete(int id, int redirectId)
        {
            photoRepo.Delete(id);
            await photoRepo.SaveAsync();
            return RedirectToAction("One", new {id = redirectId});
        }

        [HttpPost("photos/save")]
        public async Task<RedirectToActionResult> Save(List<Photo> photos, int redirectId)
        {
            Console.WriteLine("YESSSSSSSSSSSSSSSSSSSSSSSSSs");
            // for (int i = 0; i < photos.Count(); i++)
            // {
            //     Console.WriteLine("======================");
            //     Console.WriteLine(photos.ToList()[i].Url);
            //     Console.WriteLine("ID:"+photos.ToList()[i].Id);
            //     Console.WriteLine("CampID:"+photos.ToList()[i].CampId);
            //     Console.WriteLine("======================");
            // }
            foreach (var photo in photos)
            {
                photoRepo.Update(photo);
            }
            await photoRepo.SaveAsync();
            return RedirectToAction("One", new {id = redirectId});
        }
    }
}