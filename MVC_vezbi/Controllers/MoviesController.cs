using MVC_vezbi.Models; //vazno za da moze da inicijaliziram objekti od Movie/Client...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_vezbi.Controllers
{
    public class MoviesController : Controller
    {
        //ova kje ni bide MODELOT vvvvvv
        public static List<Movie> moviesList = new List<Movie>() { 
            new Movie() { Name = "Shrek", Rating = 5, DownloadUrl = "#", ImageUrl = @"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS92cMXfUwQSMFMcS-U9JrsKK5XNJMw-P-Sus1MuxmWVHVJ03AC-DtMc-betZYjA6UaD7O-fmJ6MrXj4urZStnTHZr_r6q7BMC4hYDA6IE" } 
        };
        public static List<Client> clients = new List<Client>() {}; //ova kje ni bide MODELOT ^^^^^
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowMovie(int id)
        {
            MovieRentals model = new MovieRentals();
            model.clients = clients;
            model.movie = moviesList.ElementAt(id);
            return View(model);
        }
        public ActionResult GetAllMovies()
        {
            return View(moviesList);
        }
        public ActionResult ShowClient(int id) { 
       
            return View(clients.ElementAt(id));
        }
     
        public ActionResult NewMovie()
        {
            Movie model = new Movie();
            return View(model);
        }
        public ActionResult NewClient()
        {
            Client model = new Client();
            return View(model);
        }
        [HttpPost]
        public ActionResult InsertNewClient(Client model)
        {
            if (!ModelState.IsValid)
            {
                return View("NewClient", model);
            }
            clients.Add(model);
            return View("GetAllMovies",moviesList);
        }


        [HttpPost]//zasto ova ?
        public ActionResult InsertNewMovie(Movie model) {
            if (!ModelState.IsValid)
            {
                return View("NewMovie", model);
                //ova e mn jako i BITNO!!!
            }
            moviesList.Add(model);
            return View("GetAllMovies",moviesList);
        }
        public ActionResult EditMovie(int id)
        {
            var model = moviesList.ElementAt(id);
            //pametno za da posle go znam redniot broj
            model.Id= id;
            return View(model);
        }
        [HttpPost]
        public ActionResult EditMovieInList(Movie model)
        {
            if (!ModelState.IsValid)
            {
                return View("NewMovie", model);
                //ova e mn jako i BITNO!!!
            }

            var forUpdate = moviesList.ElementAt(model.Id);
            forUpdate.Name = model.Name;
            forUpdate.ImageUrl = model.ImageUrl;
            forUpdate.DownloadUrl = model.DownloadUrl;
            forUpdate.Rating = model.Rating;

            return View("GetAllMovies", moviesList);
        }

        public ActionResult DeleteMovie(int id) {
            if (moviesList.Count > 0)
            {
                moviesList.RemoveAt(id);
            }
            
            return View("GetAllMovies", moviesList);
        }
    }
}