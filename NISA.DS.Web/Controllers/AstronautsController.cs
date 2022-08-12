using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NISA.DS.Entities;
using NISA.DS.Web.Data;
using NISA.DS.Web.Models.Astronauts;

namespace NISA.DS.Web.Controllers
{
    public class AstronautsController : Controller
    {

        #region Data And Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AstronautsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            var astronauts = await _context
                                         .Astronauts
                                         .ToListAsync();

            var astronautVMs = _mapper.Map<List<AstronautListViewModel>>(astronauts);

            return View(astronautVMs);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Astronauts == null)
            {
                return NotFound();
            }

            var astronaut = await _context
                                        .Astronauts
                                        .Include(Astronaut => Astronaut.Rockets)
                                        .FirstOrDefaultAsync(m => m.Id == id);

            if (astronaut == null)
            {
                return NotFound();
            }

            var astronautVM = _mapper.Map<AstronautDetailsViewModel>(astronaut);

            return View(astronautVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AstronautViewModel astronautVM)
        {
            if (astronautVM.DOB != null)
            {
                if (ModelState.IsValid)
                {
                    var astronaut = _mapper.Map<Astronaut>(astronautVM);

                    _context.Add(astronaut);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(astronautVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Astronauts == null)
            {
                return NotFound();
            }

            var astronaut = await _context
                                       .Astronauts
                                       .FindAsync(id);

            if (astronaut == null)
            {
                return NotFound();
            }

            var astronautVM = _mapper.Map<AstronautViewModel>(astronaut);

            return View(astronautVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AstronautViewModel astronautVM)
        {
            if (id != astronautVM.Id)
            {
                return NotFound();
            }

            if (astronautVM.DOB != null)
            {
                if (ModelState.IsValid)
                {
                    var astronaut = _mapper.Map<Astronaut>(astronautVM);

                    try
                    {
                        _context.Update(astronaut);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AstronautExists(astronaut.Id))
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

            return View(astronautVM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Astronauts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Astronauts'  is null.");
            }
            var astronaut = await _context.Astronauts.FindAsync(id);
            if (astronaut != null)
            {
                _context.Astronauts.Remove(astronaut);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Private Methods

        private bool AstronautExists(int id)
        {
            return (_context.Astronauts?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        #endregion

    }
}
