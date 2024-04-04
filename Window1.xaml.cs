using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5Ларионова1
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
        private void switch_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;
            var password = PasswordBox.Text;

            var context = new AppDbContext();

            var user = context.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (user == null)
            {
                MessageBox.Show("Такой пользователь уже в клубе крутяшек!");
                return;
            }
            MessageBox.Show("Вы успешно вошли в аккаунт!");

        }
        private void login_click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;
            var password = PasswordBox.Text;
            var context = new AppDbContext();
            var user = context.Users.SingleOrDefault(x => x.Login == login && x.Password == password);

            if (user == null)
            {
                result_text.Text = "Такой пользователь уже в клубе крутяшек!";
                return;
            }
            var Login = new User { Login = login, Password = password };
            context.Users.Add(Login);
            context.SaveChanges();
            MessageBox.Show("Welcome to the club");
        }
    }
}
