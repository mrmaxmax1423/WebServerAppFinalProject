using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FoodManager.Models;

namespace FoodManager.Controllers
{
    public class EntreeController : Controller
    {
        private DishesContext data { get; set; }
        public EntreeController(DishesContext ctx) => data = ctx;
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
    }
}
