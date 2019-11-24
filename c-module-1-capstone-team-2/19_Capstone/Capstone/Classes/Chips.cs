using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    class Chips : Products
    {
        public Chips(string name, decimal price, string type, string slotLocation, int quantity) : base(name, price, type, slotLocation, quantity)
        {

        }
    }
}
