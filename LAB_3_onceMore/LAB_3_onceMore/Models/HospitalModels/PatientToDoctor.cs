using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_3_onceMore.Models.HospitalModels
{
    public class PatientToDoctor
    {
        public int DoctorId { get; set; }
        public int SelectedPatientId { get; set; }
        public List<Patient> Patients { get; set; }

        public PatientToDoctor() { Patients = new List<Patient>(); }

    }
}