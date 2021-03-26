using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HackAtHome.Models;
namespace AspNetCoreMVC.Models
{
    public class HackAtHomeContext : DbContext
    {
        public HackAtHomeContext(DbContextOptions<HackAtHomeContext> options) : base(options)
        {
        }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Volonter> Volonter { get; set; }
        public DbSet<Zahtjev> Zahtjev { get; set; }
        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<Volonter>().ToTable("Volonter");
            modelBuilder.Entity<Zahtjev>().ToTable("Zahtjev");
            
        }
    }
}