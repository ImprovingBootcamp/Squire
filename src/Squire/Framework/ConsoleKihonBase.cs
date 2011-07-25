using System;

using NUnit.Framework;
using Squire.Framework.Abstractions;
using Rhino.Mocks;

namespace Squire.Framework
{
    [TestFixture]
    public abstract class ConsoleKihonBase : BaseKihon
    {
        private IConsoleWrapper console;

        protected override void BeforeEachTest()
        {
            base.BeforeEachTest();
            console = MockRepository.GenerateMock<IConsoleWrapper>();
        }
        [Test]
        public void Write_FooBar_To_The_Console()
        {
            // Arrange
            

            // Act
            Write_FooBar_To_The_Console(console);

            // Assert
            console.AssertWasCalled(c => c.Write("FooBar"));
        }

        [Test]
        public void WriteLine_FooBar_To_The_Console()
        {
            // Arrange
            

            // Act
            WriteLine_FooBar_To_The_Console(console);

            // Assert
            console.AssertWasCalled(c => c.WriteLine("FooBar"));
        }

        [Test]
        public void Write_Foo_In_Blue_To_The_Console()
        {
            // Arrange
            

            // Act
            Write_Foo_In_Blue_To_The_Console(console);

            // Assert
            console.AssertWasCalled(c => c.ForegroundColor = ConsoleColor.Blue);
            console.AssertWasCalled(c => c.Write("Foo"));
        }

        [Test]
        public void Read_Line_From_Console_And_Return_Value()
        {
            // Arrange
            string expected = "This is a test";
            console.Stub(c => c.ReadLine()).Return(expected);

            // Act
            var actual = Read_Line_From_Console_And_Return_Value(console);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        protected abstract void Write_FooBar_To_The_Console(IConsoleWrapper console);
        protected abstract void WriteLine_FooBar_To_The_Console(IConsoleWrapper console);
        protected abstract void Write_Foo_In_Blue_To_The_Console(IConsoleWrapper console);
        protected abstract object Read_Line_From_Console_And_Return_Value(IConsoleWrapper console);
    }
}
