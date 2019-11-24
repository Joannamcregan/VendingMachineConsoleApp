using Capstone.Classes;
using System;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();
            
            vendingMachine.GetInventoryMethod(@"../../../../", "vendingmachine.csv");

            MainMenu variable = new MainMenu(vendingMachine);

            variable.DisplayMainMenu();
        }
    }
}
