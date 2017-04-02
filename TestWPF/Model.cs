using System;

namespace PatientMVVM.Models
{
    public class TestData
    {
        static private string _data = "data binding";

        static public string Data
        {
            get { return _data; }
            set
            {
                _data = value;
            }
        }
    }
 
}
