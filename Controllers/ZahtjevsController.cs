﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMVC.Models;
using HackAtHome.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace HackAtHome.Controllers
{
    public class ZahtjevsController : Controller
    {
        private readonly HackAtHomeContext _context;
        private readonly IHttpContextAccessor _http;
        private readonly UserManager<NasUser> _userManager;

        public ZahtjevsController(HackAtHomeContext context, IHttpContextAccessor http, UserManager<NasUser> userManager)
        {
            _context = context;
            _http = http;
            _userManager = userManager;
        }

        // GET: Zahtjevs
        public async Task<IActionResult> Index()
        {
            var user = _http.HttpContext.User;
            var userFromDb = await _userManager.GetUserAsync(user);

            if (userFromDb.KorisnikId != 0) return View(await _context.Zahtjev.Where(a => a.CreatedByUserId == userFromDb.Id).ToListAsync());
            else return View(await _context.Zahtjev.ToListAsync());
        }

        // GET: Zahtjevs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjev = await _context.Zahtjev
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zahtjev == null)
            {
                return NotFound();
            }

            return View(zahtjev);
        }

        // GET: Zahtjevs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zahtjevs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KorisnikId,Tutor,MedicinskaPomoc,Vakcinisan,Dostava,ZnakovniJezik,Opis,CreatedByUserId,CreatedDateTime,Zavrseno")] Zahtjev zahtjev)
        {
            if (ModelState.IsValid)
            {
                var user = _http.HttpContext.User;
                var userFromDb = await _userManager.GetUserAsync(user);
                if (userFromDb != null) zahtjev.CreatedByUserId = userFromDb.Id;
                zahtjev.CreatedDateTime = DateTime.Now;
                zahtjev.KorisnikId = userFromDb.KorisnikId;
                zahtjev.CreatedByUserId = userFromDb.Id;

                _context.Add(zahtjev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zahtjev);
        }

        // GET: Zahtjevs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjev = await _context.Zahtjev.FindAsync(id);
            if (zahtjev == null)
            {
                return NotFound();
            }
            return View(zahtjev);
        }


        [Authorize(Roles = "Korisnik1")]
        // POST: Zahtjevs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KorisnikId,Tutor,MedicinskaPomoc,Vakcinisan,Dostava,ZnakovniJezik,Opis,CreatedByUserId,CreatedDateTime,Zavrseno")] Zahtjev zahtjev)
        {
            if (id != zahtjev.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zahtjev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZahtjevExists(zahtjev.Id))
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
            return View(zahtjev);
        }

        // GET: Zahtjevs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjev = await _context.Zahtjev
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zahtjev == null)
            {
                return NotFound();
            }

            return View(zahtjev);
        }

        // POST: Zahtjevs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zahtjev = await _context.Zahtjev.FindAsync(id);
            _context.Zahtjev.Remove(zahtjev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZahtjevExists(int id)
        {
            return _context.Zahtjev.Any(e => e.Id == id);
        }
    }
}
