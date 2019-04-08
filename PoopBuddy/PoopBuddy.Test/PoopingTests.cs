using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PoopBuddy.Data;
using PoopBuddy.Shared.DTO;
using PoopBuddy.WebApi.Controllers;

namespace PoopBuddy.Test
{
    [TestClass]
    public class PoopingTests
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(10)]
        public void GetAllReturnsCorrectListLength(int length)
        {
            // ARRANGE
            var poopingLogic = new Mock<IPoopingLogic>();
            IList<object> objList = new List<object>();
            for (var i = 0; i < length; i++)
            {
                objList.Add(new object());
            }
            poopingLogic.Setup(pl => pl.GetAll()).Returns(new GetAllPoopingsResponse
            {
                PoopingList = objList
            });
            var controller = new PoopingController(poopingLogic.Object);

            //ACT
            var actionResult = controller.GetAll();

            //ASSERT
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var response = okObjectResult.Value as GetAllPoopingsResponse;
            Assert.IsNotNull(response);

            Assert.AreEqual(length, response.PoopingList.Count);
        }
    }
}
