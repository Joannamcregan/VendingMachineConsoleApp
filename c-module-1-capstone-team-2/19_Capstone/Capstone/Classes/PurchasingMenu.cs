using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    class PurchasingMenu : MainMenu
    {

        public PurchasingMenu(VendingMachine vm) : base(vm)
        {

        }

        //Displays Purchasing Menu
        public void DisplayPurchasingMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*** Purchasing Menu ***");
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine("(B) Go Back");
                Console.WriteLine("Please make a selection (1), (2), (3) or (B)");
                Console.WriteLine("");
                Console.WriteLine($"Current Money Provided: {vendingMachine.CurrentBalance():C}");
                string input = Console.ReadLine().ToLower();

                if (input == "1" || input == "one" || input == "ONE" || input == "One" || input == "(1)")
                {
                    DisplayFeedMoneyMenu();
                }

                else if (input == "2" || input == "two" || input == "(2)")

                {
                    SelectProduct();
                }

                else if (input == "3" || input == "three" || input == "THREE" || input == "Three" || input == "(3)")
                {
                    Console.WriteLine(vendingMachine.FinishTransaction());
                    Console.ReadLine();
                    DisplayMainMenu();
                }

                else if (input == "b" || input == "B")

                {
                    DisplayMainMenu();
                }
            }
        }

        //FEED MONEY Menu
        public void DisplayFeedMoneyMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*** Feed Me Money! ***");
                Console.WriteLine("(1)  One Dollar");
                Console.WriteLine("(2)  Two Dollars");
                Console.WriteLine("(5)  Five Dollars");
                Console.WriteLine("(10) Ten Dollars");
                Console.WriteLine("(B)  Go Back");
                Console.WriteLine("Please make a selection (1), (2), (5), (10).");
                Console.WriteLine("");
                Console.WriteLine($"Current Money Provided: {vendingMachine.CurrentBalance():C}");
                string input = Console.ReadLine().ToLower();

                if (input == "b")
                {
                    DisplayPurchasingMenu();
                }
                else
                {
                    decimal moneyCounter = vendingMachine.MoneyDeposited(input);
                }

            }
        }

        //Product Selection
        private void SelectProduct()
        {
            //Shows a list of products available for purchase
            List<Products> productsToPrint = vendingMachine.ListOfProducts(vendingMachine.inventory);

            MainMenu menu = new MainMenu(vendingMachine);
            DisplayVendingMachineItems(productsToPrint);
            Console.WriteLine("");

            //Ask user input
            Console.Write("Please input slot location of the product you want to purchase: ");
            string userInputSlotLocation = Console.ReadLine().ToUpper();

            if (userInputSlotLocation == "B")
            {
                DisplayMainMenu();
            }

            else if (userInputSlotLocation == "1" || userInputSlotLocation == "one" || userInputSlotLocation == "(1)")
            {
                DisplayFeedMoneyMenu();
            }

            else if (userInputSlotLocation == "3" || userInputSlotLocation == "three" || userInputSlotLocation == "(3)")
            {
                Console.WriteLine(vendingMachine.FinishTransaction());
                Console.ReadLine();
                DisplayMainMenu();
            }

            Console.WriteLine(vendingMachine.ProductSelection(userInputSlotLocation, vendingMachine.inventory));
            Console.ReadKey();
        }
    }
}
