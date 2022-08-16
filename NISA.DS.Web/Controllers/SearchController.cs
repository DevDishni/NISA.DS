using AutoMapper;
using NISA.DS.Web.Data;
using NISA.DS.Web.Models.Astronauts;
using NISA.DS.Web.Models.Rockets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NISA.DS.Web.Models.TripTypes;

namespace NISA.DS.Web.Controllers
{
    public class SearchController : Controller
    {
        #region Data and Constructors

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SearchController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Actions

        public async Task<IActionResult> Search(string searchType, string keyword)
        {
            if (searchType == "astronaut")
            {
                var astronautVMs = await SearchByAstronautName(keyword);
                return View("SearchAstronaut", astronautVMs);
            }

            else if (searchType == "rocket")
            {
                var rocketVMs = await SearchByRocketName(keyword);
                return View("SearchRocket", rocketVMs);
            }

            else if (searchType == "ticketType")
            {
                var tripTypeVMs = await SearchByTripType(keyword);
                return View("SearchTripType", tripTypeVMs);
            }

            else
            {
                return NotFound();
            }
        }


        #endregion

        #region Private Methods

        private async Task<List<AstronautListViewModel>> SearchByAstronautName(string keyword)
        {
            var astronauts = await _context
                                       .Astronauts
                                       .Where(a => a.FirstName.Contains(keyword) || a.LastName.Contains(keyword))
                                       .ToListAsync();

            var astronautVMs = _mapper.Map<List<AstronautListViewModel>>(astronauts);

            return astronautVMs;
        }

        private async Task<List<RocketListViewModel>> SearchByRocketName(string keyword)
        {
            var rockets = await _context
                                     .Rockets
                                     .Where(r => r.Brand.Contains(keyword) || r.Model.Contains(keyword))
                                     .Include(r => r.Astronaut)
                                     .ToListAsync();

            var rocketVMs = _mapper.Map<List<RocketListViewModel>>(rockets);

            return rocketVMs;
        }

        private async Task<List<TripTypeViewModel>> SearchByTripType(string keyword)
        {
            var tripTypes = await _context
                                       .TripTypes
                                       .Where(t => t.Ticket.Contains(keyword))
                                       .ToListAsync();

            var tripTypeVMs = _mapper.Map<List<TripTypeViewModel>>(tripTypes);

            return tripTypeVMs;
        }

        #endregion
    }
}
