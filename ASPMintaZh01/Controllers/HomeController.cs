using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPMintaZh01.Models;
using ASPMintaZh01.Data;

namespace ASPMintaZh01.Controllers
{
    public class HomeController : Controller
    {
        GameLogic logic;
        public HomeController(SuperHeroContext dbcontext)
        {
            logic = new GameLogic(dbcontext);
        }
        public IActionResult Index()
        {
            return View(logic.GetAllHero());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new SuperHeroViewModel());
        }

        [HttpGet]
        public IActionResult Game(int id)
        {
            return View(logic.Fight(id));
        }

        public IActionResult ResetHealth()
        {
            logic.ResetHealth();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            logic.DeleteHero(id);
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Add(SuperHeroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            logic.AddHero(vm);
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int id)
        {
            var hero = logic.GetHeroById(id);
            return File(hero.Image, hero.ContentType);
        }

        public IActionResult Dark()
        {
            return View(logic.GetAllHero("dark"));
        }

        public IActionResult Light()
        {
            return View(logic.GetAllHero("light"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
