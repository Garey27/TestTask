using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SoccerCatalog.Interfaces;
using SoccerCatalog.Models;

namespace SoccerCatalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFootballerRepository footballerRepository;

        public HomeController(IFootballerRepository footballerRepository)
        {
            this.footballerRepository = footballerRepository;
        }

        [HttpGet]
        public IActionResult GetFootballers()
        {
            return Ok(footballerRepository.All());
        }
        public IActionResult Index()
        {
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
