using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie_TARpe20.Data;
using MvcMovie_TARpe20.Models;

namespace MvcMovie_TARpe20.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MvcMovie_TARpe20Context _context;
        

        public ActorsController(MvcMovie_TARpe20Context context)
        {
            _context = context;
        }

        // GET: Actors
        public async Task<IActionResult> Index(int? birthYear, string searchString)

        {
            var birthYearQuery = from a in _context.Actor
                                 orderby a.DateOfBirth.Year
                                 select a.DateOfBirth.Year;

            var actors = from a in _context.Actor 
                         select a;

           

            if (!String.IsNullOrEmpty(searchString))
            {
                actors = actors.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));
            }

            if (birthYear != null)
            {
                actors = actors.Where(s => s.DateOfBirth.Year == birthYear);
            }

            var actorVM = new ActorViewModel
            {
                Actors = await actors.ToListAsync(),
                BirthYears = new SelectList(await birthYearQuery.Distinct().ToListAsync())
            };

            return View(actorVM);
        }

        // GET: Actors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actors = await _context.Actor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actors == null)
            {
                return NotFound();
            }

            return View(actors);
        }

        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,BirthDate,NumberOfOscars,NetWorth,BirthPlace")] Actor actors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actors);
        }

        // GET: Actors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actors = await _context.Actor.FindAsync(id);
            if (actors == null)
            {
                return NotFound();
            }
            return View(actors);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,BirthDate,NumberOfOscars,NetWorth,BirthPlace")] Actor actor)
        {
            if (id != actor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorsExists(actor.Id))
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
            return View(actor);
        }

        // GET: Actors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actors = await _context.Actor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actors == null)
            {
                return NotFound();
            }

            return View(actors);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actors = await _context.Actor.FindAsync(id);
            _context.Actor.Remove(actors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorsExists(int id)
        {
            return _context.Actor.Any(e => e.Id == id);
        }
    }
}
