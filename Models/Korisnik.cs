using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackAtHome.Models
{
    public class Korisnik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Mail { get; set; }
        public string Grad { get; set; }
        public bool OsobaSaPoteskocamaSluha { get; set; }
        public bool OsobaUIzolaciji { get; set; }
        public bool StarijaOsoba { get; set; }
        public bool Dijete { get; set; }
        public string GeografskaSirina { get; set; }
        public string GeografskaDuzina { get; set; }

    }
}
