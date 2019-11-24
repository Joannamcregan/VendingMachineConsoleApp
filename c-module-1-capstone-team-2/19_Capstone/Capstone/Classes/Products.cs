using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Products
    {
        public string SlotLocation { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        public Products(string name, decimal price, string type, string slotLocation, int quantity)
        {
            this.ProductName = name;
            this.Price = price;
            this.Type = type;
            this.Quantity = quantity;
            this.SlotLocation = slotLocation;
        }
    }
}
