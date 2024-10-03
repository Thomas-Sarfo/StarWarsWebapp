using Microsoft.AspNetCore.Mvc;
using StarWarsDataAnalyzerWeb.Models;
using StarWarsDataAnalyzerWeb.Services;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsDataAnalyzerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SwapiService _swapiService;

        public HomeController(ILogger<HomeController> logger, SwapiService swapiService)
        {
            _logger = logger;
            _swapiService = swapiService;
        }

        public async Task<IActionResult> Index()
        {
            var planetResponse = await _swapiService.GetDataAsync<SwapiService.PlanetResponse>("planets");
            return View(planetResponse.Results);
        }

        public async Task<IActionResult> Dashboard()
        {
            var planetResponse = await _swapiService.GetDataAsync<SwapiService.PlanetResponse>("planets");

            // Preparar os dados para o gráfico
            var planetNames = planetResponse.Results.Select(p => p.Name).ToArray();
            var planetPopulations = planetResponse.Results.Select(p => 
                int.TryParse(p.Population, out var population) ? population : 0).ToArray();

            ViewBag.PlanetNames = planetNames;
            ViewBag.PlanetPopulations = planetPopulations;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
}
