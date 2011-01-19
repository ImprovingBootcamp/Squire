using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;

namespace Squire.Framework
{
    [TestClass]
    public abstract class BaseKihon
    {
        private IWindsorContainer container;

        [TestInitialize]
        public void Initialize()
        {
            container = new WindsorContainer();
            RegisterComponents(container);
            BeforeEachTest();
        }

        [TestCleanup]
        public void Cleanup()
        {
            AfterEachTest();
        }

        protected virtual void RegisterComponents(IWindsorContainer container)
        {
        }
        protected virtual void BeforeEachTest()
        {
        }
        protected virtual void AfterEachTest()
        {
        }

    }
}
