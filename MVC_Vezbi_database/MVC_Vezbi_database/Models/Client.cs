using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Vezbi_database.Models
{
    public class Client
    {
        public Client()
        {
            Movies = new List<Movie>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Phone { get; set; }
        public string MovieCard { get; set; }
        [Required]
        [Range(1, 99, ErrorMessage="Age must be berween 99")]//bitno
        public int Age { get; set; }

        public virtual List<Movie> Movies { get; set; }
    }
}