using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace PatientsDataModel
{

    public class DataHelpers
    {
        public static byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        public static Image testImg1 = Image.FromFile(@"../../Test.png");
        public static Image testImg2 = Image.FromFile(@"../../Test2.png");

        public static byte[] byteImg1 = imageToByteArray(testImg1);
        public static byte[] byteImg2 = imageToByteArray(testImg2);


           
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
                    Age = 35,
                    AddressLineOne = "786 N 15th ST",
                    AddressLineTwo = "App. 407",
                    City = "Redmond",
                    State = "Washington",
                    PostalCode = "98765",
                    Country = "United States",
                    Phone = "555-235-1291",
                    Email = "j.white@example.com",
                    Sedentary = true,
                    Med1Name = "Aleve",
                    Med1Dosage = "2x Daily",
                    Image = byteImg2,
                    MedicationRx = new List<Medication>()
                 
                };
                var aleve = new Medication
                {
                    Name = "Aleve",
                    Dosage = "250mg",
                    Frequency = "Twice Daily"

                };
                var vitD = new Medication
                {
                    Name = "Vitamin D",
                    Dosage = "500IU",
                    Frequency = "Daily"
                    
                };
                a.MedicationRx.Add(aleve);
                a.MedicationRx.Add(vitD);
                var b = new Patient
                {
                    FirstName = "Sara",
                    LastName = "Grey",
                    Age = 42,
                    AddressLineOne = "4112 23rd Ave",
                    City = "Seattle",
                    State = "Washington",
                    PostalCode = "98122",
                    Country = "United States",
                    Phone = "555-432-8921",
                    Email = "sara123@example.com",
                    Sedentary = false,
                    Image = byteImg1,
                    MedicationRx = new List<Medication>()

                };
                var ibu = new Medication
                {
                    Name = "Ibuprofen",
                    Dosage = "200mg",
                    Frequency = "Every 6 hours"

                };
                b.MedicationRx.Add(ibu);
                var c = new Patient
                {
                    FirstName = "Don",
                    LastName = "Green",
                    AddressLineOne = "567 NE 4th ST",
                    AddressLineTwo = "Summerview Apparment 304",
                    City = "Portland",
                    State = "Oregon",
                    PostalCode = "89771",
                    Country = "United States",
                    Phone = "555-111-8080",
                    Email = "dongreen@fake.net",
                    Age = 10,
                    Sedentary = true,
                    Image = byteImg1,
                    MedicationRx = new List<Medication>()
                };
                var ibu2 = new Medication
                {
                    Name = "Ibuprofen",
                    Dosage = "400mg",
                    Frequency = "Every 8 hours"

                };
                c.MedicationRx.Add(ibu2);
                var d = new Patient
                {
                    FirstName = "Sally",
                    LastName = "Black",
                    AddressLineOne = "222 22nd Ave",
                    City = "New York City",
                    State = "New York",
                    PostalCode = "45331",
                    Country = "United States",
                    Phone = "555-603-0921",
                    Email = "sallyb@notreal.org",
                    Age = 78,
                    Sedentary = false,
                    Image = byteImg2,
                    MedicationRx = new List<Medication>()
                };
                var tums = new Medication
                {
                    Name = "Calcium Carbonate",
                    Dosage = "500mg",
                    Frequency = "As needed"

                };
                d.MedicationRx.Add(tums);
                context.Patients.AddRange(new List<Patient> { a, b, c, d });
          
                context.SaveChanges();
            }
        }
    }
}

