using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    class Drink: Products
    {
        public Drink(string name, decimal price, string type, string slotLocation, int quantity) : base(name, price, type, slotLocation, quantity)
        {

        }
    }
}

