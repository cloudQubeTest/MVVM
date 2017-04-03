﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PatientMVVM.PatientModel;

namespace PatientMVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        Patient John1 = new Patient();
        Patient John2 = new Patient();
        List<Patient> testData = new List<Patient>();

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

                FirstName = _selectedPatient != null ? _selectedPatient.FirstName : "";
                LastName = _selectedPatient != null ? _selectedPatient.LastName : "";
                Age = _selectedPatient != null ? _selectedPatient.Age : 0;

                RaisePropertyChangedEvent("SelectedPatient");
            }
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                if (SelectedPatient != null)
                {
                    SelectedPatient.FirstName = _firstName;
                }
                RaisePropertyChangedEvent("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                if (SelectedPatient != null)
                {
                    SelectedPatient.LastName = _lastName;
                }
                RaisePropertyChangedEvent("LastName");
            }
        }
        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                if (SelectedPatient != null)
                {
                    SelectedPatient.Age = _age;
                }
                RaisePropertyChangedEvent("Age");
            }
        }

        public MainViewModel()
        {
            John1.FirstName = "John";
            John1.LastName = "Doe";
            John1.Age = 35;
            John2.FirstName = "Jim";
            John2.LastName = "Dale";
            John2.Age = 56;
            testData.Add(John1);
            testData.Add(John2);
            Patients = new ObservableCollection<Patient>(testData);
        }
    }
}