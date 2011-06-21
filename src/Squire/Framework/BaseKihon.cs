using System;
using Castle.Windsor;
using NUnit.Framework;

namespace Squire.Framework
{

    [TestFixture]
    public abstract class BaseKihon
    {
        private IWindsorContainer container;

        [SetUp]
        public void Initialize()
        {
            container = new WindsorContainer();
            RegisterComponents(container);
            BeforeEachTest();
        }

        [Test]
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
