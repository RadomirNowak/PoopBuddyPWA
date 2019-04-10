using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoopBuddy.Data.Database.Repositories;

namespace PoopBuddy.Test.PoopingDbTests
{
    [TestClass]
    public abstract class PoopingRepositoryTestBase : InMemoryDbTestBase
    {
        protected IPoopingRepository PoopingRepository;

        [TestInitialize]
        public override void BeforeEachTest()
        {
            base.BeforeEachTest();
            PoopingRepository = new PoopingRepository(Context);
        }
    }
}