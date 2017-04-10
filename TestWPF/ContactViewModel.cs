using System.Windows.Input;
using PatientsDataModel;

namespace PatientMVVM
{
    public class ContactViewModel :  ObservableObject
    {
        //public ContactViewModel() { }
        public ContactViewModel(Patient selectedPatient)
        {
            this._selectedPatient = selectedPatient;
        }

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

        //public Patient SelectedPatient
        //{
        //    get
        //    {
        //        return _selectedPatient;
        //    }
        //    set
        //    {
        //        _selectedPatient = value;

        //        FirstName = _selectedPatient != null ? _selectedPatient.FirstName : "";
        //        LastName = _selectedPatient != null ? _selectedPatient.LastName : "";
        //        Age = _selectedPatient != null ? _selectedPatient.Age : 0;

        //        RaisePropertyChangedEvent("SelectedPatient");
        //    }
        //}

        //private string _firstName;
        //public string FirstName
        //{
        //    get
        //    {
        //        return _firstName;
        //    }
        //    set
        //    {
        //        _firstName = value;
        //        if (SelectedPatient != null)
        //        {
        //            SelectedPatient.FirstName = _firstName;
        //        }
        //        RaisePropertyChangedEvent("FirstName");
        //    }
        //}

        //private string _lastName;
        //public string LastName
        //{
        //    get
        //    {
        //        return _lastName;
        //    }
        //    set
        //    {
        //        _lastName = value;
        //        if (SelectedPatient != null)
        //        {
        //            SelectedPatient.LastName = _lastName;
        //        }
        //        RaisePropertyChangedEvent("LastName");
        //    }
        //}
        //private int _age;
        //public int Age
        //{
        //    get
        //    {
        //        return _age;
        //    }
        //    set
        //    {
        //        _age = value;
        //        if (SelectedPatient != null)
        //        {
        //            SelectedPatient.Age = _age;
        //        }
        //        RaisePropertyChangedEvent("Age");
        //    }
        //}

        //private string _someText = TestData.Data;

        //public string SomeText
        //{
        //    get { return _someText; }

        //}

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