using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DMS_3.Data;
using DMS_3.Models;

namespace DMS_3.Controllers
{
    public class SecretariesController : Controller
    {
        private readonly DMS_3Context _context;

        public SecretariesController(DMS_3Context context)
        {
            _context = context;
        }

        // GET: Secretaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Secretaries.ToListAsync());
        }

        // GET: Secretaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secretary = await _context.Secretaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (secretary == null)
            {
                return NotFound();
            }

            return View(secretary);
        }

        // GET: Secretaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Secretaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber")] Secretary secretary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(secretary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(secretary);
        }

        // GET: Secretaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secretary = await _context.Secretaries.FindAsync(id);
            if (secretary == null)
            {
                return NotFound();
            }
            return View(secretary);
        }

        // POST: Secretaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNumber")] Secretary secretary)
        {
            if (id != secretary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(secretary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecretaryExists(secretary.Id))
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
            return View(secretary);
        }

        // GET: Secretaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secretary = await _context.Secretaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (secretary == null)
            {
                return NotFound();
            }

            return View(secretary);
        }

        // POST: Secretaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var secretary = await _context.Secretaries.FindAsync(id);
            if (secretary != null)
            {
                _context.Secretaries.Remove(secretary);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SecretaryExists(int id)
        {
            return _context.Secretaries.Any(e => e.Id == id);
        }
    }
}
