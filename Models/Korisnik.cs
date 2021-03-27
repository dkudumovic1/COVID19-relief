using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackAtHome.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Grad { get; set; }
        public bool OsobaSaPoteskocamaSluha { get; set; }
        public bool OsobaUIzolaciji { get; set; }
        public bool StarijaOsoba { get; set; }
        public bool Dijete { get; set; }
        public string GeografskaSirina { get; set; }
        public string GeografskaDuzina { get; set; }

        public Korisnik(int id, string ime, string prezime, string grad, string latitude, string longitude)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Grad = grad;
            this.GeografskaSirina = latitude;
            this.GeografskaDuzina = longitude;
;
        }

    }
}
