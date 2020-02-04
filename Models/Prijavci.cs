using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace suvlasnici.Models
{
    public class Prijavci
    {
        public int ID { get; set; }
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime datum { get; set; }
        [Display(Name = "Unos prijave")]
        public string prijavak { get; set; }
        [Display(Name = "Suvlasnik")]
        public int PopisSuvlsnikaId { get; set; }
    }
}
