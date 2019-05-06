using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SwinAdventure.Tests
{
    [TestClass]
    public class LookCommandTests
    {
        Bag b1, b2;
        Item i1, i2, i3;
        Player p;
        LookCommand lookCommand;

        [TestInitialize]
        public void Initialize()
        {
            i1 = new Item(new string[] { "Sword" }, "Bronze Sword", "A grand bronze sword from years ago");
            i2 = new Item(new string[] { "Shield" }, "Wooden Shield", "A mighty wooden shield from the Stone age.");
            i3 = new Item(new string[] { "Cape" }, "Counts Cape", "A fabulously flowing cape!");

            b1 = new Bag(new string[] { "bag" }, "backpack", "Small backpack");
            b2 = new Bag(new string[] { "wallet" }, "Wallet", "small wallet");

            p = new Player("Jeff", "The mighty warrior");

            lookCommand = new LookCommand(new string[] { "look" });

            b1.Inventory.Put(i1);
            b2.Inventory.Put(i2);
            b1.Inventory.Put(b2);

            p.Inventory.Put(i1);
            p.Inventory.Put(b1);
        }

        [TestMethod]
        public void LookAtSwordTest()
        {
            Assert.AreEqual("A grand bronze sword from years ago", lookCommand.Execute(p, new string[] { "look", "at", "sword" }));
        }
        [TestMethod]
        public void LookAtNothingTest()
        {
            Assert.AreEqual("I cannot find the nothing", lookCommand.Execute(p, new string[] { "look", "at", "nothing" }));
        }
        [TestMethod]
        public void LookAtSwordInBagTest()
        {
            Assert.AreEqual("A grand bronze sword from years ago", lookCommand.Execute(p, new string[] { "look", "at", "sword", "in", "bag" }));
        }
        [TestMethod]
        public void LookAtSwordInNoBagTest()
        {
            Assert.AreEqual("I cannot find the satchule", lookCommand.Execute(p, new string[] { "look", "at", "sword", "in", "satchule" }));
        }
        [TestMethod]
        public void LookAtNoShieldInBagTest()
        {
            Assert.AreEqual("I cannot find the shield", lookCommand.Execute(p, new string[] { "look", "at", "shield", "in", "bag" }));

        }
        [TestMethod]
        public void InvalidLookTest()
        {
            Assert.AreEqual("Error in look input", lookCommand.Execute(p, new string[] { "Jeft", "at", "sword" }));
            Assert.AreEqual("I don't know how to look like that", lookCommand.Execute(p, new string[] { "Look", "at", "sword", "in" }));
            Assert.AreEqual("What do you want to look at?", lookCommand.Execute(p, new string[] { "Look", "in", "sword"}));
            Assert.AreEqual("What do you want to look in?", lookCommand.Execute(p, new string[] { "Look", "at", "sword", "at", "bag" }));
        }
    }
}
