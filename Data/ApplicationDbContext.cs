using System;
using System.Collections.Generic;
using System.Text;
using HackAtHome.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HackAtHome.Data
{
    public class ApplicationDbContext : IdentityDbContext<NasUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
