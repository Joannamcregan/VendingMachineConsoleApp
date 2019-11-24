using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class ChipsTests
    {
        [TestMethod]
        public void ChipsTest_Created_Corrrectly()
        {
            Products chips = new Products("Potato Crisps", 3.05M, "Chips", "A1", 5);
            Assert.AreEqual("Potato Crisps", chips.ProductName);
            Assert.AreEqual("Chips", chips.Type);
            Assert.AreEqual("A1", chips.SlotLocation);
            Assert.AreEqual(3.05M, chips.Price);
            Assert.AreEqual(5, chips.Quantity);

        }
    }
}
