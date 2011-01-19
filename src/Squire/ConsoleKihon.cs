using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Squire.Framework;

namespace Squire
{
    [TestClass]
    public class ConsoleKihon : ConsoleKihonStructure
    {
        protected override void Write_FooBar_To_The_Console(Framework.Abstractions.IConsoleWrapper console)
        {
            throw new NotImplementedException();
        }

        protected override void WriteLine_FooBar_To_The_Console(Framework.Abstractions.IConsoleWrapper console)
        {
            throw new NotImplementedException();
        }

        protected override void Write_Foo_In_Blue_To_The_Console(Framework.Abstractions.IConsoleWrapper console)
        {
            throw new NotImplementedException();
        }

        protected override object Read_Line_From_Console_And_Return_Value(Framework.Abstractions.IConsoleWrapper console)
        {
            throw new NotImplementedException();
        }
    }
}
