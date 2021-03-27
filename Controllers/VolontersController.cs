using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMVC.Models;
using HackAtHome.Models;

namespace HackAtHome.Controllers
{
    public class VolontersController : Controller
    {
        private readonly HackAtHomeContext _context;

        public VolontersController(HackAtHomeContext context)
        {
            _context = context;
        }

        // GET: Volonters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Volonter.ToListAsync());
        }

        // GET: Volonters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volonter = await _context.Volonter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volonter == null)
            {
                return NotFound();
            }

            return View(volonter);
        }

        // GET: Volonters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Volonters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,BrojTelefona,Grad,Opis,MedicinskiRadnik,Dostava,Tutor,ZnakovniJezik,Vakcinisan,GeografskaSirina,GeografskaDuzina")] Volonter volonter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(volonter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(volonter);
        }

        // GET: Volonters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volonter = await _context.Volonter.FindAsync(id);
            if (volonter == null)
            {
                return NotFound();
            }
            return View(volonter);
        }

        // POST: Volonters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,BrojTelefona,Grad,Opis,MedicinskiRadnik,Dostava,Tutor,ZnakovniJezik,Vakcinisan,GeografskaSirina,GeografskaDuzina")] Volonter volonter)
        {
            if (id != volonter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volonter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolonterExists(volonter.Id))
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
            return View(volonter);
        }

        // GET: Volonters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volonter = await _context.Volonter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volonter == null)
            {
                return NotFound();
            }

            return View(volonter);
        }

        // POST: Volonters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volonter = await _context.Volonter.FindAsync(id);
            _context.Volonter.Remove(volonter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolonterExists(int id)
        {
            return _context.Volonter.Any(e => e.Id == id);
        }

        public async Task<IActionResult> PregledZahtjeva()
        {
            var korisnici = new List<Korisnik>();
            korisnici.Add(new Korisnik(1, "Korisnik 1", "", "Sarajevo", "43.8563", "18.4131"));
            korisnici.Add(new Korisnik(2, "Korisnik 2", "", "Sarajevo", "45.815399", "15.966568"));

            ViewBag.korisnici = korisnici;
            return View();
        }
    }
}
