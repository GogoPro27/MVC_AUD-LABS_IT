using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vezba.Models
{
    public class AddPatientToDoctorModel
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public List<Patient> Patients { get; set; }

        public AddPatientToDoctorModel()
        {
            Patients = new List<Patient>();
        }
    }
}