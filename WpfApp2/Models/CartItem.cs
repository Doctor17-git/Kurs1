using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class CartItem
    {
        public Guid ProductId { get; set; }  // Ссылка на товар
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;  // Количество товара
        public decimal Total { get; internal set; }
    }
}
