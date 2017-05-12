using System.Windows.Input;
using PatientsDataModel;

namespace PatientMVVM
{
    public class RiskViewModel : ObservableObject
    {

        public RiskViewModel(Patient selectedPatient)
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

    }
}