using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CapstoneTests
{
    [TestClass]

    public class MainMenuTests
    {

        [TestMethod]
        public void ReturnSoldOutTestWith5()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            MainMenu mm = new MainMenu(vm);
            Products Cola = new Products("Cola", 1.25M, "Drink", "C1", 5);
            //act
            string actualResult = mm.ReturnSoldOut(Cola);
            //assert
            Assert.AreEqual("5", actualResult);
        }

        [TestMethod]
        public void ReturnSoldOutTestSoldOut()
        {
            //arrange
            VendingMachine vm = new VendingMachine();
            MainMenu mm = new MainMenu(vm);
            Products Heavy = new Products("Heavy", 1.50M, "Drink", "C4", 0);
            //act
            string actualResult = mm.ReturnSoldOut(Heavy);
            //assert
            Assert.AreEqual("Sold Out!", actualResult);
        }

    }
}
