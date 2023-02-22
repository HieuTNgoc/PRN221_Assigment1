using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Product(int categoryId, string? productName, string? weight, decimal unitPrice, int unitStock)
        {
            CategoryId = categoryId;
            ProductName = productName;
            Weight = weight;
            UnitPrice = unitPrice;
            UnitStock = unitStock;
        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Weight { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int UnitStock { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
