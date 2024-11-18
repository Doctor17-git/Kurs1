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
using WpfApp2.Models;
using WpfApp2.Services;
using WpfApp2.Views;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly JsonDatabase _db;
        public MainWindow()
        {
            InitializeComponent();
            _db = new JsonDatabase("../../Data/users.json");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;

            var users = _db.LoadData<User>();
            var user = users.FirstOrDefault(u => u.Username == username);

            if (user != null && PasswordHasher.VerifyPassword(password, user.PasswordHash))
            {
                var mainPage = new MainPage(user.Role);
                mainPage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверное имя или пароль!");
            }
        }
    }
}
