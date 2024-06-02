using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vezba.Models
{
    public class AddDoctorToHospitalModel
    {
        public int HospitalId { get; set; }
        public int DoctorId { get; set; }
        public List<Doctor> Doctors { get; set; }

        public AddDoctorToHospitalModel()
        {
            Doctors = new List<Doctor>();
        }
    }
}