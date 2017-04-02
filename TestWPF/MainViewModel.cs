using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PatientMVVM.Models;

namespace PatientMVVM.ViewModels
{
    public class Presenter : ObservableObject
    {
        private string _someText;

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = "Testing";
                RaisePropertyChangedEvent("SomeText");
            }
        }

  

 
    }
}