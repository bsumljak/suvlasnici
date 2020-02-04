using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using suvlasnici.Models;

namespace suvlasnici.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<suvlasnici.Models.PopisSuvlsnika> PopisSuvlasnika { get; set; }
        public DbSet<suvlasnici.Models.RasporedCiscenja> RasporedCiscenja { get; set; }
        public DbSet<suvlasnici.Models.Sjednice> Sjednice { get; set; }
        public DbSet<suvlasnici.Models.Prijavci> Prijavci { get; set; }
        public DbSet<suvlasnici.Models.Funkcija> Funkcija { get; set; }
    }
}
