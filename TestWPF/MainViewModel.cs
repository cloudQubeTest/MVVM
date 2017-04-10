using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PatientsDataModel;
//using PatientMVVM;

namespace PatientMVVM
{
    public class MainViewModel : ObservableObject
    {
        private readonly ConnectedRepository _repo = new ConnectedRepository();

        //Patient John1 = new Patient();
        //Patient John2 = new Patient();
        List<Patient> testData;

        private ObservableCollection<Patient> _patients;

        public ContactViewModel ContactTab
        { get; set; }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                SelectedPatient = Patients[value];
                ContactTab.SelectedPatient = Patients[value];
                RaisePropertyChangedEvent("SelectedIndex");
            }
        }

        public ObservableCollection<Patient> Patients
        {
            get
            {
                return _patients;
            }
            set
            {
                _patients = value;
                RaisePropertyChangedEvent("Patients");

            }
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

                //FirstName = _selectedPatient != null ? _selectedPatient.FirstName : "";
                //LastName = _selectedPatient != null ? _selectedPatient.LastName : "";
                //Age = _selectedPatient != null ? _selectedPatient.Age : 0;

                RaisePropertyChangedEvent("SelectedPatient");
            }
        }

        private ContactViewModel _tab1;
        public ContactViewModel Tab1
        {
            get
            {
                return _tab1;
            }
            set
            {
                if (_tab1 != value)
                {
                    _tab1 = value;
                    RaisePropertyChangedEvent("Tab1");
                }
            }
        }


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

        public ICommand SaveClickCommand
        {
            get { return new DelegateCommand(SaveClick); }
        }

        private void SaveClick()
        {
            _repo.Save();
        }

        public MainViewModel()
        {
            testData = new List<Patient>(_repo.GetPatients());
            //John1.FirstName = "John";
            //John1.LastName = "Doe";
            //John1.Age = 35;
            //John2.FirstName = "Jim";
            //John2.LastName = "Dale";
            //John2.Age = 56;
            //testData.Add(John1);
            //testData.Add(John2);
            _selectedPatient = testData[0];
            ContactTab = new ContactViewModel(_selectedPatient);
            Patients = new ObservableCollection<Patient>(testData);
        }
    }
}