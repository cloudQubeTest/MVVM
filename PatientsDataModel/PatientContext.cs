using System.Data.Entity;
using PatientsDataModel;


namespace PatientsDataModel
{
    public class PatientContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medication> Medications { get; set; }
    }
}
