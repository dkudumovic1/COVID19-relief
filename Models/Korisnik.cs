using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackAtHome.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [Display(Name = "Broj telefona ")]
        public string BrojTelefona { get; set; }
        public string Grad { get; set; }
        [Display(Name = "Osoba sa poteskocama sluha")]
        public bool OsobaSaPoteskocamaSluha { get; set; }
        [Display(Name = "Osoba u izolaciji")]
        public bool OsobaUIzolaciji { get; set; }
        [Display(Name = "Starija osoba")]
        public bool StarijaOsoba { get; set; }
        public bool Dijete { get; set; }
        [Display(Name = "Geografska širina")]
        public string GeografskaSirina { get; set; }

        [Display(Name = "Geografska dužina")]
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
