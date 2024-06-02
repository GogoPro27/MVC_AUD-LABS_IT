using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vezba.Models
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name="Image")]
        public string Img_Url { get; set; }
        public virtual List<Doctor> Doctors { get; set; }

        public Hospital()
        {
            Doctors = new List<Doctor>();
        }
    }
}