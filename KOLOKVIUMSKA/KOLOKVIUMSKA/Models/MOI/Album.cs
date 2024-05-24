using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace KOLOKVIUMSKA.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Store> stores { get; set; }
        public Album()
        {
            stores = new List<Store>();
        }
    }
}