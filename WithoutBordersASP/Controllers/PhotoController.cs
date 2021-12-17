using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WithoutBorders.Core.Repository;
using WithoutBorders.Data.Entities;
using WithoutBordersASP.Models.Dto;

namespace WithoutBordersASP.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IRepository<int, Camp> campRepo;

        public PhotoController(IRepository<int, Camp> campRepo) => this.campRepo = campRepo;

        public async Task<IActionResult> Photos(int campId)
        {

            // Console.WriteLine($"CampId: {campId}");
            
            // IEnumerable<Camp> camps = await campRepo.GetAllAsync(c => c.Photos);
            // foreach (var camp in camps)
            // {
            //     Console.WriteLine("=========================");
            //     Console.WriteLine($"ID: {camp.Id}");
            //     Console.WriteLine($"Place: {camp.Place}");
            //     Console.WriteLine($"Name: {camp.Name}");
            //     Console.WriteLine($"YearID: {camp.YearId}");
            //     Console.WriteLine("=========================");
            // }

            Camp data = await campRepo.GetByIdAsync(campId, c => c.Year, c => c.Photos);
            // Console.WriteLine("===============================");
            // Console.WriteLine(data.Id);
            // Console.WriteLine("===============================");
            return View(new CampDto(data));
        }
    }
}