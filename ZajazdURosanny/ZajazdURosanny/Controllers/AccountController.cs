using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZajazdURosanny.ViewModel;

namespace ZajazdURosanny.Controllers
{
    public class AccountController : Controller
    {
        protected SignInManager<IdentityUser> SignInManager { get; set; }
        protected RoleManager<IdentityRole> RoleManager { get; }
        public UserManager<IdentityUser> UserManager { get; set; }

        public AccountController(SignInManager<IdentityUser> sim, UserManager<IdentityUser> um, RoleManager<IdentityRole> roleManager)
        {
            SignInManager = sim;
            UserManager = um;
            RoleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser(viewModel.Login) { Email = viewModel.Email };
                var result = await UserManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    var result2 = await SignInManager.PasswordSignInAsync(viewModel.Login, viewModel.Password, false, false);

                    if (result2.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LogInModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var result = await SignInManager.PasswordSignInAsync(viewModel.Login, viewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ControlPanel()
        {
            return View();
        }

    }
}