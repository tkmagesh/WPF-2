using System.ComponentModel;

namespace MyFirstWPFApp
{
    public class Employee : INotifyPropertyChanged
    {
        private int _id;
        private string _firstName;
        private string _lastName;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                TriggerPropertyChanged("FirstName");
                TriggerPropertyChanged("FullName");
            }
        }

        private void TriggerPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set { 
                _lastName = value; 
                TriggerPropertyChanged("LastName");
                TriggerPropertyChanged("FullName");
            }
        }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
    }
}