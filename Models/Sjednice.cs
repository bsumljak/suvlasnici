using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace suvlasnici.Models
{
    public class Sjednice
    {
        public int ID { get; set; }
        [Display(Name = "Datum sjednice")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime datum { get; set; }
        [Display(Name = "Zapisnik")]
        public string zapisnik { get; set; }
        public string PopisSuvlsnikaId { get; set; }
    }
}
