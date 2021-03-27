﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackAtHome.Models
{
    public class Zahtjev
    {
        public int Id { get; set; }

        public int KorisnikId { get; set; }
        public bool Tutor { get; set; }
        public bool MedicinskaPomoc { get; set; }
        public bool Vakcinisan { get; set; }
        public bool Dostava { get; set; }
        public bool ZnakovniJezik { get; set; }
        public string Opis { get; set; }

        public string CreatedByUserId { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public bool Zavrseno { get; set; }
    }
}
