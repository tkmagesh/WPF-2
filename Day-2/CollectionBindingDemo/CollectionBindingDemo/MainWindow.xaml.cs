using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollectionBindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Employee> employees;

        public MainWindow()
        {
            InitializeComponent();
            employees = new ObservableCollection<Employee>()
                {
                    new Employee(){Id=11, FirstName = "Magesh", LastName = "Kuppan", Salary = 10000, CompanyId = 102},
                    new Employee(){Id=12, FirstName = "Suresh", LastName = "Kannan", Salary = 20000, CompanyId = 101 },
                    new Employee(){Id=13, FirstName = "Rajesh", LastName = "Pandit", Salary = 30000, CompanyId = 102},
                    new Employee(){Id=14, FirstName = "Ramesh", LastName = "Jayaram", Salary = 40000, CompanyId = 101}
                };
            this.DataContext = employees;
        }

        private void BtnAddNewEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            employees.Add(new Employee(){Id = 15, FirstName = "Ganesh", LastName = "Easwar", Salary = 50000, CompanyId = 102});
            MessageBox.Show("Current employee count = " + employees.Count);
        }

        private void BtnRemoveSelectedEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            employees.Remove((Employee) LstEmployees.SelectedItem);
        }
    }
}
