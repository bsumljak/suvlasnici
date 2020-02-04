using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace suvlasnici.Models
{
    public class Funkcija
    {
        public int Id { get; set; }
        [Display(Name = "Naziv")]
        public string naziv { get; set; }
     }
}
