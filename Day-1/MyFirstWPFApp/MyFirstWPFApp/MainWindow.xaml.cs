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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyFirstWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (this.TxtUsername.Text == this.PwdPassword.Password)
            {
                this.TbStatus.Text = "Login Successful!!";
                this.TbStatus.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                this.TbStatus.Text = "Login attempt failed!!!";
                this.TbStatus.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.TxtUsername.Text = this.PwdPassword.Password = string.Empty;
        }
    }
}
