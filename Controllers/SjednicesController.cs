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

        public class SjednicesController : Controller
        {
            private readonly ApplicationDbContext _context;

            public SjednicesController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: Sjednices
            public async Task<IActionResult> Index()
            {
                return View(await _context.Sjednice.ToListAsync());
            }

            // GET: Sjednices/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var sjednice = await _context.Sjednice
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (sjednice == null)
                {
                    return NotFound();
                }

                return View(sjednice);
            }

            // GET: Sjednices/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Sjednices/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("ID,datum,zapisnik,PopisSuvlsnikaId")] Sjednice sjednice)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(sjednice);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(sjednice);
            }

            // GET: Sjednices/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var sjednice = await _context.Sjednice.FindAsync(id);
                if (sjednice == null)
                {
                    return NotFound();
                }
                return View(sjednice);
            }

            // POST: Sjednices/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("ID,datum,zapisnik,PopisSuvlsnikaId")] Sjednice sjednice)
            {
                if (id != sjednice.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(sjednice);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SjedniceExists(sjednice.ID))
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
                return View(sjednice);
            }

            // GET: Sjednices/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var sjednice = await _context.Sjednice
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (sjednice == null)
                {
                    return NotFound();
                }

                return View(sjednice);
            }

            // POST: Sjednices/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var sjednice = await _context.Sjednice.FindAsync(id);
                _context.Sjednice.Remove(sjednice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool SjedniceExists(int id)
            {
                return _context.Sjednice.Any(e => e.ID == id);
            }
        }
    }
