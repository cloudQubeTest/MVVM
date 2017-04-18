using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using PatientsDataModel;
using System.Windows.Input;

namespace PatientMVVM
{
    class ImageViewModel : ObservableObject
    {
        public BitmapImage Image_Loaded()
        {
            // ... Create a new BitmapImage.
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri("C:\\Users\\Colin\\Documents\\Projects\\TestWPF\\Test.png");
            b.EndInit();

            return b;
       
        }

      

    }
}
