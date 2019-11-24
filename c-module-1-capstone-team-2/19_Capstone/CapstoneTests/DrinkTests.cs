using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
       [TestClass]
        public class DrinkTests
        {
            [TestMethod]
            public void DrinksTest_Created_Corrrectly()
            {
                Capstone.Classes.Products drink = new Products("Heavy", 1.50M, "Drink", "C4", 5);
                Assert.AreEqual("Heavy", drink.ProductName);
                Assert.AreEqual("Drink", drink.Type);
                Assert.AreEqual("C4", drink.SlotLocation);
                Assert.AreEqual(1.50M, drink.Price);
                Assert.AreEqual(5, drink.Quantity);

            
        }
    }
}
