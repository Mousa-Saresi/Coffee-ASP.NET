using System.Diagnostics;
using Coffee_Shop2.Data;
using Coffee_Shop2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Coffee_Shop2.Controllers
{
    public class HomeController : Controller
    {

        private readonly CoffeeDbContext _context;


        public HomeController(CoffeeDbContext C)
        {
            _context = C;

        }

        public IActionResult about()
        {
            return View();
        }
        [Authorize]
        public IActionResult menu()
        {
            return View();
        }
        [Authorize]
        public IActionResult service()
        {
            return View();
        }

        [Authorize]
        public IActionResult testimonil()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult reservation()
        {

            
                IEnumerable<Coffee> CoffeeShope = _context.CoffeeShope.ToList();

             

            return View(CoffeeShope);
        }
        

        [HttpGet]
        public IActionResult Add()
        {
           


         
            return View();
        }
        [HttpPost]
        public IActionResult Add(Coffee C)
        {
            if (ModelState.IsValid)
            {
                _context.CoffeeShope.Add(C);
                _context.SaveChanges();
                TempData["Message"] = "your booking is dun";
                return RedirectToAction("Add");
            }
            else
                return View(C);
        }



        [HttpGet]
        public IActionResult Update(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }



            var Coff = _context.CoffeeShope.SingleOrDefault(x => x.id == id);

            return View(Coff); 
        }

        [HttpPost]
        public IActionResult Update(Coffee C)
        {
            if (ModelState.IsValid)
            {
                _context.CoffeeShope.Update(C);
                _context.SaveChanges();
                TempData["Message"] = "your Updating is dun";
                return RedirectToAction("Update");
            }
            else
                return View(C);
        }

        [HttpGet]
        public IActionResult Delete (int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }



            var Coff = _context.CoffeeShope.SingleOrDefault(x => x.id == id);

            return View(Coff);
        }

        public IActionResult Delete(Coffee C)
        {

            if (ModelState.IsValid)
            {
                _context.CoffeeShope.Remove(C);
                _context.SaveChanges();
                TempData["Message"] = "your Delete is dun";
                return RedirectToAction("Delete");

            }
            else
            {
                return View(C);
            }
        }
    }
}