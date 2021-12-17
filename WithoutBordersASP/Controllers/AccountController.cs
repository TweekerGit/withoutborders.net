using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WithoutBordersASP.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace WithoutBordersASP.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginModel());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginModel model, string returnUrl)
        {
            // Console.WriteLine("NOOOOOOOOOOOOOOOOOOOOOO");
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IdentityUser user = await this.userManager.FindByNameAsync(model.UserName);

            // Console.WriteLine(user.UserName);
            
            if (user is not null)
            {
                await this.signInManager.SignOutAsync(); //так нада
                SignInResult result =
                    await this.signInManager.PasswordSignInAsync(user, model.Password, model.Remember, false);

                if (result.Succeeded)
                    return this.LocalRedirect(returnUrl ?? "/");
            }

            ModelState.AddModelError(nameof(LoginModel.UserName), "Неправильний логін або пароль");

            return View(model);
        }

        [Authorize]
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}