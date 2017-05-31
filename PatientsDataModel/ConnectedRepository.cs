using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using PatientsDataModel;

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
            _context.Patients.Add(patient);
            return patient;
        }

        public Medication NewMedication()
        {
            var medication = new Medication();
            _context.Medications.Add(medication);
            return medication;
        }



#if false
  //Quick way to initialize and seed the database on first use.
    public ConnectedRepository() {
      DataHelpers.removeDB();
    }

#endif
    }
}
