using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class GumTests
    {
        [TestMethod]
        public void GumTest_Created_Corrrectly()
        {
            Capstone.Classes.Products gum = new Products("Triplemint", 0.75M, "Gum", "D4", 5);
            Assert.AreEqual("Triplemint", gum.ProductName);
            Assert.AreEqual("Gum", gum.Type);
            Assert.AreEqual("D4", gum.SlotLocation);
            Assert.AreEqual(0.75M, gum.Price);
            Assert.AreEqual(5, gum.Quantity);

        }
    }
}
