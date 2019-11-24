using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Dictionary<string, Products> inventory = new Dictionary<string, Products>();

        private decimal moneyCounter = 0M;

        //Log transactions
        private void WriterToLog(string message)
        {
            using (StreamWriter sw = new StreamWriter(@"Log.txt", true))
            {
                sw.WriteLine(message);
            }
        }

        //Uploads inventory file into Dictionary where key is the slot location
        public void GetInventoryMethod(string directoryPath, string fileToRead)
        {
            //directoryPath is the new inputFile
            Directory.SetCurrentDirectory(directoryPath);

            string wholeDocument = File.ReadAllText(fileToRead).Trim();
            string[] eachLineArray = wholeDocument.Split("\r\n");
            for (int i = 0; i < eachLineArray.Length; i++)
            {
                string currentLine = eachLineArray[i];
                string[] currentLineArray = currentLine.Split("|");
                Products product = null;

                if (currentLineArray[3] == "Chip")
                {
                    product = new Chips(currentLineArray[1], Decimal.Parse(currentLineArray[2]), currentLineArray[3], currentLineArray[0], 5);
                }
                else if (currentLineArray[3] == "Candy")
                {
                    product = new Candy(currentLineArray[1], Decimal.Parse(currentLineArray[2]), currentLineArray[3], currentLineArray[0], 5);
                }

                else if (currentLineArray[3] == "Gum")
                {
                    product = new Gum(currentLineArray[1], Decimal.Parse(currentLineArray[2]), currentLineArray[3], currentLineArray[0], 5);
                }

                else if (currentLineArray[3] == "Drink")
                {
                    product = new Drink(currentLineArray[1], Decimal.Parse(currentLineArray[2]), currentLineArray[3], currentLineArray[0], 5);
                }

                inventory.Add(currentLineArray[0].ToString(), product);
            }
        }

        //created a list to hold dictionary keys and values
        public List<Products> ListOfProducts(Dictionary<string,Products> inventory)
        {
            List<Products> listOfProducts = new List<Products>();
            foreach (KeyValuePair<string, Products> kvp in inventory)
            {
                listOfProducts.Add(kvp.Value);
            }
            return listOfProducts;
        }

        //Keeps track of money that is deposited
        public decimal MoneyDeposited(string input)
        {
            if (input == "1" || input == "one" || input == "(1)")
            {
                input = "1";
                moneyCounter += 1;
            }
            else if (input == "2" || input == "two" || input == "TWO" || input == "Two" || input == "(2)" || input == "2.00")
            {
                input = "2";
                moneyCounter += 2;
            }
            else if (input == "5" || input == "five" || input == "FIVE" || input == "Five" || input == "(5)" || input == "5.00")
            {
                input = "5";
                moneyCounter += 5;
            }
            else if (input == "10" || input == "ten" || input == "TEN" || input == "Ten" || input == "(10)" || input == "10.00")
            {
                input = "10";
                moneyCounter += 10;
            }
            else if (input == "B" || input == "b" || input == "(B)" || input == "(b)")
            {
                input = "0";
                moneyCounter += 0;
            }
            else
            {
                input = "0";
                moneyCounter += 0;
            }

            WriterToLog($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")} FEED MONEY: {EnsureProperInput(input):C} {moneyCounter:C}");
            return moneyCounter; 
        }

        public decimal EnsureProperInput (string input)
        {
            if (input == "1" || input == "2" || input == "5" || input == "10" || input == "0")
            {
                return decimal.Parse(input);
            }
            else
            {
                return 0;
            }

        }

        //Dispenses products
        public string ProductSelection(string userInputSlotLocation, Dictionary<string, Products> inventory)
        {
            if (!inventory.ContainsKey(userInputSlotLocation))
            {
                return "Invalid slot location. Returning to Purchasing Menu.";
            }

            if (inventory.ContainsKey(userInputSlotLocation))
            {
                if (inventory[userInputSlotLocation].Quantity == 0)
                {
                    return "Sorry! That's sold out! Returning to Purchasing Menu.";
                }

                else if (moneyCounter < inventory[userInputSlotLocation].Price)
                {
                    return "Please enter more money. Returning to Purchasing Menu.";
                }

                else
                {
                    inventory[userInputSlotLocation].Quantity -= 1;

                    moneyCounter = moneyCounter - inventory[userInputSlotLocation].Price;
                    Console.WriteLine($"Dispensing {inventory[userInputSlotLocation].ProductName} which cost {inventory[userInputSlotLocation].Price:C} and your remaining balance is {moneyCounter:C}");
                    WriterToLog($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")} {inventory[userInputSlotLocation].ProductName}: {moneyCounter + inventory[userInputSlotLocation].Price:C} {moneyCounter:C}");

                    if (inventory[userInputSlotLocation].Type == "Chip")
                    {
                        return "Crunch! Crunch! Yum!";
                    }
                    else if (inventory[userInputSlotLocation].Type == "Candy")
                    {
                        return "Munch! Munch! Yum!";
                    }
                    else if (inventory[userInputSlotLocation].Type == "Drink")
                    {
                        return "Glug! Glug! Yum!";
                    }
                    else if (inventory[userInputSlotLocation].Type == "Gum")
                    {
                        return "Chew! Chew! Yum!";
                    }
                }
            }
            return "Returning to Purchasing Menu";
        }

        // Provides change and returns balance to 0
        public string FinishTransaction()
        {
            decimal previousBalance = moneyCounter;

            decimal changeBalance = moneyCounter * 100;
            int quarters = ((int)changeBalance / 25);
            int dimes = ((int)changeBalance - 25 * quarters) / 10;
            int nickels = ((int)changeBalance - 25 * quarters - 10 * dimes) / 5;

            WriterToLog($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")} GIVE CHANGE: {moneyCounter:C} {0:C}");
            moneyCounter = 0M;

            return $"Your change is {previousBalance:C}. {(int)(quarters)} quarter(s), {(int)dimes} dime(s), {(int)nickels} nickel(s)).";
        }

        public decimal CurrentBalance()
        {
            return moneyCounter;
        }
    }
}

