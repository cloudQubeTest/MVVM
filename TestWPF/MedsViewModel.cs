using System.Windows.Input;
using PatientsDataModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace PatientMVVM
{
    public class MedsViewModel : ObservableObject
    {

        //Medication emptyMed = new Medication();
        List<Medication> emptyMedList = new List<Medication>();
        public MedsViewModel(Patient selectedPatient)
        {
            this._selectedPatient = selectedPatient;
            this.Medication = new ObservableCollection<Medication>(selectedPatient.MedicationRx);
            this._medication = new ObservableCollection<Medication>(emptyMedList);
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


    }
}