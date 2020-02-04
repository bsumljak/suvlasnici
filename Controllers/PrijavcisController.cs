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
   
        public class PrijavcisController : Controller
        {
            private readonly ApplicationDbContext _context;

            public PrijavcisController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: Prijavcis
            public async Task<IActionResult> Index()
            {
                return View(await _context.Prijavci.ToListAsync());
            }

            // GET: Prijavcis/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var prijavci = await _context.Prijavci
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (prijavci == null)
                {
                    return NotFound();
                }

                return View(prijavci);
            }

            // GET: Prijavcis/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Prijavcis/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("ID,datum,prijavak,PopisSuvlsnikaId")] Prijavci prijavci)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(prijavci);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(prijavci);
            }

            // GET: Prijavcis/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var prijavci = await _context.Prijavci.FindAsync(id);
                if (prijavci == null)
                {
                    return NotFound();
                }
                return View(prijavci);
            }

            // POST: Prijavcis/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("ID,datum,prijavak,PopisSuvlsnikaId")] Prijavci prijavci)
            {
                if (id != prijavci.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(prijavci);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PrijavciExists(prijavci.ID))
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
                return View(prijavci);
            }

            // GET: Prijavcis/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var prijavci = await _context.Prijavci
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (prijavci == null)
                {
                    return NotFound();
                }

                return View(prijavci);
            }

            // POST: Prijavcis/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var prijavci = await _context.Prijavci.FindAsync(id);
                _context.Prijavci.Remove(prijavci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool PrijavciExists(int id)
            {
                return _context.Prijavci.Any(e => e.ID == id);
            }
        }
    }

