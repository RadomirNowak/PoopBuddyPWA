using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoopBuddy.Data.Context;

namespace PoopBuddy.Test
{
    [TestClass]
    public abstract class InMemoryDbTestBase
    {
        protected PoopingContext Context;


        // TestContext musi być public ponieważ jest automatycznie uzupełniane przez MsTest
        // ReSharper disable once MemberCanBePrivate.Global
        public TestContext TestContext { get; set; } 

        [TestInitialize]
        public virtual void BeforeEachTest()
        {
            var options = new DbContextOptionsBuilder<PoopingContext>()
                .UseInMemoryDatabase(databaseName: TestContext.TestName)
                .Options;

            Context = new PoopingContext(options);
        }

        [TestCleanup]
        public virtual void AfterEachTest()
        {
                Context.Dispose();
                Context = null;
        }
    }
}
