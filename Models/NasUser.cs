using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackAtHome.Models
{
    public class NasUser : IdentityUser
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string BrojTelefona { get; set; }
    }
}
