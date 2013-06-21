using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelProgrammingDemo
{
    public class CompanyEmployees : INotifyPropertyChanged
    {
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Company> _companies;
        private int _selectedCompanyId;
        private Employee _selectedEmployee;
        private IEnumerable<Employee> _listEmployees;
        private string _status;
        public event PropertyChangedEventHandler PropertyChanged;

        
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
            var fetchEmployeestask = new Task<ObservableCollection<Employee>>(DataAccessUtils.GetAllEmployees);
            fetchEmployeestask.ContinueWith(t =>
                {
                    Employees = t.Result;
                    ListEmployees = Employees;
                });
            fetchEmployeestask.Start();

            //Employees = DataAccessUtils.GetAllEmployees();
            var fetchCompaniestask = new Task<ObservableCollection<Company>>(DataAccessUtils.GetAllCompanies);
            fetchCompaniestask.ContinueWith(t =>
                {
                        fetchEmployeestask.Wait();
                        Companies = t.Result;
                        DisplayCompleted();
                    });
            
            fetchCompaniestask.Start();
            DisplayLoading();
            

        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        private void DisplayCompleted()
        {
            Status = "Loaded";
        }

        private void DisplayLoading()
        {
            Status = "Loading";
        }
    }
}
