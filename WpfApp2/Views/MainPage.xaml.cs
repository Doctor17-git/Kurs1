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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        private readonly string _role;
        private readonly JsonDatabase _db;
        private List<CartItem> _cart = new List<CartItem>();
        private List<Product> _allProducts = new List<Product>();
        public MainPage(string role)
        {
            InitializeComponent();
            _db = new JsonDatabase("../../Data/products.json");
            _role = role;
            InitializeUI();
            LoadProducts();
            LoadCategories();
        }

        private void InitializeUI()
        {
            if (_role == "admin")
            {
                WelcomeText.Text = "Панель администратора";
                AdminEditUsersButton.Visibility = Visibility.Visible;
            }
            else if (_role == "seller")
            {
                WelcomeText.Text = "Панель продавца";
                SellerAddProductButton.Visibility = Visibility.Visible;
            }
            else if ( _role == "user")
            {
                WelcomeText.Text = "Панель пользователя";
                OpenCartButton.Visibility = Visibility.Visible;
            }
        }

        private void LoadProducts()
        {
            _allProducts = _db.LoadData<Product>();

            foreach (var product in _allProducts)
            {
                if (_role == "seller")
                    product.EditButtonVisibility = "Visible";
                else if (_role == "user")
                    product.AddToCartButtonVisibility = "Visible";
            }
            
            ProductListView.ItemsSource = _allProducts;
        }

        private void LoadCategories()
        {
            var categories = _allProducts.Select(p => p.Category).Distinct().ToList();
            categories.Insert(0, ""); // Добавляем пустую категорию для "Все категории"
            CategoryComboBox.ItemsSource = categories;
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            // Получаем значения фильтров
            string searchQuery = SearchTextBox.Text.Trim().ToLower();
            string selectedCategory = CategoryComboBox.SelectedItem as string;
            decimal.TryParse(MinPriceTextBox.Text, out decimal minPrice);
            decimal.TryParse(MaxPriceTextBox.Text, out decimal maxPrice);

            // Применяем фильтры
            var filteredProducts = _allProducts.Where(p =>
                (string.IsNullOrEmpty(searchQuery) || p.Name.ToLower().Contains(searchQuery)) &&
                (string.IsNullOrEmpty(selectedCategory) || p.Category == selectedCategory) &&
                (minPrice == 0 || p.Price >= minPrice) &&
                (maxPrice == 0 || p.Price <= maxPrice)
            ).ToList();

            // Обновляем список на экране
            ProductListView.ItemsSource = filteredProducts;
        }

        private void ResetFilters_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = string.Empty;
            CategoryComboBox.SelectedIndex = -1;
            MinPriceTextBox.Text = string.Empty;
            MaxPriceTextBox.Text = string.Empty;

            ProductListView.ItemsSource = _allProducts; // Восстанавливаем полный список
        }

        private void EditUsers_Click(object sender, RoutedEventArgs e)
        {
            var editUsersPage = new EditUsersPage();
            editUsersPage.ShowDialog();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var addProductPage = new AddProductPage();
            addProductPage.ShowDialog();
            LoadProducts(); // Обновить список товаров после добавления
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button)?.CommandParameter as Product;

            if (product != null)
            {
                var editProductPage = new EditProductPage(product);

                if (editProductPage.ShowDialog() == true)
                {
                    var products = _db.LoadData<Product>();

                    // Ищем товар по Id
                    var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);

                    if (existingProduct != null)
                    {
                        existingProduct.Name = product.Name;
                        existingProduct.Price = product.Price;
                        existingProduct.Category = product.Category;
                    }

                    _db.SaveData(products); // Сохраняем изменения в файл
                    LoadProducts(); // Обновляем список на экране
                }
            }
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button)?.CommandParameter as Product;

            if (product != null)
            {
                var existingItem = _cart.FirstOrDefault(item => item.ProductId == product.Id);

                if (existingItem != null)
                {
                    existingItem.Quantity++; // Увеличиваем количество, если товар уже в корзине
                }
                else
                {
                    _cart.Add(new CartItem
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        Price = product.Price,
                        Quantity = 1
                    });
                }

                MessageBox.Show($"Товар \"{product.Name}\" добавлен в корзину.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void OpenCart_Click(object sender, RoutedEventArgs e)
        {
            var cartPage = new CartPage(_cart);
            cartPage.ShowDialog();
        }
    }
}
