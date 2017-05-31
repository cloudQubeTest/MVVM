using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PatientsDataModel
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string DOB { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string MiddleName { get; set; }
        public Sex Sex { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Sedentary { get; set; }
        public bool Smoker { get; set; }
        public bool Diabetes { get; set; }
        public float LDL { get; set; }
        public float HDL { get; set; }
        public byte[] Image { get; set; }
        public List<Medication> MedicationRx { get; set; }
    }

    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        [Required]
        public Patient Patient { get; set; }
    }

}

