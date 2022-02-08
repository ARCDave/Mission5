using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5.Controllers
{
    public class HomeController : Controller
    {

        private MovieFormContext movieContext { get; set; }

        public HomeController(MovieFormContext applications)
        {
            
            movieContext = applications;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Category = movieContext.Category.ToList();
            
            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(MovieForm Response)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(Response);
                movieContext.SaveChanges();
                return RedirectToAction("MovieForm", Response);
            }
            else
            {
                ViewBag.Category = movieContext.Category.ToList();
                return View(Response);
            }
            

            
        }
        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = movieContext.Responses
                /*.Where()*/
                .OrderBy(x => x.Category)
                .ToList();
            var category = movieContext.Category
                .ToList();


            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Category = movieContext.Category.ToList();

            var movie = movieContext.Responses.Single(x => x.MovieId == movieid);

            return View("MovieForm", movie);
        }
        [HttpPost]
        public IActionResult Edit(MovieForm edit)
        {
            ViewBag.Category = movieContext.Category.ToList();

            movieContext.Update(edit);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            ViewBag.Category = movieContext.Category.ToList();

            var movie = movieContext.Responses.Single(x => x.MovieId == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieForm delete)
        {

            
            movieContext.Responses.Remove(delete);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
