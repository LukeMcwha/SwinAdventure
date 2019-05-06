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
    public class ItemTests
    {
        Item i1;
        Item i2;
        Item i3;

        [TestInitialize]
        public void Initialize()
        {
            i1 = new Item(new string[] { "Sword" }, "Bronze Sword", "A grand bronze sword from years ago");
            i2 = new Item(new string[] { "Shield" }, "Wooden Shield", "A mighty wooden shield from the Stone age.");
            i3 = new Item(new string[] { "Cape" }, "Counts Cape", "A fabulously flowing cape!");
        }
        [TestMethod()]
        public void ItemTest()
        {
            Assert.IsTrue(i1.AreYou("sword"));
        }

        [TestMethod]
        public void ShortDescription()
        {
            Assert.AreEqual(i1.ShortDescription, "a bronze sword (sword)");
        }

        [TestMethod]
        public void LongDescription()
        {
            Assert.AreEqual(i1.LongDescription, "A grand bronze sword from years ago");
        }
    }
}