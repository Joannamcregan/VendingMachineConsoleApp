using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class MainMenu
    {

        protected VendingMachine vendingMachine;

        //MainMenu Contructor
        public MainMenu(VendingMachine vm)
        {
            this.vendingMachine = vm;
        }
        
        // Main Menu Display
        public void DisplayMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*** Main Menu ***");
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Exit");
                Console.WriteLine("Please make a selection (1), (2), (3).");
                string input = Console.ReadLine();

                if (input == "1" || input == "one" || input == "(1)")
                {
                    List<Products> productsToPrint = vendingMachine.ListOfProducts(vendingMachine.inventory);

                    DisplayVendingMachineItems(productsToPrint);
                    Console.ReadLine();
                }
                else if (input == "2" || input == "two" || input == "(2)")
                {
                    PurchasingMenu pm = new PurchasingMenu(vendingMachine);
                    pm.DisplayPurchasingMenu();
                }
                else if (input == "3" || input == "three" || input == "(3)")
                {
                    Environment.Exit(0);
                }
            }
        }

        //Prints out a list of available products
        public void DisplayVendingMachineItems(List<Products> productsToPrint)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"{"Slot Location", -30}{"Product Name", -20}{"$Item Price", 10}{"Type of Item", 20}{"Quantity Remaining", 35}");
            Console.WriteLine("___________________________________________________________________________________________________________________");
            foreach (Products item in productsToPrint)
            {
                Console.WriteLine($"{item.SlotLocation, -30} {item.ProductName, -20} {item.Price, 10:c} {item.Type, 20} {ReturnSoldOut(item), 30}");
            }
        }

        //Displays if quantity is sold out
        public string ReturnSoldOut (Products item)
        {
            if (item.Quantity > 0)
            {
                return item.Quantity.ToString();
            }
            else
            {
                return "Sold Out!";
            }
        }
    }
}
