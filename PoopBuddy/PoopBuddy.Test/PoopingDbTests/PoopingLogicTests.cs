using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoopBuddy.Data.Logic;
using PoopBuddy.Shared.DTO;

namespace PoopBuddy.Test.PoopingDbTests
{
    [TestClass]
    public class PoopingLogicTests : PoopingLogicTestBase
    {
        [TestMethod]
        public void GetAllPoopingsEmptyResponseTest()
        {
            var response = PoopingLogic.GetAll();
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.PoopingList);
            Assert.AreEqual(0, response.PoopingList.Count);
        }

        [TestMethod]
        public void AddPoopingResponseTest()
        {
            var poopingRequest = new AddPoopingRequest
            {
                AuthorName = "John",
                Duration = TimeSpan.FromMinutes(3),
                WagePerHour = 12
            };
            PoopingLogic.Add(poopingRequest);
            var allPoopings = PoopingLogic.GetAll();

            Assert.IsNotNull(allPoopings);
            Assert.IsNotNull(allPoopings.PoopingList);
            Assert.AreEqual(1, allPoopings.PoopingList.Count);
            var pooping = allPoopings.PoopingList.First();
            Assert.AreEqual("John", pooping.AuthorName);
            Assert.AreEqual(TimeSpan.FromMinutes(3), pooping.Duration);
            Assert.AreEqual(12, pooping.WagePerHour);
        }
    }
}