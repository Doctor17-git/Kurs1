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
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Window
    {
        private readonly JsonDatabase _db;
        public AddProductPage()
        {
            InitializeComponent();
            _db = new JsonDatabase("../../Data/products.json");
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            // Валидация ввода
            string name = ProductNameTextBox.Text.Trim();
            string priceText = ProductPriceTextBox.Text.Trim();
            string category = ProductCategoryTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(priceText) || string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price) || price <= 0)
            {
                MessageBox.Show("Цена должна быть положительным числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Добавление товара
            var newProduct = new Product
            {
                Name = name,
                Price = price,
                Category = category
            };

            var products = _db.LoadData<Product>();
            products.Add(newProduct);
            _db.SaveData(products);

            MessageBox.Show("Товар успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
