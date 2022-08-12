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
using NISA.DS.Web.Models.Passengers;

namespace NISA.DS.Web.Controllers
{
    public class PassengersController : Controller
    {

        #region Data And Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PassengersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            var passenger = await _context
                                       .Passengers
                                       .ToListAsync();

            var passengerVMs = _mapper.Map<List<PassengerListViewModel>>(passenger);

            return View(passengerVMs);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passenger = await _context
                                       .Passengers
                                       .FirstOrDefaultAsync(m => m.Id == id);

            if (passenger == null)
            {
                return NotFound();
            }

            var passengerVM = _mapper.Map<PassengerDetailsViewModel>(passenger);

            return View(passengerVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PassengerViewModel passengerVM)
        {
            if (passengerVM.DOB != null)
            {

                if (ModelState.IsValid)
                {
                    var passenger = _mapper.Map<Passenger>(passengerVM);

                    _context.Add(passenger);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(passengerVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passenger = await _context
                                       .Passengers
                                       .FindAsync(id);

            if (passenger == null)
            {
                return NotFound();
            }

            var passengerVM = _mapper.Map<PassengerViewModel>(passenger);

            return View(passengerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PassengerViewModel passengerVM)
        {
            if (id != passengerVM.Id)
            {
                return NotFound();
            }

            if (passengerVM.DOB != null)
            {
                if (ModelState.IsValid)
                {
                    var passenger = _mapper.Map<Passenger>(passengerVM);

                    try
                    {
                        _context.Update(passenger);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PassengerExists(passenger.Id))
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
            }

            return View(passengerVM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passengers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Passengers'  is null.");
            }
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Private Methods

        private bool PassengerExists(int id)
        {
            return (_context.Passengers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        #endregion

    }
}
