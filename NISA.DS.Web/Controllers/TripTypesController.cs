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
using NISA.DS.Web.Models.TripTypes;

namespace NISA.DS.Web.Controllers
{
    public class TripTypesController : Controller
    {

        #region Data And Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TripTypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            var tripTypes = await _context
                                 .TripTypes
                                 .ToListAsync();

            var TripTypeVMs = _mapper.Map<List<TripTypeViewModel>>(tripTypes);

            return View(TripTypeVMs);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TripTypes == null)
            {
                return NotFound();
            }

            var tripType = await _context
                                      .TripTypes
                                      .FirstOrDefaultAsync(m => m.Id == id);

            if (tripType == null)
            {
                return NotFound();
            }

            var tripTypeVM = _mapper.Map<TripTypeViewModel>(tripType);

            return View(tripTypeVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TripTypeViewModel tripTypeVM)
        {
            if (ModelState.IsValid)
            {
                var tripType = _mapper.Map<TripType>(tripTypeVM);

                _context.Add(tripType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tripTypeVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TripTypes == null)
            {
                return NotFound();
            }

            var tripType = await _context
                                      .TripTypes
                                      .FindAsync(id);

            if (tripType == null)
            {
                return NotFound();
            }

            var tripTypeVM = _mapper.Map<TripTypeViewModel>(tripType);

            return View(tripTypeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TripTypeViewModel tripTypeVM)
        {
            if (id != tripTypeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var tripType = _mapper.Map<TripType>(tripTypeVM);

                try
                {
                    _context.Update(tripType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripTypeExists(tripType.Id))
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
            return View(tripTypeVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TripTypes == null)
            {
                return NotFound();
            }

            var tripType = await _context.TripTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripType == null)
            {
                return NotFound();
            }

            return View(tripType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TripTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TripTypes'  is null.");
            }
            var tripType = await _context.TripTypes.FindAsync(id);
            if (tripType != null)
            {
                _context.TripTypes.Remove(tripType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Private Methods

        private bool TripTypeExists(int id)
        {
            return (_context.TripTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        #endregion

    }
}
