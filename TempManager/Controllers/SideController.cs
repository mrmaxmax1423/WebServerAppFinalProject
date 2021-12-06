using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FoodManager.Models;

namespace FoodManager.Controllers
{
    public class SideController : Controller
    {
        private DishesContext data { get; set; }
        public SideController(DishesContext ctx) => data = ctx;
        public ViewResult Index()
        {
            var sides = data.Sides.OrderBy(t => t.Date).ToList();
            return View(sides);
        }

        [HttpGet]
        public ViewResult AddSide() => View(new Side());

        [HttpPost]
        public IActionResult AddSide(Side side)
        {
            data.Sides.Add(side);
            data.SaveChanges();
            return View(side);
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
    }
}
