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
using NISA.DS.Web.Models.Trip;

namespace NISA.DS.Web.Controllers
{
    public class TripsController : Controller
    {

        #region Data And Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TripsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index(TripPageViewModel tripVM)
        {

            var tripsQuery = _context
                                  .Trips
                                  .Include(t => t.TripType)
                                  .AsQueryable();

            if(tripVM.TripTypeId.HasValue)
            {
                tripsQuery = tripsQuery.Where(tq => tq.TripTypeId == tripVM.TripTypeId);
            }

            var trips = await tripsQuery.ToListAsync();

            var tripPageVM = new TripPageViewModel();

            tripPageVM.Trips = _mapper.Map<List<TripListViewModel>>(trips);

            tripPageVM.TripTypes = new SelectList(_context.TripTypes, "Id", "Ticket", tripPageVM.TripTypeId);


            return View(tripPageVM);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trips == null)
            {
                return NotFound();
            }

            var trip = await _context
                                  .Trips
                                  .Include(trip => trip.Rocket)
                                  .Include(trip => trip.TripType)
                                  .Include(trip => trip.Passengers)
                                  .FirstOrDefaultAsync(trip => trip.Id == id);

            if (trip == null)
            {
                return NotFound();
            }

            var tripVM = _mapper.Map<TripDetailsViewModel>(trip);

            return View(tripVM);
        }

        public IActionResult Create()
        {
            var tripVM = new TripViewModel();

            tripVM.Rockets = new SelectList(_context.Rockets, "Id", "RocketFullName");
            tripVM.TripTypes = new SelectList(_context.TripTypes, "Id", "Ticket");
            tripVM.PassengersMultiSelect = new MultiSelectList(_context.Passengers, "Id", "FullName");

            return View(tripVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TripViewModel tripVM)
        {
            if (tripVM.PickUpDateTime != null)
            {

                if (ModelState.IsValid)
                {
                    var trip = _mapper.Map<Trip>(tripVM);

                    await AddPassengersToTripAsync(tripVM, trip);

                    _context.Add(trip);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            tripVM.Rockets = new SelectList(_context.Rockets, "Id", "RocketFullName", tripVM.RocketId);
            tripVM.TripTypes = new SelectList(_context.TripTypes, "Id", "Ticket", tripVM.TripTypeId);
            tripVM.PassengersMultiSelect = new MultiSelectList(_context.Passengers, "Id", "FullName");
            return View(tripVM);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trips == null)
            {
                return NotFound();
            }

            var trip = await _context
                                  .Trips
                                  .Include(trip => trip.Passengers)
                                  .SingleOrDefaultAsync(trip => trip.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            var tripVM = _mapper.Map<TripViewModel>(trip);

            tripVM.Rockets = new SelectList(_context.Rockets, "Id", "RocketFullName", tripVM.RocketId);
            tripVM.TripTypes = new SelectList(_context.TripTypes, "Id", "Ticket", tripVM.TripTypeId);

            tripVM.PassengerIds = trip.Passengers.Select(p => p.Id).ToList();
            tripVM.PassengersMultiSelect = new MultiSelectList(_context.Passengers, "Id", "FullName", tripVM.PassengerIds);

            return View(tripVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TripViewModel tripVM)
        {

            if (id != tripVM.Id)
            {
                return NotFound();
            }

            if (tripVM.PickUpDateTime != null)
            {
                if (ModelState.IsValid)
                {
                    var trip = _mapper.Map<Trip>(tripVM);

                    try
                    {
                        _context.Update(trip);
                        await _context.SaveChangesAsync();

                        await UpdateTripPassengersAndSave(tripVM, trip.Id);


                        _context.Update(trip);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TripExists(trip.Id))
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
            tripVM.Rockets = new SelectList(_context.Rockets, "Id", "RocketFullName", tripVM.RocketId);
            tripVM.TripTypes = new SelectList(_context.TripTypes, "Id", "Ticket", tripVM.TripTypeId);
            tripVM.PassengersMultiSelect = new MultiSelectList(_context.Passengers, "Id", "FullName", tripVM.PassengerIds);
            return View(tripVM);
        }




        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trips == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Trips'  is null.");
            }
            var trip = await _context.Trips.FindAsync(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Private Methods

        private bool TripExists(int id)
        {
            return (_context.Trips?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task AddPassengersToTripAsync(TripViewModel tripVM, Trip trip)
        {
            var passengers = await _context.Passengers.Where(passenger => tripVM.PassengerIds.Contains(passenger.Id)).ToListAsync();
            trip.Passengers.AddRange(passengers);
        }

        private async Task UpdateTripPassengersAndSave(TripViewModel tripVM, int tripId)
        {
            var trip = await _context
                                  .Trips
                                  .Include(t => t.Passengers)
                                  .Where(t => t.Id == tripId)
                                  .SingleAsync();

            trip.Passengers.Clear();

            var passengers = await _context
                                        .Passengers
                                        .Where(passenger => tripVM.PassengerIds.Contains(passenger.Id))
                                        .ToListAsync();

            trip.Passengers.AddRange(passengers);

        }

        #endregion

    }
}
