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
    public class IdentifiableObjectTests
    {
        IdentifiableObject id;

        [TestInitialize]
        public void Initialize()
        {
            id = new IdentifiableObject(new string[] { "me", "you" });
        }

        [TestMethod]
        public void AreYouTest()
        { 
            Assert.AreEqual(id.AreYou("me"), true);
        }

        [TestMethod]
        public void NotAreYouTest()
        {
            Assert.AreEqual(id.AreYou("someone else"), false);
        }

        [TestMethod]
        public void CaseSensitivityAreYouTest()
        {
            Assert.AreEqual(id.AreYou("yOU"), true);
        }

        [TestMethod]
        public void AddIdentifierTest()
        {
            id.AddIdentifier("baCon");
            Assert.AreEqual(id.AreYou("bacon"), true);
        }

        [TestMethod]
        public void FirstIDTest()
        {
            Assert.AreEqual(id.FirstId, "me");
        }
    }
}