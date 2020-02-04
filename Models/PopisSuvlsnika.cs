using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace suvlasnici.Models
{
    public class PopisSuvlsnika
    {
        public int Id { get; set; }
        [Display(Name = "Ime")]
        public string ime { get; set; }
        [Display(Name = "Prezime")]
        public string prezime { get; set; }
        [Display(Name = "Funkcija")]
         public Boolean predstavnik { get; set; }
        public int FunkcijaId { get; set; }
       
    }
}
