using System.Data.Entity;
using PatientMVVM;


namespace PatientsDataModel
{
    public class PatientContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
    }
}
