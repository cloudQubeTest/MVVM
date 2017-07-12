using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows;
using PatientsDataModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;

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

        public static Bitmap BitmapSourceToBitmap(BitmapSource bitmapsource)
        {
            Bitmap bitmap;
            using (var outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(outStream);
                bitmap = new Bitmap(outStream);
            }
            return bitmap;
        }

        public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Png);
            return ms.ToArray();
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
                updateImage();
                RaisePropertyChangedEvent("SelectedPatient");
                
            }
        }

        private BitmapSource _bitmapSource;

        public ImageViewModel(Patient selectedPatient)
        {
           _selectedPatient = selectedPatient;
            if (selectedPatient != null && selectedPatient.Image != null)
            {
                Bitmap bitmap = new Bitmap(ImageConversion.byteArrayToImage(SelectedPatient.Image));
                ImageSource = ImageConversion.BitmapToBitmapSource(bitmap);
            }
        }
  
        public BitmapSource ImageSource
        {
            get
            {
                return _bitmapSource;
            }
            set
            {
                _bitmapSource = value;
                RaisePropertyChangedEvent("ImageSource");
            }
        }

        public void updateImage()
        {
            Bitmap bitmap;
            if (SelectedPatient.Image != null)
            {
                bitmap = new Bitmap(ImageConversion.byteArrayToImage(SelectedPatient.Image));
            }
            else
            {
                bitmap = new Bitmap(@"../../blank.png");
            }
            ImageSource = ImageConversion.BitmapToBitmapSource(bitmap);
        }

        private string getFilePath()
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            string path = "";
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                path = dialog.FileName;
            }
            return path;
        }


        private System.Drawing.Image imgToStore;

        private void AddImageClick()
        {
            string path = getFilePath();
            if (path != "")
            {
                Bitmap addImg = new Bitmap(path);
                ImageSource = ImageConversion.BitmapToBitmapSource(addImg);

                imgToStore = System.Drawing.Image.FromFile(path);
                SelectedPatient.Image = ImageConversion.imageToByteArray(imgToStore);
            }
        }

        public ICommand AddClickCommand
        {
            get { return new DelegateCommand(AddImageClick); }
        }


        private void GrayscaleClick()
        {
            if (SelectedPatient.Image != null)
            {
                FormatConvertedBitmap grayscaleBpm = new FormatConvertedBitmap(_bitmapSource, PixelFormats.Gray8, BitmapPalettes.Gray256, 0.0);
                Bitmap editBpm = new Bitmap(ImageConversion.BitmapSourceToBitmap(grayscaleBpm));
                ImageSource = grayscaleBpm;
                SelectedPatient.Image = ImageConversion.imageToByteArray(editBpm);
            }

        }

        public ICommand GrayscaleClickCommand
        {
            get { return new DelegateCommand(GrayscaleClick); }
        }


    }
}
