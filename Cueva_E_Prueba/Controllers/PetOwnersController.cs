using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cueva_E_Prueba.Data;
using Cueva_E_Prueba.Models;

namespace Cueva_E_Prueba.Controllers
{
    public class PetOwnersController : Controller
    {
        private readonly Cueva_E_PruebaContext _context;

        public PetOwnersController(Cueva_E_PruebaContext context)
        {
            _context = context;
        }

        // GET: PetOwners
        public async Task<IActionResult> Index()
        {
            var cueva_E_PruebaContext = _context.PetOwner.Include(p => p.Doctor).Include(p => p.Pet);
            return View(await cueva_E_PruebaContext.ToListAsync());
        }

        // GET: PetOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = await _context.PetOwner
                .Include(p => p.Doctor)
                .Include(p => p.Pet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petOwner == null)
            {
                return NotFound();
            }

            return View(petOwner);
        }

        // GET: PetOwners/Create
        public IActionResult Create()
        {
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "Id", "Id");
            ViewData["IdPet"] = new SelectList(_context.Pet, "Id", "Id");
            return View();
        }

        // POST: PetOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,RegisterDate,HasMultiplePets,Budget,IdPet,IdDoctor")] PetOwner petOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petOwner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "Id", "Id", petOwner.IdDoctor);
            ViewData["IdPet"] = new SelectList(_context.Pet, "Id", "Id", petOwner.IdPet);
            return View(petOwner);
        }

        // GET: PetOwners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = await _context.PetOwner.FindAsync(id);
            if (petOwner == null)
            {
                return NotFound();
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "Id", "Id", petOwner.IdDoctor);
            ViewData["IdPet"] = new SelectList(_context.Pet, "Id", "Id", petOwner.IdPet);
            return View(petOwner);
        }

        // POST: PetOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,RegisterDate,HasMultiplePets,Budget,IdPet,IdDoctor")] PetOwner petOwner)
        {
            if (id != petOwner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petOwner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetOwnerExists(petOwner.Id))
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
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "Id", "Id", petOwner.IdDoctor);
            ViewData["IdPet"] = new SelectList(_context.Pet, "Id", "Id", petOwner.IdPet);
            return View(petOwner);
        }

        // GET: PetOwners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = await _context.PetOwner
                .Include(p => p.Doctor)
                .Include(p => p.Pet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petOwner == null)
            {
                return NotFound();
            }

            return View(petOwner);
        }

        // POST: PetOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petOwner = await _context.PetOwner.FindAsync(id);
            if (petOwner != null)
            {
                _context.PetOwner.Remove(petOwner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetOwnerExists(int id)
        {
            return _context.PetOwner.Any(e => e.Id == id);
        }
    }
}
