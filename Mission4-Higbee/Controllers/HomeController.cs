using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission5_Higbee.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5_Higbee.Controllers
{
    public class HomeController : Controller //controller creation
    {
        private Context Movies { get; set; } //connects to the context model

        public HomeController(Context con)
        //information to connect to the database, context model
        {
            Movies = con;
        }

        public IActionResult Index() //return view for index page
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMovies() //get response for add movies web page
        {
            ViewBag.Categories = Movies.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovies(MovieResponse mr) //post response for add movies
        {
            if (ModelState.IsValid)
            {
                Movies.Add(mr); //adds the information into the response
                Movies.SaveChanges(); //saves the changes to the database
                return View("Confirmation", mr); //returns the confirmation view, movie response info saved
            }
            else
            {
                ViewBag.Categories = Movies.Categories.ToList();
                return View();
            }
        }

        public IActionResult PodcastInfo() //return view for podcast info page
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewMovies()
        {
           var table=Movies.Responses
                .Include(x=>x.Category)
                .ToList();

           return View(table); 
        }

        [HttpGet]
        public IActionResult Edit(int MovieSubmissionId)
        {
            ViewBag.Categories = Movies.Categories.ToList();
            var form = Movies.Responses.Single(x => x.MovieSubmissionId == MovieSubmissionId);
            return View("AddMovies", form);
        }

        [HttpPost]
        
        public IActionResult Edit(MovieResponse mr)
        {
            Movies.Update(mr);
            Movies.SaveChanges();
            return RedirectToAction("ViewMovies");
        }

        [HttpGet]
        public IActionResult Delete(int MovieSubmissionId)
        {
            var form = Movies.Responses.Single(x => x.MovieSubmissionId == MovieSubmissionId);
            return View(form);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse mr)
        {
            Movies.Responses.Remove(mr);
            Movies.SaveChanges();
            return RedirectToAction("ViewMovies");
        }
    }
    
}

