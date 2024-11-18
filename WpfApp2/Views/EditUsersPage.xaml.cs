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
using WpfApp2.Models;
using WpfApp2.Services;

namespace WpfApp2.Views
{
    /// <summary>
    /// Логика взаимодействия для EditUsersPage.xaml
    /// </summary>
    public partial class EditUsersPage : Window
    {
        private readonly JsonDatabase _db;
        private List<User> _users;
        public EditUsersPage()
        {
            InitializeComponent();
            _db = new JsonDatabase("../../Data/users.json");
            LoadUsers();
        }

        private void LoadUsers()
        {
            _users = _db.LoadData<User>();
            UsersListView.ItemsSource = _users;
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var user = (sender as Button)?.CommandParameter as User;
            if (user != null)
            {
                var confirm = MessageBox.Show($"Вы уверены, что хотите удалить пользователя {user.Username}?", "Удаление пользователя", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes)
                {
                    _users.Remove(user);
                    _db.SaveData(_users);
                    LoadUsers();
                }
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            var editUserWindow = new EditUserWindow();
            if (editUserWindow.ShowDialog() == true)
            {
                var newUser = editUserWindow.EditedUser;
                var users = _db.LoadData<User>();
                users.Add(newUser);
                _db.SaveData(users);
                LoadUsers(); // Обновляем отображение
            }
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UsersListView.SelectedItem as User;
            if (selectedUser == null)
            {
                MessageBox.Show("Выберите пользователя для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var editUserWindow = new EditUserWindow(selectedUser);
            if (editUserWindow.ShowDialog() == true)
            {
                var updatedUser = editUserWindow.EditedUser;
                var users = _db.LoadData<User>();

                var existingUser = users.FirstOrDefault(u => u.Id == updatedUser.Id);
                if (existingUser != null)
                {
                    existingUser.Username = updatedUser.Username;
                    existingUser.PasswordHash = updatedUser.PasswordHash;
                    existingUser.Role = updatedUser.Role;
                }

                _db.SaveData(users);
                LoadUsers(); // Обновляем отображение
            }
        }
    }
}
