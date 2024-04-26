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
        public static Movie movie = new Movie() { Name="Shrek", Rating=5,DownloadUrl="#",ImageUrl= @"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS92cMXfUwQSMFMcS-U9JrsKK5XNJMw-P-Sus1MuxmWVHVJ03AC-DtMc-betZYjA6UaD7O-fmJ6MrXj4urZStnTHZr_r6q7BMC4hYDA6IE" };
        public static List<Client> clients = new List<Client>() {
            new Client(){ Name="Aleksandar S.",MovieCard="1234",Address="bul. Partizanski odredi 19",Phone="070390346",Age=17},
            new Client(){ Name="Gorazd F.",MovieCard="321",Address="Vladimir Komarov",Phone="070333000",Age=20},
            new Client(){ Name="Trajko T.",MovieCard="2345",Address="Ilindenska 15",Phone="072233111",Age=29}
        }; //ova kje ni bide MODELOT ^^^^^
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Random()
        {
            MovieRentals model = new MovieRentals();
            model.clients = clients;
            model.movie = movie;
            return View(model);
        }
        public ActionResult ShowClient(int id) { 
       
            return View(clients.ElementAt(id));
        }
    }
}