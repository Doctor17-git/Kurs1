using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string EditButtonVisibility { get; set; } = "Collapsed";
        public string AddToCartButtonVisibility { get; set; } = "Collapsed";
    }
}
