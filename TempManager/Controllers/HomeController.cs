using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TempManager.Models;

namespace Ch11Ex1TempManager.Controllers
{
    public class HomeController : Controller
    {
        private TempManagerContext data { get; set; }
        public HomeController(TempManagerContext ctx) => data = ctx;

        public ViewResult Index()
        {
            var temps = data.Temps.OrderBy(t => t.Date).ToList();
            return View(temps);
        }

        //Entree
        [HttpGet]
        public ViewResult AddEntree() => View(new Entree());

        [HttpPost]
        public IActionResult AddEntree(Temp temp)
        {
            // server-side check for remote validation for duplicate date
            Temp check = data.Temps.FirstOrDefault(t => t.Date == temp.Date);
            if (check != null)
            {
                ModelState.AddModelError("Date",
                    $"The date {temp.Date?.ToShortDateString()} is already in the database.");
            }

            if (ModelState.IsValid)
            {
                data.Temps.Add(temp);
                data.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                // model-level validation message
                ModelState.AddModelError("", "Please correct all errors.");
                return View(temp);
            }
        }

        //Sides
        [HttpGet]
        public ViewResult AddSide() => View(new Side());

        [HttpPost]
        public IActionResult AddSide(Temp temp)
        {
            // server-side check for remote validation for duplicate date
            Temp check = data.Temps.FirstOrDefault(t => t.Date == temp.Date);
            if (check != null)
            {
                ModelState.AddModelError("Date",
                    $"The date {temp.Date?.ToShortDateString()} is already in the database.");
            }

            if (ModelState.IsValid)
            {
                data.Temps.Add(temp);
                data.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                // model-level validation message
                ModelState.AddModelError("", "Please correct all errors.");
                return View(temp);
            }
        }

        //Desserts
        [HttpGet]
        public ViewResult AddDessert() => View(new Dessert());

        [HttpPost]
        public IActionResult AddDessert(Temp temp)
        {
            // server-side check for remote validation for duplicate date
            Temp check = data.Temps.FirstOrDefault(t => t.Date == temp.Date);
            if (check != null)
            {
                ModelState.AddModelError("Date",
                    $"The date {temp.Date?.ToShortDateString()} is already in the database.");
            }

            if (ModelState.IsValid)
            {
                data.Temps.Add(temp);
                data.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                // model-level validation message
                ModelState.AddModelError("", "Please correct all errors.");
                return View(temp);
            }
        }

        [HttpGet]
        public ViewResult DeleteEntree(int id)
        {
            var temp = data.Temps.Find(id);
            return View(temp);
        }

        [HttpPost]
        public RedirectToActionResult DeleteEntree(Temp temp)
        {
            data.Remove(temp);
            data.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult DeleteSide(int id)
        {
            var temp = data.Temps.Find(id);
            return View(temp);
        }

        [HttpPost]
        public RedirectToActionResult DeleteSide(Temp temp)
        {
            data.Remove(temp);
            data.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult DeleteDessert(int id)
        {
            var temp = data.Temps.Find(id);
            return View(temp);
        }

        [HttpPost]
        public RedirectToActionResult DeleteDessert(Temp temp)
        {
            data.Remove(temp);
            data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}