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
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Window
    {
        private readonly List<CartItem> _cart;
        public CartPage(List<CartItem> cart)
        {
            InitializeComponent();
            _cart = cart;

            // Добавляем свойство Total для отображения суммы по каждому товару
            foreach (var item in _cart)
            {
                item.Total = item.Quantity * item.Price;
            }

            CartListView.ItemsSource = _cart;
            UpdateTotalAmount();
        }

        private void UpdateTotalAmount()
        {
            decimal totalAmount = _cart.Sum(item => item.Total);
            TotalAmountTextBlock.Text = totalAmount.ToString("C2"); // Форматирование в виде валюты
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заказ оформлен!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            _cart.Clear(); // Очищаем корзину
            UpdateTotalAmount();
            CartListView.ItemsSource = null; // Обновляем список
            Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
