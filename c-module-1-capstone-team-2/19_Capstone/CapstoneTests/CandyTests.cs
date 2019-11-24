using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class CandyTests
    {
        [TestMethod]
        public void CandyTest_Created_Corrrectly()
        {
            Capstone.Classes.Products candy = new Products("Moonpie", 1.80M, "Candy", "B1", 5);
            Assert.AreEqual("Moonpie", candy.ProductName);
            Assert.AreEqual("Candy", candy.Type);
            Assert.AreEqual("B1", candy.SlotLocation);
            Assert.AreEqual(1.80M, candy.Price);
            Assert.AreEqual(5, candy.Quantity);

        }
    }
}
