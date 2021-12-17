using Microsoft.AspNetCore.Mvc;

namespace WithoutBordersASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainController:Controller
    {
        
        [HttpGet("admin")]
        public IActionResult Index()
        {
            return View();
        }

        public RedirectToActionResult Home() => RedirectToAction("Index", "Home");
        
    }
}