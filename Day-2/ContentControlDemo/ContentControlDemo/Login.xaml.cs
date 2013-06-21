using System.Windows;
using System.Windows.Media;

namespace ContentControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
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
