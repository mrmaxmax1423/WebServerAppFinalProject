

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FoodManager.Models;

namespace Ch11Ex1FoodManager.Controllers
{
    public class HomeController : Controller
    {
        private DishesContext data { get; set; }
        public HomeController(DishesContext ctx) => data = ctx;

        public ViewResult Index()
        {
            var entrees = data.Entrees.OrderBy(t => t.Date).ToList();
            return View(entrees);
        }

        //Entree
        [HttpGet]
        public ViewResult AddEntree() => View(new Entree());

        [HttpPost]
        public IActionResult AddEntree(Entree entree)
        {
                data.Entrees.Add(entree);
                data.SaveChanges();
                return View(entree);

        }

        //Sides
        [HttpGet]
        public ViewResult AddSide() => View(new Side());

        [HttpPost]
        public IActionResult AddSide(Side side)
        {
            data.Sides.Add(side);
            data.SaveChanges();
            return View(side);
        }

        //Desserts
        [HttpGet]
        public ViewResult AddDessert() => View(new Dessert());

        [HttpPost]
        public IActionResult AddDessert(Dessert dessert)
        {
            data.Desserts.Add(dessert);
            data.SaveChanges();
            return View(dessert);
        }

        /* Attempting to add About us method */
        public ViewResult AboutUs()
        { 

            return View();
        }


        [HttpGet]
        public ViewResult DeleteEntree(int id)
        {
            var entree = data.Entrees.Find(id);
            return View(entree);
        }

        [HttpPost]
        public RedirectToActionResult DeleteEntree(Entree entree)
        {
            data.Remove(entree);
            data.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult DeleteSide(int id)
        {
            var side = data.Sides.Find(id);
            return View(side);
        }

        [HttpPost]
        public RedirectToActionResult DeleteSide(Side side)
        {
            data.Remove(side);
            data.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult DeleteDessert(int id)
        {
            var dessert = data.Desserts.Find(id);
            return View(dessert);
        }

        [HttpPost]
        public RedirectToActionResult DeleteDessert(Dessert dessert)
        {
            data.Remove(dessert);
            data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}