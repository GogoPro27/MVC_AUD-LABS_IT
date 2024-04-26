using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_vezbi.Models
{
    public class MovieRentals
    {
        public Movie movie { get; set; }
        public List<Client> clients { get; set; }
        //posto ima lista mora da se postavi na prazna lista vo konstruktor

        public MovieRentals() { 
            clients = new List<Client>();
        }
    }
}