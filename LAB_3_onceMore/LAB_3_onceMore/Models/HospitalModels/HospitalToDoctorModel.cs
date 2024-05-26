using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_3_onceMore.Models.HospitalModels
{
    public class HospitalToDoctorModel
    {
        public int DoctorId { get; set; }
        public List<Hospital> Hospitals { get; set; }
        public int ChosenHospitalId { get; set; }
    }
}