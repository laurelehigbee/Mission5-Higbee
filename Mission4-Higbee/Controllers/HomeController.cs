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
                ViewBag.Categories = Movies.Categories.ToList(); //if the information is invalid
                return View();
            }
        }

        public IActionResult PodcastInfo() //return view for podcast info page
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewMovies() //return get request for the View Movies table
        {
           var table=Movies.Responses
                .Include(x=>x.Category) //includes the name for each category, rather than the number
                .ToList();

           return View(table); 
        }

        [HttpGet]
        public IActionResult Edit(int MovieSubmissionId) //return get request for the edit request
        { 
            ViewBag.Categories = Movies.Categories.ToList(); //allows for movie categories to be used
            var form = Movies.Responses.Single(x => x.MovieSubmissionId == MovieSubmissionId);
            //identifies which record is being edited
            return View("AddMovies", form); //returns editable information
        }

        [HttpPost]
        
        public IActionResult Edit(MovieResponse mr) //response for the post request for editing
        {
            Movies.Update(mr); //updates the movie
            Movies.SaveChanges(); //saves changes
            return RedirectToAction("ViewMovies"); //redirects to the table
        }

        [HttpGet]
        public IActionResult Delete(int MovieSubmissionId)//response for the get request for deleting
        {
            var form = Movies.Responses.Single(x => x.MovieSubmissionId == MovieSubmissionId);
            //identifies which record is being deleted
            return View(form);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse mr)//response for the post request for deleting
        {
            Movies.Responses.Remove(mr); //removes the record 
            Movies.SaveChanges();//saves the changes
            return RedirectToAction("ViewMovies"); //redirects to view movies table
        }
    }
    
}

