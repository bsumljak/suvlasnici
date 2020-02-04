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
  
        public class PopisSuvlsnikasController : Controller
        {
            private readonly ApplicationDbContext _context;

            public PopisSuvlsnikasController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: PopisSuvlsnikas
            public async Task<IActionResult> Index()
            {
                return View(await _context.PopisSuvlasnika.ToListAsync());
            }

            // GET: PopisSuvlsnikas/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var popisSuvlsnika = await _context.PopisSuvlasnika
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (popisSuvlsnika == null)
                {
                    return NotFound();
                }

                return View(popisSuvlsnika);
            }

            // GET: PopisSuvlsnikas/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: PopisSuvlsnikas/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,ime,prezime,predstavnik,FunkcijaId")] PopisSuvlsnika popisSuvlsnika)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(popisSuvlsnika);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(popisSuvlsnika);
            }

            // GET: PopisSuvlsnikas/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var popisSuvlsnika = await _context.PopisSuvlasnika.FindAsync(id);
                if (popisSuvlsnika == null)
                {
                    return NotFound();
                }
                return View(popisSuvlsnika);
            }

            // POST: PopisSuvlsnikas/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,ime,prezime,predstavnik,FunkcijaId")] PopisSuvlsnika popisSuvlsnika)
            {
                if (id != popisSuvlsnika.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(popisSuvlsnika);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PopisSuvlsnikaExists(popisSuvlsnika.Id))
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
                return View(popisSuvlsnika);
            }

            // GET: PopisSuvlsnikas/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var popisSuvlsnika = await _context.PopisSuvlasnika
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (popisSuvlsnika == null)
                {
                    return NotFound();
                }

                return View(popisSuvlsnika);
            }

            // POST: PopisSuvlsnikas/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var popisSuvlsnika = await _context.PopisSuvlasnika.FindAsync(id);
                _context.PopisSuvlasnika.Remove(popisSuvlsnika);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool PopisSuvlsnikaExists(int id)
            {
                return _context.PopisSuvlasnika.Any(e => e.Id == id);
            }
        }
    }

