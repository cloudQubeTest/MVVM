using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientsDataModel
{
    public class DataHelpers
    {
        public static void NewDbWithSeed()
        {

            Database.SetInitializer(new DropCreateDatabaseAlways<PatientContext>());
            using (var context = new PatientContext())
            {
                if (context.Patients.Any())
                {
                    return;
                }

                var a = new Patient
                {
                    FirstName = "Joe",
                    LastName = "White",
                    Age = 35
                 
                };
                var b = new Patient
                {
                    FirstName = "Sara",
                    LastName = "Grey",
                    Age = 42

                };
                var c = new Patient
                {
                    FirstName = "Don",
                    LastName = "Green",
                    Age = 10
                };
                var d = new Patient
                {
                    FirstName = "Sally",
                    LastName = "Black",
                    Age = 78
                };
                context.Patients.AddRange(new List<Patient> { a, b, c, d });
           

                context.SaveChanges();
            }
        }
    }
}

