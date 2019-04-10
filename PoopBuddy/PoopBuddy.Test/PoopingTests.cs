using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PoopBuddy.Data;
using PoopBuddy.Data.Logic;
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
            IList<PoopingDTO> objList = new List<PoopingDTO>();
            for (var i = 0; i < length; i++)
            {
                objList.Add(new PoopingDTO());
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

        [TestMethod]
        public void GetAllReturnsCorrectValues()
        {
            // ARRANGE
            var authorNamePrefix = "Author ";
            var poopingLogic = new Mock<IPoopingLogic>();
            IList<PoopingDTO> objList = new List<PoopingDTO>();
            for (var i = 0; i < 5; i++)
            {
                objList.Add(new PoopingDTO
                {
                    AuthorName = authorNamePrefix + i,
                    WagePerHour = 10 + i,
                    ExternalId = new Guid(),
                    Duration = new TimeSpan(0, 0, i)
                });
            }
            poopingLogic.Setup(pl => pl.GetAll()).Returns(new GetAllPoopingsResponse
            {
                PoopingList = objList
            });
            var controller = new PoopingController(poopingLogic.Object);

            // ACT
            var actionResult = controller.GetAll();

            //ASSERT
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var response = okObjectResult.Value as GetAllPoopingsResponse;
            Assert.IsNotNull(response);

            Assert.AreEqual(5, response.PoopingList.Count);

            var item = response.PoopingList.Single(p => p.AuthorName == authorNamePrefix + "1");
            Assert.IsNotNull(item);
            Assert.AreEqual(11, item.WagePerHour);
            Assert.AreEqual(1, item.Duration.TotalSeconds);

        }


    }
}
