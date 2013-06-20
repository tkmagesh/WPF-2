using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyFirstWPFApp
{
    /// <summary>
    /// Interaction logic for SimpleObjectBinding.xaml
    /// </summary>
    public partial class SimpleObjectBinding : Window
    {
        public SimpleObjectBinding()
        {
            InitializeComponent();
            /*var employee = new Employee() {Id = 101, Name = "Magesh"};
            TxtId.DataContext = employee;
            TxtName.DataContext = employee;
            TxtId.SetBinding(TextBox.TextProperty, new Binding("Id"));
            TxtName.SetBinding(TextBox.TextProperty, new Binding("Name"));*/
        }

        private void BtnDisplayNames_OnClick(object sender, RoutedEventArgs e)
        {
            var emp = (Employee) GridLayoutRoot.Resources["employee"];
            emp.FirstName = "Suresh";
            MessageBox.Show(string.Format("Id = {0}, Name={1}", emp.Id, emp.FirstName));
        }
    }

    
}
