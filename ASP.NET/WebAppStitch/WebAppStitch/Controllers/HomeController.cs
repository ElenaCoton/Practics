using System.Diagnostics;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Stitch.Core;
using Stitch.Core.Dtos;
using WebAppStitch.Data;
using WebAppStitch.Models;

namespace WebAppStitch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DataContext db;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {

            var allManufactures = db.Manufacturer.ToList<ManufacturerDto>();
            ViewBag.Manufactures = allManufactures;
            var kitCount = db.Kit.Count();
            ViewBag.KitCount = kitCount;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
