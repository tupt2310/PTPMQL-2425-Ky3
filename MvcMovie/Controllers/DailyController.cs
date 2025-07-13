using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Model;

namespace MvcMovie.Controllers
{
    public class Dailycontroller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Dailycontroller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dailycontroller
        public async Task<IActionResult> Index()
        {
            return View(await _context.Daily.ToListAsync());
        }

        // GET: Dailycontroller/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daily = await _context.Daily
                .FirstOrDefaultAsync(m => m.Id == id);
            if (daily == null)
            {
                return NotFound();
            }

            return View(daily);
        }

        // GET: Dailycontroller/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dailycontroller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,FullName,Address,Date,Time,Note")] Daily daily)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daily);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daily);
        }

        // GET: Dailycontroller/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daily = await _context.Daily.FindAsync(id);
            if (daily == null)
            {
                return NotFound();
            }
            return View(daily);
        }

        // POST: Dailycontroller/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,FullName,Address,Date,Time,Note")] Daily daily)
        {
            if (id != daily.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daily);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyExists(daily.Id))
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
            return View(daily);
        }

        // GET: Dailycontroller/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daily = await _context.Daily
                .FirstOrDefaultAsync(m => m.Id == id);
            if (daily == null)
            {
                return NotFound();
            }

            return View(daily);
        }

        // POST: Dailycontroller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daily = await _context.Daily.FindAsync(id);
            if (daily != null)
            {
                _context.Daily.Remove(daily);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyExists(int id)
        {
            return _context.Daily.Any(e => e.Id == id);
        }
    }
}
