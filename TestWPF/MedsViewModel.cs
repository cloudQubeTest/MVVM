using System.Windows.Input;
using PatientsDataModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace PatientMVVM
{
    public class MedsViewModel : ObservableObject
    {
        private readonly ConnectedRepository _repo;

        //Medication emptyMed = new Medication();
        List<Medication> emptyMedList = new List<Medication>();
        public MedsViewModel(Patient selectedPatient, ConnectedRepository repo)
        {
            //_selectedPatient = new Patient();
            _selectedPatient = selectedPatient;
            List<Medication> MedList = new List<Medication>(SelectedPatient.MedicationRx);
            _medication = new ObservableCollection<Medication>(MedList);
            this._repo = repo;
            SelectedMedication = Medication.FirstOrDefault();
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
                List<Medication> MedList = new List<Medication>(_selectedPatient.MedicationRx);
                this.Medication = new ObservableCollection<Medication>(MedList);


                RaisePropertyChangedEvent("SelectedPatient");
            }
        }

       //private ObservableCollection<Medication> _medication = new ObservableCollection<Medication>();
       private ObservableCollection<Medication> _medication;
        public ObservableCollection<Medication> Medication
        {
            get
            {

                    return _medication; //TODO broken
            }
            set
            {
                _medication = value;
                RaisePropertyChangedEvent("Medication");

            }
        }

        private int _selectedMedIndex;
        public int SelectedMedIndex
        {
            get
            {
                return _selectedMedIndex;
            }
            set
            {
                _selectedMedIndex = value;
                if(_selectedMedIndex >= 0 && Medication.Count != 0)
                SelectedMedication = Medication[value];
                RaisePropertyChangedEvent("SelectedMedIndex");
            }
        }

        private Medication _selectedMedication;
        public Medication SelectedMedication
        {
            get
            {
                return _selectedMedication;
            }
            set
            {
                _selectedMedication = value;
                RaisePropertyChangedEvent("SelectedMedication");
            }
        }

        public void NewClick()
        {
            
    
        }

        public ICommand NewClickCommand
        {
            get { return new DelegateCommand(NewClick); }
        }

        public ICommand SaveClickCommand
        {
            get { return new DelegateCommand(SaveClick); }
        }

        private void SaveClick()
        {
            _repo.Save();
        }


    }
}