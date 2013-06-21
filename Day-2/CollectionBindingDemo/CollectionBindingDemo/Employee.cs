using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CollectionBindingDemo.Annotations;

namespace CollectionBindingDemo
{
    public class Employee : INotifyPropertyChanged
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private decimal _salary;
        private int _companyId;

        public int CompanyId
        {
            get { return _companyId; }
            set
            {
                if (value == _companyId) return;
                _companyId = value;
                OnPropertyChanged("CompanyId");
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value == _lastName) return;
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value == _salary) return;
                _salary = value;
                OnPropertyChanged("Salary");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
