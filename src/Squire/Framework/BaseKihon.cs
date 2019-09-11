using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Squire.Framework
{

    [TestClass]
    public abstract class BaseKihon
    {
        [TestInitialize]
        public void Initialize()
        {
            BeforeEachTest();
        }

        [TestCleanup]
        public void Cleanup()
        {
            AfterEachTest();
        }

        protected virtual void BeforeEachTest()
        {
        }
        protected virtual void AfterEachTest()
        {
        }
    }
}
