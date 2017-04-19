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

        public static Image testImg1 = Image.FromFile(@"C:\Users\Colin\Documents\Projects\TestWPF\TestWPF\Test.png");
        public static Image testImg2 = Image.FromFile(@"C:\Users\Colin\Documents\Projects\TestWPF\TestWPF\Test2.png");

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
                    Image = byteImg2
                 
                };
                var b = new Patient
                {
                    FirstName = "Sara",
                    LastName = "Grey",
                    Age = 42,
                    Image = byteImg1

                };
                var c = new Patient
                {
                    FirstName = "Don",
                    LastName = "Green",
                    Age = 10,
                    Image = byteImg1
                };
                var d = new Patient
                {
                    FirstName = "Sally",
                    LastName = "Black",
                    Age = 78,
                    Image = byteImg2
                };
                context.Patients.AddRange(new List<Patient> { a, b, c, d });
           

                context.SaveChanges();
            }
        }
    }
}

