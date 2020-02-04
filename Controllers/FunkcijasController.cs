using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using suvlasnici.Data;
using suvlasnici.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace suvlasnici.Controllers
{
    [Authorize]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
    public class FunkcijasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FunkcijasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Funkcijas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funkcija.ToListAsync());
        }

        // GET: Funkcijas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funkcija = await _context.Funkcija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funkcija == null)
            {
                return NotFound();
            }

            return View(funkcija);
        }

        // GET: Funkcijas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funkcijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,naziv")] Funkcija funkcija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funkcija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funkcija);
        }

        // GET: Funkcijas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funkcija = await _context.Funkcija.FindAsync(id);
            if (funkcija == null)
            {
                return NotFound();
            }
            return View(funkcija);
        }

        // POST: Funkcijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,naziv")] Funkcija funkcija)
        {
            if (id != funkcija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funkcija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FunkcijaExists(funkcija.Id))
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
            return View(funkcija);
        }

        // GET: Funkcijas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funkcija = await _context.Funkcija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funkcija == null)
            {
                return NotFound();
            }

            return View(funkcija);
        }

        // POST: Funkcijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funkcija = await _context.Funkcija.FindAsync(id);
            _context.Funkcija.Remove(funkcija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FunkcijaExists(int id)
        {
            return _context.Funkcija.Any(e => e.Id == id);
        }
    }
}
