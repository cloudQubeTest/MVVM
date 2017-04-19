using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows;
using PatientsDataModel;
using System.IO;

namespace PatientMVVM
{
    public static class ImageConversion
    {
        public static BitmapSource BitmapToBitmapSource(Bitmap source)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                          source.GetHbitmap(),
                          IntPtr.Zero,
                          Int32Rect.Empty,
                          BitmapSizeOptions.FromEmptyOptions());
        }

        public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
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
            Bitmap bitmap = new Bitmap(ImageConversion.byteArrayToImage(SelectedPatient.Image));
            _bitmapSource = ImageConversion.BitmapToBitmapSource(bitmap);
        }
        //TODO: Remove lines 54 and 55 and place into own method to see if pictures will change
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
