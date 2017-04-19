using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows;
using PatientsDataModel;

namespace PatientMVVM
{
    public static class BitmapConversion
    {
        public static BitmapSource BitmapToBitmapSource(Bitmap source)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                          source.GetHbitmap(),
                          IntPtr.Zero,
                          Int32Rect.Empty,
                          BitmapSizeOptions.FromEmptyOptions());
        }
    }
    public class ImageViewModel : ObservableObject
    {
        
        private Patient _selectedPatient;

        public Patient SelectedPatient
        {
            get
            {
                return _selectedPatient;
            }
            set
            {
                _selectedPatient = value;


                RaisePropertyChangedEvent("SelectedPatient");
            }
        }

        private BitmapSource _bitmapSource;

        public ImageViewModel(Patient selectedPatient)
        {
            _selectedPatient = selectedPatient;
            Bitmap bitmap = (Bitmap)Bitmap.FromFile(@"C:\Users\Colin\Documents\Projects\TestWPF\Test.png", true);
            _bitmapSource = BitmapConversion.BitmapToBitmapSource(bitmap);
        }

        public BitmapSource ImageSource
        {
            get { return _bitmapSource; }
        }

        //public string DisplayedImage
        //{
        //    get { return @"C:\Users\Colin\Documents\Projects\TestWPF\TestWPF\Test.png"; }
        //}

    }
}
