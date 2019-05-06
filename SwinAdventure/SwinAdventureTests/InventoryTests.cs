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
    public class InventoryTests
    {
        Item i1;
        Item i2;
        Item i3;

        Inventory invent;

        [TestInitialize]
        public void Initialize()
        {
            i1 = new Item(new string[] { "Sword" }, "Bronze Sword", "A grand bronze sword from years ago");
            i2 = new Item(new string[] { "Shield" }, "Wooden Shield", "A mighty wooden shield from the Stone age.");
            i3 = new Item(new string[] { "Cape" }, "Counts Cape", "A fabulously flowing cape!");
            invent = new Inventory();
            invent.Put(i1);
            invent.Put(i2);
        }

        [TestMethod]
        public void HasItemTest()
        {
            Assert.IsTrue(invent.HasItem("sword"));
        }
        [TestMethod]
        public void NotHasItemTest()
        {
            Assert.IsFalse(invent.HasItem("cape"));
        }

        [TestMethod]
        public void FetchTest()
        {
            Assert.AreSame(invent.Fetch("sword"), i1);
        }

        [TestMethod]
        public void PutTest()
        {
            invent.Put(i3);
            Assert.IsTrue(invent.HasItem("Cape"));
        }

        [TestMethod]
        public void TakeTest()
        {
            Assert.AreSame(invent.Take("sword"), i1);
            Assert.IsFalse(invent.HasItem("sword"));
        }
    }
}