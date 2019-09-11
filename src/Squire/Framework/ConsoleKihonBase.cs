using System;

using Squire.Framework.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Squire.Framework
{
    [TestClass]
    public abstract class ConsoleKihonBase : BaseKihon
    {
        private Mock<IConsoleWrapper> mockConsole;

        protected override void BeforeEachTest()
        {
            base.BeforeEachTest();
            mockConsole = new Mock<IConsoleWrapper>();
        }
        [TestMethod]
        public void Write_FooBar_To_The_Console()
        {
            // Arrange
            mockConsole.Setup(e => e.Write("FooBar"))
                .Verifiable("Did not call Write correctly");

            // Act
            Write_FooBar_To_The_Console(mockConsole.Object);

            // Assert
            mockConsole.Verify();
        }

        [TestMethod]
        public void WriteLine_FooBar_To_The_Console()
        {
            // Arrange
            mockConsole.Setup(e => e.WriteLine("FooBar"))
                .Verifiable("Did not call WriteLine correctly");

            // Act
            WriteLine_FooBar_To_The_Console(mockConsole.Object);

            // Assert
            mockConsole.Verify();
        }

        [TestMethod]
        public void Write_Foo_In_Blue_To_The_Console()
        {
            // Arrange
            mockConsole.SetupSet(e => e.ForegroundColor = ConsoleColor.Blue)
                .Verifiable("Did not set foreground color correctly.");
            mockConsole.Setup(e => e.Write("Foo"))
                .Verifiable("Did not call Write correctly");
            // Act
            Write_Foo_In_Blue_To_The_Console(mockConsole.Object);

            // Assert
            mockConsole.Verify();
        }

        [TestMethod]
        public void Read_Line_From_Console_And_Return_Value()
        {
            // Arrange
            string expected = "This is a test";
            mockConsole.Setup(c => c.ReadLine()).Returns(expected);

            // Act
            var actual = Read_Line_From_Console_And_Return_Value(mockConsole.Object);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        protected abstract void Write_FooBar_To_The_Console(IConsoleWrapper console);
        protected abstract void WriteLine_FooBar_To_The_Console(IConsoleWrapper console);
        protected abstract void Write_Foo_In_Blue_To_The_Console(IConsoleWrapper console);
        protected abstract object Read_Line_From_Console_And_Return_Value(IConsoleWrapper console);
    }
}
