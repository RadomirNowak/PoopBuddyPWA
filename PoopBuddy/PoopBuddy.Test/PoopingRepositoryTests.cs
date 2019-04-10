using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoopBuddy.Data.Database.Entities;
using PoopBuddy.Data.Database.Repositories;

namespace PoopBuddy.Test
{
    [TestClass]
    public class PoopingRepositoryTests : InMemoryDbTestBase
    {
        private IPoopingRepository poopingRepository;

        [TestInitialize]
        public override void BeforeEachTest()
        {
            base.BeforeEachTest();
            poopingRepository = new PoopingRepository(Context);
        }

        [TestMethod]
        public void AddPersistItemInDatabase()
        {
            poopingRepository.Add(new PoopingEntity
            {
                Author = "Czesio",
                Duration = new TimeSpan(0, 0, 5),
                WagePerHour = 15,
                ExternalId = Guid.NewGuid()
            });

            var pooping = poopingRepository.GetSingle(e => e.Author == "Czesio");

            Assert.AreNotEqual(new Guid(), pooping.ExternalId, "Guid is not random!");
            Assert.AreEqual(15, pooping.WagePerHour);
            Assert.AreEqual("Czesio", pooping.Author);
            Assert.AreEqual(5, pooping.Duration.TotalSeconds);
        }

        [TestMethod]
        public void GetAllItemsReturnsEmptyListWhenNoItemsArePresent()
        {
            var allItems = poopingRepository.GetAll();
            Assert.IsNotNull(allItems);
            Assert.AreEqual(0, allItems.Count());
        }

        private Guid AddPoopingToDb(string author, decimal wagePerHour, TimeSpan duration)
        {
            return poopingRepository.Add(new PoopingEntity
            {
                Author = author,
                WagePerHour = wagePerHour,
                Duration = duration,
                ExternalId = Guid.NewGuid()
            });
        }

        [TestMethod]
        public void GetThatMatchesMultipleRecordsThrowsException()
        {
            const string duplicatedAuthor = "John";
            var guid1 = AddPoopingToDb(duplicatedAuthor, 5, TimeSpan.FromSeconds(1));
            var guid2 = AddPoopingToDb(duplicatedAuthor, 16, TimeSpan.FromSeconds(1));

            Assert.AreNotEqual(guid2, guid1 );
            Assert.ThrowsException<InvalidOperationException>(
                () => poopingRepository.GetSingle(p => p.Author == duplicatedAuthor));
        }

        [TestMethod]
        public void GetSingleReturnsCorrectEntity()
        {
            var guid1 = AddPoopingToDb("John", 5, TimeSpan.FromSeconds(1));
            var guid2 = AddPoopingToDb("Jane", 16, TimeSpan.FromSeconds(2));
            var guid3 = AddPoopingToDb("Janice", 22, TimeSpan.FromSeconds(3));

            AssertEntitiesAreEqual(guid1, "John", 5, TimeSpan.FromSeconds(1), poopingRepository.GetSingle(e => e.Author == "John"));
            AssertEntitiesAreEqual(guid2, "Jane", 16, TimeSpan.FromSeconds(2), poopingRepository.GetSingle(e => e.Author == "Jane"));
            AssertEntitiesAreEqual(guid3, "Janice", 22, TimeSpan.FromSeconds(3), poopingRepository.GetSingle(e => e.Author == "Janice"));
        }

        private void AssertEntitiesAreEqual(Guid id, string author, decimal wagePerHour, TimeSpan duration,
            PoopingEntity entityToCompareTo)
        {
            Assert.AreEqual(id, entityToCompareTo.Id);
            Assert.AreEqual(author, entityToCompareTo.Author);
            Assert.AreEqual(wagePerHour, entityToCompareTo.WagePerHour);
            Assert.AreEqual(duration, entityToCompareTo.Duration);
        }

        [TestMethod]
        public void AddingEntityWithSameIdThrows()
        {
            var guid1 = AddRandomPoopingToDb();
            Assert.ThrowsException<InvalidOperationException>(() => poopingRepository.Add(new PoopingEntity
            {
                Author = "Other random",
                Duration = TimeSpan.FromSeconds(5),
                ExternalId = Guid.NewGuid(),
                WagePerHour = 5,
                Id = guid1
            }));
        }

        private Guid AddRandomPoopingToDb()
        {
            var random = new Random();
            return AddPoopingToDb("Random author " + random.Next(), random.Next(), TimeSpan.FromSeconds(random.Next()));
        }

        [TestMethod]
        public void AddingDeletingSearchingTest()
        {
            var guidToDelete = AddRandomPoopingToDb();
            var guidToLookup = AddRandomPoopingToDb();
            AddRandomPoopingToDb();
            AddRandomPoopingToDb();

            var allItems = poopingRepository.GetAll();
            Assert.AreEqual(4, allItems.Count());
            Assert.IsNotNull(poopingRepository.GetById(guidToLookup));
            poopingRepository.Delete(guidToDelete);
            allItems = poopingRepository.GetAll();

            Assert.AreEqual(3, allItems.Count());
            Assert.IsNull(allItems.SingleOrDefault(p=>p.Id == guidToDelete));
        }

        [TestMethod]
        public void SingleOrDefaultReturnsNullIfNotExists()
        {
            Assert.IsNull(poopingRepository.GetSingleOrDefault(p => p.Author == "Non existing author"));
        }
    }
}