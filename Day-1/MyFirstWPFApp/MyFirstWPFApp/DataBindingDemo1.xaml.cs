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
    /// Interaction logic for DataBindingDemo1.xaml
    /// </summary>
    public partial class DataBindingDemo1 : Window
    {
        public DataBindingDemo1()
        {
            InitializeComponent();
        }

        private void SliderTest_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.TbSliderValue.Text = e.NewValue.ToString();
        }
    }
}
