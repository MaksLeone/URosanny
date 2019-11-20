using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZajazdURosanny;
using ZajazdURosanny.Models;

namespace ZajazdURosanny.Controllers
{
    public class MenuController : Controller
    {
        private readonly EFCDbContext _context;

        public MenuController(EFCDbContext context)
        {
            _context = context;
        }

        // GET: Menu
        public async Task<IActionResult> Index()
        {
            return View(await _context.MenuModel.ToListAsync());
        }

        //// GET: Menu/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var menuModel = await _context.MenuModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (menuModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(menuModel);
        //}

        // GET: Menu/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Category,Name,Description,Price")] MenuModel menuModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menuModel);
        }

        // GET: Menu/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuModel = await _context.MenuModel.FindAsync(id);
            if (menuModel == null)
            {
                return NotFound();
            }
            return View(menuModel);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Category,Name,Description,Price")] MenuModel menuModel)
        {
            if (id != menuModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuModelExists(menuModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menuModel);
        }

        // GET: Menu/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuModel = await _context.MenuModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuModel == null)
            {
                return NotFound();
            }

            return View(menuModel);
        }

        // POST: Menu/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuModel = await _context.MenuModel.FindAsync(id);
            _context.MenuModel.Remove(menuModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuModelExists(int id)
        {
            return _context.MenuModel.Any(e => e.Id == id);
        }
    }
}
