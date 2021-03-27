using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackAtHome.Models
{
    public class Zahtjev
    {
        public int Id { get; set; }

        public int KorisnikId { get; set; }
        public string VrstaPomoci { get; set; }
        public string Opis { get; set; }

        public string CreatedByUserId { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}
