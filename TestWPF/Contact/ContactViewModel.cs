using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PatientMVVM.Models;

namespace PatientMVVM.ViewModels
{
    public class ContactViewModel : ObservableObject
    {
        private string _someText = TestData.Data;

        public string SomeText
        {
            get { return _someText; }

        }

        public ICommand ClickCommand
        {
            get { return new DelegateCommand(ConvertText); }
        }

        private void ConvertText()
        {
            //if (string.IsNullOrWhiteSpace(SomeText)) return;
            //AddToHistory(_textConverter.ConvertText(SomeText));
            //SomeText = string.Empty;
        }

        //public ContactViewModel()
        //{

        //}


    }
}