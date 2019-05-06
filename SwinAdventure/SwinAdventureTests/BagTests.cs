using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure.Tests
{
    [TestClass()]
    public class BagTests
    {
        Bag b1, b2;
        Item i1, i2, i3;

        [TestInitialize]
        public void Initialize()
        {
            i1 = new Item(new string[] { "Sword" }, "Bronze Sword", "A grand bronze sword from years ago");
            i2 = new Item(new string[] { "Shield" }, "Wooden Shield", "A mighty wooden shield from the Stone age.");
            i3 = new Item(new string[] { "Cape" }, "Counts Cape", "A fabulously flowing cape!");

            b1 = new Bag(new string[] { "backpack" }, "backpack", "Small backpack");
            b2 = new Bag(new string[] { "wallet" }, "Wallet", "small wallet");

            b1.Inventory.Put(i1);
            b2.Inventory.Put(i2);
            b1.Inventory.Put(b2);
        }

        [TestMethod()]
        public void LocateItemsTest()
        {
            Assert.AreSame(i1, b1.Locate("sword"));
        }
        [TestMethod]
        public void LocateItselfTest()
        {
            Assert.AreSame(b1, b1.Locate("backpack"));
        }
        public void LocateNothingTest()
        {
            Assert.IsNull(b1.Locate("asdf"));
        }

        [TestMethod]
        public void LocateOtherBag()
        {
            Assert.AreSame(b2, b1.Locate("wallet"));
        }
    }
}