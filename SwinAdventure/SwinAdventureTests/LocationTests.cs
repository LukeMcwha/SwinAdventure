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
    public class LocationTests
    {
        Item i;
        Location l;        
        [TestInitialize]
        public void Initilize()
        {
            i = new Item(new string[] { "gem" }, "gem", "A beautiful gem");
            l = new Location(new string[] { "room" }, "bedroom", "a beautiful master bedroom");
            l.Inventory.Put(i);
        }

        [TestMethod()]
        public void LocateTest()
        {
            Assert.AreSame(i, l.Locate("gem"));
        }

        [TestMethod]
        public void LocateNothingTest()
        {
            Assert.IsNull(l.Locate("Nothing"));
        }
    }
}