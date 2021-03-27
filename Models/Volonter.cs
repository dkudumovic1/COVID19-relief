using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackAtHome.Models
{
    public class Volonter
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        [Display(Name = "Broj telefona")]
        public string BrojTelefona { get; set; }
        public string Grad { get; set; }
        public string Opis { get; set; }
        [Display(Name = "Medicinski radnik")]
        public bool MedicinskiRadnik { get; set; }
        public bool Dostava { get; set; }
        public bool Tutor { get; set; }
        [Display(Name = "Znakovni jezik")]
        public bool ZnakovniJezik { get; set; }
        public bool Vakcinisan { get; set; }
        [Display(Name = "Geografska širina")]
        public string GeografskaSirina { get; set; }
        [Display(Name = "Geografska dužina")]
        public string GeografskaDuzina { get; set; }

    }
}
