using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoopBuddy.Data.Logic;

namespace PoopBuddy.Test.PoopingDbTests
{
    [TestClass]
    public abstract class PoopingLogicTestBase : PoopingRepositoryTestBase
    {
        protected IPoopingLogic PoopingLogic;

        [TestInitialize]
        public override void BeforeEachTest()
        {
            base.BeforeEachTest();
            PoopingLogic = new PoopingLogic(PoopingRepository);
        }
    }
}
