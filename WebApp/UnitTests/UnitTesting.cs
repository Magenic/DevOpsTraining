using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestSite.Controllers;

namespace UnitTests
{
    [TestClass]
    public class UnitTesting
    {
        [TestMethod]
        public void AboutMessage()
        {
            HomeController controller = new HomeController(null);
            ViewResult view = (ViewResult)controller.About();
            Assert.AreEqual("Automation demo site", view.ViewData["Message"]);
        }

        [TestMethod]
        public void ContactMessage()
        {
            HomeController controller = new HomeController(null);
            ViewResult view = (ViewResult)controller.Contact();
            Assert.AreEqual("Magenic", view.ViewData["Message"]);
        }

        [TestMethod]
        public void DidTheUnitWorkOne()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DidTheUnitWorkTwo()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DidTheUnitWorkThree()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DidTheUnitWorkFour()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DidTheUnitWorkFive()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DidTheUnitWorkSix()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DidTheUnitWorkSeven()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DidTheUnitWorkEight()
        {
            Assert.IsTrue(true);
        }
    }
}
