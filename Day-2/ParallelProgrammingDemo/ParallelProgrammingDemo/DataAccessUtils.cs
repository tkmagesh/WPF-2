using System.Collections.ObjectModel;
using System.Threading;

namespace ParallelProgrammingDemo
{
    public static class DataAccessUtils
    {
        public static ObservableCollection<Employee> GetAllEmployees()
        {
            Thread.Sleep(10000);
            return new ObservableCollection<Employee>()
                {
                    new Employee(){Id=11, FirstName = "Magesh", LastName = "Kuppan", Salary = 10000, CompanyId = 102},
                    new Employee(){Id=12, FirstName = "Suresh", LastName = "Kannan", Salary = 20000, CompanyId = 101 },
                    new Employee(){Id=13, FirstName = "Rajesh", LastName = "Pandit", Salary = 30000, CompanyId = 102},
                    new Employee(){Id=14, FirstName = "Ramesh", LastName = "Jayaram", Salary = 40000, CompanyId = 101}
                };
        }

        public static ObservableCollection<Company> GetAllCompanies()
        {
            Thread.Sleep(5000);
            return new ObservableCollection<Company>()
                {
                    new Company(){Id = -1, Name = "All"},
                    new Company(){Id = 101, Name = "Schneider"},
                    new Company(){Id = 102, Name = "APC"}
                };
        }
    }
}