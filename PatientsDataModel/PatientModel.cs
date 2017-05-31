using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PatientsDataModel
{
    public class Patient
    {
       
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
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
            }
        }

        public string DOB { get; set; }

        public string Height { get; set; }
        public string Weight { get; set; }
        public string MiddleName { get; set; }
        public Sex Sex { get; set; }

        private string _addressLineOne;

        public string AddressLineOne
        {
            get
            {
                return _addressLineOne;
            }
            set
            {
                _addressLineOne = value;
            }
        }

        private string _addressLineTwo;

        public string AddressLineTwo
        {
            get
            {
                return _addressLineTwo;
            }
            set
            {
                _addressLineTwo = value;
            }
        }

        private string _city;

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        private string _state;

        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        private string _postalCode;

        public string PostalCode
        {
            get
            {
                return _postalCode;
            }
            set
            {
                _postalCode = value;
            }
        }

        private string _country;

        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        private string _phone;

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

        private string _email;

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        private bool _sedentaty;

        public bool Sedentary
        {
            get
            {
                return _sedentaty;
            }
            set
            {
                _sedentaty = value;
            }
        }

        private string _med1Name;
        public string Med1Name
        {
            get
            {
                return _med1Name;
            }
            set
            {
                _med1Name = value;
            }
        }

        private string _med1Dosage;
        public string Med1Dosage
        {
            get
            {
                return _med1Dosage;
            }
            set
            {
                _med1Dosage = value;
            }
        }

        private byte[] _image;

        public byte[] Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }
        public List<Medication> MedicationRx { get; set; }


    }

    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        [Required]
        public Patient Patient { get; set; }
    }

}

