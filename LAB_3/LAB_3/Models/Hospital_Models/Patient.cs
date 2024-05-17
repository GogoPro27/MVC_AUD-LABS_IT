using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAB_3.Models
{
    public class Patient
    {
        public Patient()
        {
            Doctors = new List<Doctor>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]{5}$",ErrorMessage ="Kodot treba da e tocno 5 karakteri")]
        [Display(Name ="Kod Na Pacient")]
        public string PatientCode { get; set; }
        public virtual List<Doctor> Doctors { get; set; }

    }
}