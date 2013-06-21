using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CollectionBindingDemo.Annotations;

namespace CollectionBindingDemo
{
    public class CompanyEmployees : INotifyPropertyChanged
    {
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Company> _companies;
        private int _selectedCompanyId;
        private Employee _selectedEmployee;
        private IEnumerable<Employee> _listEmployees;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                if (Equals(value, _employees)) return;
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public IEnumerable<Employee> ListEmployees
        {
            get { return _listEmployees; }
            set
            {
                if (Equals(value, _listEmployees)) return;
                _listEmployees = value;
                OnPropertyChanged("ListEmployees");
            }
        }

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                if (Equals(value, _selectedEmployee)) return;
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        public int SelectedCompanyId
        {
            get { return _selectedCompanyId; }
            set
            {
                if (value == _selectedCompanyId) return;
                _selectedCompanyId = value;

                ListEmployees = value == -1? Employees :  Employees.Where(e => e.CompanyId == value);
                OnPropertyChanged("SelectedCompanyId");
            }
        }

        public ObservableCollection<Company> Companies
        {
            get { return _companies; }
            set
            {
                if (Equals(value, _companies)) return;
                _companies = value;
                OnPropertyChanged("Companies");
            }
        }

        public CompanyEmployees()
        {
            Employees = new ObservableCollection<Employee>()
                {
                    new Employee(){Id=11, FirstName = "Magesh", LastName = "Kuppan", Salary = 10000, CompanyId = 102},
                    new Employee(){Id=12, FirstName = "Suresh", LastName = "Kannan", Salary = 20000, CompanyId = 101 },
                    new Employee(){Id=13, FirstName = "Rajesh", LastName = "Pandit", Salary = 30000, CompanyId = 102},
                    new Employee(){Id=14, FirstName = "Ramesh", LastName = "Jayaram", Salary = 40000, CompanyId = 101}
                };
            Companies = new ObservableCollection<Company>()
                {
                    new Company(){Id = -1, Name = "All"},
                    new Company(){Id = 101, Name = "Schneider"},
                    new Company(){Id = 102, Name = "APC"}
                };
            ListEmployees = Employees;
        }
    }
}
