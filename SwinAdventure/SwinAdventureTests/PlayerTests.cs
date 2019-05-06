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
    public class PlayerTests
    {

        Player p;
        Item i1;
        Item i2;

        [TestInitialize]
        public void Initialize()
        {
            p = new Player("Jeff", "I am a legend");
            i1 = new Item(new string[] { "Sword" }, "Bronze Sword", "A grand bronze sword from years ago");
            i2 = new Item(new string[] { "Shield" }, "Wooden Shield", "A mighty wooden shield from the Stone age.");
            p.Inventory.Put(i1);
        }

        [TestMethod()]
        public void PlayerAreYouTest()
        {
            Assert.IsTrue(p.AreYou("me"));
            Assert.IsTrue(p.AreYou("inventory"));
        }

        [TestMethod()]
        public void LocateTest()
        {
            Assert.AreSame(i1, p.Locate("sword"));
        }
        [TestMethod]
        public void LocateSelfTest()
        {
            Assert.AreSame(p, p.Locate("me"));
            Assert.AreSame(p, p.Locate("inventory"));
        }

        [TestMethod]
        public void LocateNothingTest()
        {
            Assert.IsNull(p.Locate("Nothing"));
        }
    }
}