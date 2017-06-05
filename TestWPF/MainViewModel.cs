using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PatientsDataModel;
using System.Linq;
using System.Windows.Media.Imaging;
using System;
using System.Windows;

//using PatientMVVM;

namespace PatientMVVM
{
    public class MainViewModel : ObservableObject
    {
        private readonly ConnectedRepository _repo = new ConnectedRepository();

        //Patient John1 = new Patient();
        //Patient John2 = new Patient();
        List<Patient> testData;

        Patient emptyPatient = new Patient();

        private ObservableCollection<Patient> _patients;

        public ContactViewModel ContactTab
        { get; set; }

        public ImageViewModel ImageTab
        { get; set; }

        public RiskViewModel RiskTab
        { get; set; }

        public MedsViewModel MedTab
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
                if (_selectedIndex >= 0 && Patients.Count != 0)
                {
                    SelectedPatient = Patients[value];
                    ContactTab.SelectedPatient = Patients[value];
                    ImageTab.SelectedPatient = Patients[value];
                    RiskTab.SelectedPatient = Patients[value];
                    //MedTab.SelectedPatient = Patients[value];
                    //Patient _selectedPatientMeds = new Patient();
                    //_selectedPatientMeds = _repo.GetPatientWithMedication(value + 1);
                    //if (Patients[value] != null)
                        //if(SelectedPatient.MedicationRx != null)
                        if (MedTab == null)
                        MedTab = new MedsViewModel(getPMeds(_selectedPatient), _repo);
                        else
                        MedTab.SelectedPatient = getPMeds(Patients[value]); //TODO fix this
                                                                            //ImageTab = new ImageViewModel(SelectedPatient);
                }
                else
                {
                    emptyPatient.MedicationRx = new List<Medication>();
                    //SelectedPatient = emptyPatient;
                    ContactTab.SelectedPatient = emptyPatient;
                    ImageTab.SelectedPatient = emptyPatient;
                    RiskTab.SelectedPatient = emptyPatient;
                    MedTab.SelectedPatient = emptyPatient;

                }
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

        public IEnumerable<Sex> Sex
        {
            get
            {
                return Enum.GetValues(typeof(Sex)).Cast<Sex>();
            }
        }

        public Patient getPMeds(Patient patient)
        {
            return _repo.GetPatientWithMedication(patient.Id);
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
            //if (SelectedPatient.MedicationRx != null) //TODO fix this
            _repo.Save();
        }

        private void NewClick()
        {
            Patient newPatient = new Patient();
            newPatient = _repo.NewPatient();
            SelectedPatient = newPatient;
            Patients.Add(SelectedPatient);
            SaveClick();
            SelectedIndex = (Patients.Count - 1);
            RaisePropertyChangedEvent("SelectedPatient");
            RaisePropertyChangedEvent("SelectedIndex");
            RaisePropertyChangedEvent("Patients");
            //RaisePropertyChangedEvent("MedTab");
           // MedTab.NewClick();
        }

        public ICommand NewClickCommand
        {
            get { return new DelegateCommand(NewClick); }
        }

        private void NewMedClick()
        {
            if(Patients.Count == 0)
            {
                MessageBox.Show("Create a new patient first.", "Cannot Add Medication", MessageBoxButton.OK);
                return;
            }
            Medication newMed = new Medication();
            SelectedPatient.MedicationRx.Add(newMed);
            MedTab.SelectedPatient = getPMeds(Patients[SelectedIndex]);

        }


        public ICommand NewMedClickCommand
        {
            get { return new DelegateCommand(NewMedClick); }
        }

        private void DeletePatientClick()
        {
            if (SelectedPatient == null)
                MessageBox.Show("No Patient to Delete", "Cannot Delete", MessageBoxButton.OK);
            else
            {
                switch (MessageBox.Show("Delete Selected Patient?", "Patient Entry", MessageBoxButton.YesNo))
                {
                    case MessageBoxResult.Yes:
                        var patientToDelete = SelectedPatient;
                        //if (SelectedIndex == 0)
                        //    if(Patients.Count == 1)
                        //    SelectedIndex++;
                        //else
                        //SelectedIndex = 0;
                        _repo.DeleteCurrentPatient(patientToDelete);
                        Patients.Remove(patientToDelete);
                        SelectedIndex = 0;
                        if(Patients.Count == 0)
                            SelectedPatient = emptyPatient;
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        public ICommand DeleteClickCommand
        {
            get { return new DelegateCommand(DeletePatientClick); }
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
            //_selectedPatient = testData.FirstOrDefault();
            //_selectedIndex = 1;
            SelectedPatient = testData.FirstOrDefault();
            //Patient _selectedWithMeds = new Patient();
            //_selectedWithMeds = _repo.GetPatientWithMedication(1);
            ContactTab = new ContactViewModel(_selectedPatient);
            ImageTab = new ImageViewModel(_selectedPatient);
            RiskTab = new RiskViewModel(_selectedPatient);
            if(_selectedPatient != null)
            MedTab = new MedsViewModel(getPMeds(_selectedPatient), _repo);
            else
            {
                emptyPatient.MedicationRx = new List<Medication>();
                MedTab = new MedsViewModel(emptyPatient, _repo);

            }
            Patients = new ObservableCollection<Patient>(testData);
        }
    }
}