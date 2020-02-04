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

        public class RasporedCiscenjasController : Controller
        {
            private readonly ApplicationDbContext _context;

            public RasporedCiscenjasController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: RasporedCiscenjas
            public async Task<IActionResult> Index()
            {

                return View(await _context.RasporedCiscenja.ToListAsync());
            }

            // GET: RasporedCiscenjas/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var rasporedCiscenja = await _context.RasporedCiscenja
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (rasporedCiscenja == null)
                {
                    return NotFound();
                }

                return View(rasporedCiscenja);
            }

            // GET: RasporedCiscenjas/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: RasporedCiscenjas/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("ID,datumod,datumdo,PopisSuvlsnikaId")] RasporedCiscenja rasporedCiscenja)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(rasporedCiscenja);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(rasporedCiscenja);
            }

            // GET: RasporedCiscenjas/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var rasporedCiscenja = await _context.RasporedCiscenja.FindAsync(id);
                if (rasporedCiscenja == null)
                {
                    return NotFound();
                }
                return View(rasporedCiscenja);
            }

            // POST: RasporedCiscenjas/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("ID,datumod,datumdo,PopisSuvlsnikaId")] RasporedCiscenja rasporedCiscenja)
            {
                if (id != rasporedCiscenja.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(rasporedCiscenja);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!RasporedCiscenjaExists(rasporedCiscenja.ID))
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
                return View(rasporedCiscenja);
            }

            // GET: RasporedCiscenjas/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var rasporedCiscenja = await _context.RasporedCiscenja
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (rasporedCiscenja == null)
                {
                    return NotFound();
                }

                return View(rasporedCiscenja);
            }

            // POST: RasporedCiscenjas/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var rasporedCiscenja = await _context.RasporedCiscenja.FindAsync(id);
                _context.RasporedCiscenja.Remove(rasporedCiscenja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool RasporedCiscenjaExists(int id)
            {
                return _context.RasporedCiscenja.Any(e => e.ID == id);
            }
        }
    }

