﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace PatientsDataModel
{
    public class ConnectedRepository
    {
        private readonly PatientContext _context = new PatientContext();


        public Patient GetPatientById(int id)
        {
            return _context.Patients.Find(id);
        }

        public List<Patient> GetPatients()
        {
            return _context.Patients.ToList();
        }

        public Patient GetPatientWithMedication(int id)
        {
            return _context.Patients.Include(p => p.MedicationRx)
              .FirstOrDefault(p => p.Id == id);
        }

        public void DeleteCurrentPatient(Patient patient)
        {
            _context.Patients.Remove(patient);
            Save();
        }

        public void DeleteCurrentMedication(Medication medication)
        {
            _context.Medications.Remove(medication);
            Save();
        }


        public ObservableCollection<Patient> PatientsInMemory()
        {
            if (_context.Patients.Local.Count == 0)
            {
                GetPatients();
            }
            return _context.Patients.Local;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Patient NewPatient()
        {
            var patient = new Patient();
            var meds = new List<Medication>();
            patient.MedicationRx = meds;
            _context.Patients.Add(patient);
            return patient;
        }

        public Medication NewMedication()
        {
            var medication = new Medication();
            return medication;
        }



#if true
  //Quick way to initialize and seed the database on first use.
    public ConnectedRepository() {
                DataHelpers.NewDbWithSeed();
        }
#endif
        //Quick way to wipe DB if set to true, set the above block to false
#if false
        public ConnectedRepository()
        {
            DataHelpers.removeDB();
        }

#endif
    }
}
