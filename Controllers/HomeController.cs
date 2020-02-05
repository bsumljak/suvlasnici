using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using suvlasnici.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using suvlasnici.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace suvlasnici.Controllers
{

    public class HomeController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            ViewBag.sjednice = (await _context.Sjednice.ToListAsync());
            ViewBag.raspored = (await _context.RasporedCiscenja.ToListAsync());
            ViewBag.prijavci = (await _context.Prijavci.ToListAsync());

            return View();

        }
    


       

   
        public IActionResult Privacy()
        {
            return View();
        }
       
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      

    }
}
