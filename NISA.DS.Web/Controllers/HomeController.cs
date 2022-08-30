using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NISA.DS.Utils.Enums;
using NISA.DS.Web.Data;
using NISA.DS.Web.Models;
using NISA.DS.Web.Models.Home;
using NISA.DS.Web.Models.Trip;
using System.Diagnostics;

namespace NISA.DS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var homePageVM = new HomePageViewModel();

            homePageVM.Trips = await Get3VIPTickets();

            return View(homePageVM);
        }

        private async Task<List<TripListViewModel>> Get3VIPTickets()
        {
            var vIPTickets = await _context
                                        .Trips
                                        .Where(t => t.TicketType == TicketType.VIP)
                                        .OrderByDescending(t => t.Price)
                                        .ToListAsync();

            var vIPTicketVMs = _mapper.Map<List<TripListViewModel>>(vIPTickets);

            return vIPTicketVMs;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}