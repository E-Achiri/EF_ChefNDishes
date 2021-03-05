using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefNDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
 


namespace ChefNDishes.Controllers
{
    		public static class SessionExtensions
		{
		    // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
		    public static void SetObjectAsJson(this ISession session, string key, object value)
		    {
		        // This helper function simply serializes the object to JSON and stores it as a string in session
		        session.SetString(key, JsonSerializer.Serialize(value));
		    }
		       
		    // generic type T is a stand-in indicating that we need to specify the type on retrieval
		    public static T GetObjectFromJson<T>(this ISession session, string key)
		    {
		        string value = session.GetString(key);
		        // Upon retrieval the object is deserialized based on the type we specified
		        return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
		    }
}
    public class HomeController : Controller
    {
        private MyContext _context;
		     
		        // here we can "inject" our context service into the constructor
		        public HomeController(MyContext context)
		        {
		            _context = context;
		        }
		     
		        [HttpGet("")]
		        public IActionResult Index()
		        {
		            List<Chef> AllChefs = _context.Chefs.ToList();
		            List<Dish> AllDishes = _context.Dishes.ToList();
		            ViewBag.ChefList = AllChefs;
                    ViewBag.DishList = AllDishes;
		            return View();
        }

        [HttpPost("AddDish")]
        public IActionResult AddDish(Dish dish){
            if(ModelState.IsValid){

                _context.Add(dish);
                _context.SaveChanges();
                return RedirectToAction("DishDisplay");
            } else{
                return RedirectToAction("DishAdd");
            }
        }

        [HttpPost("AddChef")]
        public IActionResult AddChef(Chef chef){
            if(ModelState.IsValid){
                _context.Add(chef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else{
                return RedirectToAction("ChefAdd");
            }
        }

        [HttpGet("new")]
        public IActionResult ChefAdd(){
            return View("AddChef");
        }

        [HttpGet("dishes/new")]
        public IActionResult DishAdd(){
            List<Chef> AllChefs = _context.Chefs.ToList();
            ViewBag.ChefList = AllChefs;
            return View("AddDish");
        }

        [HttpGet("dishes")]
        public IActionResult DishDisplay(){
            List<Chef> AllChefs = _context.Chefs.ToList();
		            List<Dish> AllDishes = _context.Dishes.ToList();
		            ViewBag.ChefList = AllChefs;
                    ViewBag.DishList = AllDishes;
            return View("Dishes");
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
