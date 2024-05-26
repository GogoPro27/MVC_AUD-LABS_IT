using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAB_3_onceMore.Models.HospitalModels
{
    public class Doctor
    {
        [Key]
        public int Id{ get; set; }
        public string Name { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual List<Patient> Patients{ get; set; }
        public Doctor() { 
            Patients = new List<Patient>(); 
        }

    }
}