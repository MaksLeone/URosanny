using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZajazdURosanny;
using ZajazdURosanny.Models;

namespace ZajazdURosanny.Controllers
{
    public class NewsController : Controller
    {
        private readonly EFCDbContext _context;

        public NewsController(EFCDbContext context)
        {
            _context = context;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewsModel.ToListAsync());
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsModel = await _context.NewsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsModel == null)
            {
                return NotFound();
            }

            return View(newsModel);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,PostedOn")] NewsModel newsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsModel);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsModel = await _context.NewsModel.FindAsync(id);
            if (newsModel == null)
            {
                return NotFound();
            }
            return View(newsModel);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,PostedOn")] NewsModel newsModel)
        {
            if (id != newsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsModelExists(newsModel.Id))
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
            return View(newsModel);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsModel = await _context.NewsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsModel == null)
            {
                return NotFound();
            }

            return View(newsModel);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsModel = await _context.NewsModel.FindAsync(id);
            _context.NewsModel.Remove(newsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsModelExists(int id)
        {
            return _context.NewsModel.Any(e => e.Id == id);
        }
    }
}
