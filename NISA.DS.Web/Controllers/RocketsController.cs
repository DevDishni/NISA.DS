using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NISA.DS.Entities;
using NISA.DS.Web.Data;
using NISA.DS.Web.Models.Rockets;

namespace NISA.DS.Web.Controllers
{
    public class RocketsController : Controller
    {

        #region Data And Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RocketsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            var rockets = await _context
                                     .Rockets
                                     .Include(Rocket => Rocket.Astronaut)
                                     .ToListAsync();

            var rocketVMs = _mapper.Map<List<RocketListViewModel>>(rockets);

            return View(rocketVMs);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rockets == null)
            {
                return NotFound();
            }

            var rocket = await _context
                                    .Rockets
                                    .Include(r => r.Astronaut)
                                    .FirstOrDefaultAsync(m => m.Id == id);
            if (rocket == null)
            {
                return NotFound();
            }

            var rocketVM = _mapper.Map<RocketDetailsViewModel>(rocket);

            return View(rocketVM);
        }

        public IActionResult Create()
        {
            var rocketVM = new RocketViewModel();
            rocketVM.Astronauts  = new SelectList(_context.Astronauts, "Id", "FullName");

            
            return View(rocketVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RocketViewModel rocketVM)
        {
            if (ModelState.IsValid)
            {
                var rocket = _mapper.Map<Rocket>(rocketVM);

                _context.Add(rocket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            rocketVM.Astronauts = new SelectList(_context.Astronauts, "Id", "FullName", rocketVM.AstronautId);
            return View(rocketVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rockets == null)
            {
                return NotFound();
            }

            var rocket = await _context.Rockets.FindAsync(id);

            if (rocket == null)
            {
                return NotFound();
            }

            var rocketVM = _mapper.Map<RocketViewModel>(rocket);

            rocketVM.Astronauts = new SelectList(_context.Astronauts, "Id", "FullName", rocketVM.AstronautId);
            return View(rocketVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RocketViewModel rocketVM)
        {
            if (id != rocketVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var rocket = _mapper.Map<Rocket>(rocketVM);

                try
                {
                    _context.Update(rocket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RocketExists(rocket.Id))
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

            rocketVM.Astronauts = new SelectList(_context.Astronauts, "Id", "FullName", rocketVM.AstronautId);
            return View(rocketVM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rockets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Rockets'  is null.");
            }
            var rocket = await _context.Rockets.FindAsync(id);
            if (rocket != null)
            {
                _context.Rockets.Remove(rocket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Private Methods

        private bool RocketExists(int id)
        {
            return (_context.Rockets?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        #endregion

    }
}
