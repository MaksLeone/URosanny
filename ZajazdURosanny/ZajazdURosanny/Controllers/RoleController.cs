using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZajazdURosanny.Models;
using ZajazdURosanny.ViewModel;

namespace ZajazdURosanny.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        protected RoleManager<IdentityRole> RoleManager { get; }
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel role, string roleName)
        {
            var ir = new IdentityRole(roleName);
            await RoleManager.CreateAsync(ir);
            role.RoleName = roleName;

            return RedirectToAction("Index", "Home");
        }


        // Dodawanie uzytkownika do roli
        // NIESKONCZONE
        [HttpGet]
        public async Task<IActionResult> AddToRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddToRole(RoleViewModel role, string user)
        {
            

            return RedirectToAction("Index", "Home");
        }
    }
}