using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FoodManager.Models;

namespace FoodManager.Controllers
{
    public class DessertController : Controller
    {
        private DishesContext data { get; set; }
        public DessertController(DishesContext ctx) => data = ctx;
        public ViewResult Index()
        {
            var desserts = data.Desserts.OrderBy(t => t.Date).ToList();
            return View(desserts);
        }

        [HttpGet]
        public ViewResult AddDessert() => View(new Dessert());

        [HttpPost]
        public IActionResult AddDessert(Dessert dessert)
        {
            data.Desserts.Add(dessert);
            data.SaveChanges();
            return View(dessert);
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
