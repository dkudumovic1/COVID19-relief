using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackAtHome.Models
{
    public class Volonter
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Grad { get; set; }
        public string Opis { get; set; }
        public bool MedicinskiRadnik { get; set; }
        public bool Dostava { get; set; }
        public bool Tutor { get; set; }
        public bool ZnakovniJezik { get; set; }
        public bool Vakcinisan { get; set; }
        public string GeografskaSirina { get; set; }
        public string GeografskaDuzina { get; set; }

    }
}
