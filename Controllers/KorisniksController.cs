using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMVC.Models;
using HackAtHome.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace HackAtHome.Controllers
{
    public class KorisniksController : Controller
    {
        private readonly HackAtHomeContext _context;
        private readonly IHttpContextAccessor _http;
        private readonly UserManager<NasUser> _userManager;

        public KorisniksController(HackAtHomeContext context, IHttpContextAccessor http, UserManager<NasUser> user)
        {
            _context = context;
            _http = http;
            _userManager = user;
        }

        // GET: Korisniks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Korisnik.ToListAsync());
        }

        // GET: Korisniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = _http.HttpContext.User;
            var userFromDb = await _userManager.GetUserAsync(user);
            if (userFromDb != null && id == null) id = userFromDb.KorisnikId;

            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        // GET: Korisniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Korisniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,BrojTelefona,Grad,OsobaSaPoteskocamaSluha,OsobaUIzolaciji,StarijaOsoba,Dijete,GeografskaSirina,GeografskaDuzina")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(korisnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(korisnik);
        }

        // GET: Korisniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }
            return View(korisnik);
        }

        // POST: Korisniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,BrojTelefona,Grad,OsobaSaPoteskocamaSluha,OsobaUIzolaciji,StarijaOsoba,Dijete,GeografskaSirina,GeografskaDuzina")] Korisnik korisnik)
        {
            if (id != korisnik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(korisnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KorisnikExists(korisnik.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(korisnik);
        }

        // GET: Korisniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        //Dodaj Zahtjev

        public async Task<IActionResult> DodajZahtjev()
        {
            return View();
        }

        // POST: Korisniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var korisnik = await _context.Korisnik.FindAsync(id);
            _context.Korisnik.Remove(korisnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KorisnikExists(int id)
        {
            return _context.Korisnik.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Poruke()
        {
            string apiUri = "https://www.affirmations.dev/";
            string poruka = "";
            string [] poruka2 = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUri);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    poruka = response;
                    poruka2 = poruka.Split(":");
                    poruka = poruka2[poruka2.Length - 1].Substring(0, poruka2[poruka2.Length - 1].Length - 1);
                }
            }
            ViewData["poruka"] =poruka;
            return View();
            /*var nasContext = _context.Student.Include(s => s.PrijavaStudenta).Include(s => s.Soba);
            return View(await nasContext.ToListAsync());*/
        }
    }
}
