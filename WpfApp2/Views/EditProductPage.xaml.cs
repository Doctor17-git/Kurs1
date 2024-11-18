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

namespace WpfApp2.Views
{
    /// <summary>
    /// Логика взаимодействия для EditProductPage.xaml
    /// </summary>
    public partial class EditProductPage : Window
    {
        public Product EditedProduct { get; private set; }
        public EditProductPage(Product product)
        {
            InitializeComponent();
            ProductNameTextBox.Text = product.Name;
            ProductPriceTextBox.Text = product.Price.ToString();
            ProductCategoryTextBox.Text = product.Category;

            EditedProduct = product;
        }

        private void SaveProduct_Click(object sender, RoutedEventArgs e)
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

            // Сохраняем изменения
            EditedProduct.Name = name;
            EditedProduct.Price = price;
            EditedProduct.Category = category;

            DialogResult = true; // Изменения подтверждены
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Отменяем изменения
            Close();
        }
    }
}
