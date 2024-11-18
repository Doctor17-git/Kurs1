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
using System.Windows.Shapes;
using System.Security.Cryptography;
using WpfApp2.Models;

namespace WpfApp2.Views
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public User EditedUser { get; private set; }
        public EditUserWindow(User user = null)
        {
            InitializeComponent();
            
            if (user != null)
            {
                EditedUser = user;
                UsernameTextBox.Text = user.Username;
                RoleComboBox.SelectedItem = user.Role;
            }
            else
            {
                EditedUser = new User();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем ввод
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) || string.IsNullOrWhiteSpace(RoleComboBox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Сохраняем данные
            EditedUser.Username = UsernameTextBox.Text.Trim();
            EditedUser.Role = RoleComboBox.Text;

            // Хешируем пароль, если он был введён
            if (!string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                using (var sha256 = SHA256.Create())
                {
                    EditedUser.PasswordHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(PasswordBox.Password)));
                }
            }

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
