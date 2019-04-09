using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoopBuddy.Data;
using PoopBuddy.Data.Context;
using PoopBuddy.Data.Entities;
using PoopBuddy.Data.Repositories;

namespace PoopBuddy.Test
{
    [TestClass]
    public class PoopingRepositoryTests
    {
        [TestMethod]
        public void AddPersistItemInDatabase()
        {
            // ARRANGE
            var options = new DbContextOptionsBuilder<PoopingContext>()
                .UseInMemoryDatabase(databaseName: "AddPersistItemInDatabase")
                .Options;

            using (var context = new PoopingContext(options))
            {
                IPoopingRepository poopingRepository = new PoopingRepository(context);
                
                poopingRepository.Add(new PoopingEntity
                {
                    Author = "Czesio",
                    Duration = new TimeSpan(0,0,5),
                    WagePerHour = 15,
                    ExternalId = Guid.NewGuid()
                });
            }

            using (var context = new PoopingContext(options))
            {
                IPoopingRepository poopingRepository = new PoopingRepository(context);

                var pooping = poopingRepository.GetSingle(e => e.Author == "Czesio");

                Assert.AreNotEqual(new Guid(), pooping.ExternalId, "Guid is not random!");
                Assert.AreEqual(15, pooping.WagePerHour);
                Assert.AreEqual("Czesio", pooping.Author);
                Assert.AreEqual(5, pooping.Duration.TotalSeconds);
            }
        }
    }
}
