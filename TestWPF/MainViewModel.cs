using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PatientMVVM.PatientModel;

namespace PatientMVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        Patient John1 = new Patient();
        Patient John2 = new Patient();
        List<Patient> testData = new List<Patient>(2);

        private ObservableCollection<Patient> _patients;

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

        public MainViewModel()
        {
            John1.FirstName = "John";
            John1.LastName = "Doe";
            John2.FirstName = "Jim";
            John2.LastName = "Dale";
            testData.Add(John1);
            testData.Add(John2);
            Patients = new ObservableCollection<Patient>(testData);
        }
    }
}