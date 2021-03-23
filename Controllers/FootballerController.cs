using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SoccerCatalog.Interfaces;
using SoccerCatalog.Models;

namespace SoccerCatalog.Controllers
{
    public class FootballerController : Controller
    {

        private readonly IFootballerRepository FootballerRepository;
        private readonly IHubContext<SignalServer> context;

        public FootballerController(IFootballerRepository FootballerRepository, IHubContext<SignalServer> context)
        {
            this.FootballerRepository = FootballerRepository;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(FootballerRepository.All());
        }

        [HttpGet]
        public IActionResult AddFootballer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFootballer(Footballer model)
        {
            if (!ModelState.IsValid) return View(model);

            FootballerRepository.Add(model);
            FootballerRepository.SaveChanges();
            context.Clients.All.SendAsync("refreshFootballers");
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult EditFootballer(Guid id)
        {
            return View(FootballerRepository.Find(id));
        }
        [HttpPost]
        public IActionResult EditFootballer(Footballer model)
        {
            if (!ModelState.IsValid) return View(model);

            var Footballer = FootballerRepository.Find(model.Id);
            Footballer.FirstName = model.FirstName;
            Footballer.LastName = model.LastName;
            Footballer.BirthDate = model.BirthDate;
            Footballer.Country = model.Country;
            Footballer.Gender = model.Gender;
            Footballer.TeamName = model.TeamName;
            FootballerRepository.Update(Footballer);
            FootballerRepository.SaveChanges();

            context.Clients.All.SendAsync("refreshFootballers");
            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult DeleteFootballer(Guid footballerId)
        {
            var footballer = FootballerRepository.Find(footballerId);
            FootballerRepository.Delete(footballer);
            FootballerRepository.SaveChanges();
            context.Clients.All.SendAsync("refreshFootballers");
            return RedirectToAction("index");
        }
    }
}