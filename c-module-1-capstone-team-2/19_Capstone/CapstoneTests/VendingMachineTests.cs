using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void MoneyDepositedTestInput1()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            //act
            decimal actualResult = vm.MoneyDeposited("1");
            //assert
            Assert.AreEqual(1.00M, actualResult);
        }

        [TestMethod]
        public void MoneyDepositedTestInputTwo()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            //act
            decimal actualResult = vm.MoneyDeposited("Two");
            //assert
            Assert.AreEqual(2.00M, actualResult);
        }

        [TestMethod]
        public void MoneyDepositedTestInput5InParens()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            //act
            decimal actualResult = vm.MoneyDeposited("(5)");
            //assert
            Assert.AreEqual(5.00M, actualResult);
        }

        [TestMethod]
        public void MoneyDepositedTestInputTEN()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            //act
            decimal actualResult = vm.MoneyDeposited("TEN");
            //assert
            Assert.AreEqual(10.00M, actualResult);
        }

        [TestMethod]
        public void MoneyDepositedTestInputB()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            //act
            decimal actualResult = vm.MoneyDeposited("B");
            //assert
            Assert.AreEqual(0.00M, actualResult);
        }

        [TestMethod]
        public void MoneyDepositedTestInputNegative()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            //act
            decimal actualResult = vm.MoneyDeposited("-1");
            //assert
            Assert.AreEqual(0.00M, actualResult);
        }

        [TestMethod]
        public void MoneyDepositedTestInputLetter()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            //act
            decimal actualResult = vm.MoneyDeposited("K");
            //assert
            Assert.AreEqual(0.00M, actualResult);
        }

        [TestMethod]
        public void EnsureProperInputTest1()
        {
            VendingMachine vm = new VendingMachine();
            decimal actualResult = vm.EnsureProperInput("1");
            Assert.AreEqual(1.00M, actualResult);
        }

        [TestMethod]
        public void Current_Balance_Test_Result_5()
        {
            //Arrange
            VendingMachine vm = new VendingMachine();
            Products crunchie = new Products("Crunchie", 1.75M, "Candy", "B4", 5);
            Dictionary<string, Products> sampleDictionary = new Dictionary<string, Products>() { };
            sampleDictionary.Add("B4", crunchie);

            //Act
            vm.MoneyDeposited("5");

            //Assert
            Assert.AreEqual(5, vm.CurrentBalance());
        }

        [TestMethod]
        public void Current_Balance_Test_Result_10()
        {
            //Arrange
            VendingMachine vm = new VendingMachine();
            Products crunchie = new Products("Crunchie", 1.75M, "Candy", "B4", 5);
            Dictionary<string, Products> sampleDictionary = new Dictionary<string, Products>() { };
            sampleDictionary.Add("B4", crunchie);

            //Act
            vm.MoneyDeposited("10");

            //Assert
            Assert.AreEqual(10, vm.CurrentBalance());
        }

        [TestMethod]
        public void Finish_Transaction_Test_20_Quarters_Change_Bank()
        {
            //Arrange
            VendingMachine vm = new VendingMachine();
            Products crunchie = new Products("Crunchie", 1.75M, "Candy", "B4", 5);
            Dictionary<string, Products> sampleDictionary = new Dictionary<string, Products>() { };
            sampleDictionary.Add("B4", crunchie);

            //Act
            vm.MoneyDeposited("5");

            //Assert
            Assert.AreEqual("Your change is $5.00. 20 quarter(s), 0 dime(s), 0 nickel(s)).", vm.FinishTransaction());
        }

        [TestMethod]
        public void Finish_Transaction_Test_13_Quarters_Back()
        {
            //Arrange
            VendingMachine vm = new VendingMachine();
            Products crunchie = new Products("Crunchie", 1.75M, "Candy", "B4", 5);
            Dictionary<string, Products> inventory = new Dictionary<string, Products>() { };
            inventory.Add("B4", crunchie);

            List<Products> crunchieAddedToList = new List<Products>();
            foreach (KeyValuePair<string, Products> kvp in inventory)
            {
                crunchieAddedToList.Add(kvp.Value);
            }

            //Act
            vm.MoneyDeposited("5");
            vm.ProductSelection("B4", inventory);

            //Assert
            Assert.AreEqual("Your change is $3.25. 13 quarter(s), 0 dime(s), 0 nickel(s)).", vm.FinishTransaction());
        }

        [TestMethod]
        public void ListOfProducts_Dictionary_Value_Added_To_List()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            Products Cola = new Products("Cola", 1.25M, "Drink", "C1", 5);
            Dictionary<string, Products> inventory = new Dictionary<string, Products>();
            inventory["C1"] = Cola;

            //act
            List<Products> testList = new List<Products>();
            foreach (KeyValuePair<string, Products> kvp in inventory)
            {
                testList.Add(kvp.Value);
            }

            //assert
            CollectionAssert.AreEquivalent(testList, vm.ListOfProducts(inventory));
        }

        [TestMethod]
        public void ProductSelection_Test_Invalid_Selection_Message()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            Products Cola = new Products("Cola", 1.25M, "Drink", "C1", 5);
            Dictionary<string, Products> inventory = new Dictionary<string, Products>();
            inventory["C1"] = Cola;

            //act
            vm.MoneyDeposited("5");
            string actualResult = vm.ProductSelection("B9", inventory);

            //assert
            Assert.AreEqual("Invalid slot location. Returning to Purchasing Menu.", actualResult);
        }

        [TestMethod]
        public void ProductSelection_Test_Please_Enter_More_Money_Message()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            Products Cola = new Products("Cola", 1.25M, "Drink", "C1", 5);
            Dictionary<string, Products> inventory = new Dictionary<string, Products>();
            inventory["C1"] = Cola;

            //act
            string actualResult = vm.ProductSelection("C1", inventory);

            //assert
            Assert.AreEqual("Please enter more money. Returning to Purchasing Menu.", actualResult);
        }

        [TestMethod]
        public void ProductionSelection_Test_Sorry_Sold_Out_Message()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            Products Cola = new Products("Cola", 1.25M, "Drink", "C1", 0);
            Dictionary<string, Products> inventory = new Dictionary<string, Products>();
            inventory["C1"] = Cola;

            //act
            string actualResult = vm.ProductSelection("C1", inventory);
            vm.MoneyDeposited("2");

            //assert
            Assert.AreEqual("Sorry! That's sold out! Returning to Purchasing Menu.", actualResult);
        }

        [TestMethod]
        public void ProductSelection_Drink_Glug_Glug_Yum_Message()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            Products Cola = new Products("Cola", 1.25M, "Drink", "C1", 5);
            Dictionary<string, Products> inventory = new Dictionary<string, Products>();
            inventory["C1"] = Cola;

            //act
            vm.MoneyDeposited("2");
            string actualResult = vm.ProductSelection("C1", inventory);

            //assert
            Assert.AreEqual("Glug! Glug! Yum!", actualResult);
        }

        [TestMethod]
        public void ProductSelection_Current_Balance_Decreased_To_75_Cents()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            Products Cola = new Products("Cola", 1.25M, "Drink", "C1", 5);
            Dictionary<string, Products> inventory = new Dictionary<string, Products>();
            inventory["C1"] = Cola;

            //act
            vm.MoneyDeposited("2");
            vm.ProductSelection("C1", inventory);
            decimal actualResult = vm.CurrentBalance();

            //assert
            Assert.AreEqual(0.75M, actualResult);
        }

        [TestMethod]
        public void ProductSelection_Quantity_Decreased_to_4()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            Products Cola = new Products("Cola", 1.25M, "Drink", "C1", 5);
            Dictionary<string, Products> inventory = new Dictionary<string, Products>();
            inventory["C1"] = Cola;

            //act
            vm.MoneyDeposited("2");
            vm.ProductSelection("C1", inventory);
            int actualResult = inventory["C1"].Quantity;

            //assert
            Assert.AreEqual(4, actualResult);
        }
    }
}
