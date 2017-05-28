using System.Windows.Input;
using PatientsDataModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace PatientMVVM
{
    public class MedsViewModel : ObservableObject
    {
        private readonly ConnectedRepository _repo;

        //Medication emptyMed = new Medication();
        List<Medication> emptyMedList = new List<Medication>();
        public MedsViewModel(Patient selectedPatient, ConnectedRepository repo)
        {
            this._selectedPatient = selectedPatient;
            this.Medication = new ObservableCollection<Medication>(selectedPatient.MedicationRx);
            this._medication = new ObservableCollection<Medication>(emptyMedList);
            this._repo = repo;
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
                RaisePropertyChangedEvent("Medication");
            }
        }

       private ObservableCollection<Medication> _medication = new ObservableCollection<Medication>();
       // private ObservableCollection<Medication> _medication;
        public ObservableCollection<Medication> Medication
        {
            get
            {
                if (SelectedPatient == null)
                {
                    return _medication;
                }
                return new ObservableCollection<Medication>(SelectedPatient.MedicationRx);
            }
            set
            {
                _medication = new ObservableCollection<Medication>(value);
                RaisePropertyChangedEvent("Medication");

            }
        }

        private void NewClick()
        {
            var newMed = _repo.NewMedication();
            SelectedPatient.MedicationRx.Add(newMed);
            RaisePropertyChangedEvent("Medication");
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