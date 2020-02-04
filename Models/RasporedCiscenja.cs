using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace suvlasnici.Models
{
    public class RasporedCiscenja
    {
        public int ID { get; set; }
        [Display(Name = "Datum od")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime datumod { get; set; }
        [Display(Name = "Datum do")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime datumdo { get; set; }
        public string PopisSuvlsnikaId { get; set; }
    }
}
