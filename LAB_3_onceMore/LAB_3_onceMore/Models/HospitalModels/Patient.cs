using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAB_3_onceMore.Models.HospitalModels
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [RegularExpression(@"\d{5}")]
        public string PatientCode { get; set; }
        public string Gender { get; set; }

    }
}