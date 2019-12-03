using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZajazdURosanny.Models;
using ZajazdURosanny.ViewModel;

namespace ZajazdURosanny.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        protected RoleManager<IdentityRole> RoleManager { get; }
        protected UserManager<IdentityUser> UserManager { get; }

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            RoleManager = roleManager;
            UserManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleModel role, string roleName)
        {
            var ir = new IdentityRole(roleName);
            await RoleManager.CreateAsync(ir);
            role.RoleName = roleName;

            return RedirectToAction("Index", "Home");
        }


        //Dodawanie uzytkownika do roli
        //Podczas wchodzenia do tej akcji przekierowuje do - /Account/Login ... O.o
        [HttpGet]
        public async Task<IActionResult> AddToRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddToRole(RoleModel role)
        {
            IdentityUser user = await UserManager.GetUserAsync(User);
            await UserManager.AddToRoleAsync(user, "Admin");

            return RedirectToAction("Index", "Home");
        }




    }
}