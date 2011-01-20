using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Squire.Framework;
using Squire.Framework.Abstractions;

namespace Squire
{
    /* ***** Important Please Read *****
     * 
     * System.Console is a static class, and as such difficult to test.
     * As such, for this Kihon we have abstracted this using the 
     * IConsoleWrapper interface.  IConsoleWrapper has all the same 
     * methods and properties as System.Console, so anything you can
     * do to one, you can do to the other.
     */
    [TestClass]
    public class ConsoleKihon : ConsoleKihonStructure
    {
        protected override void Write_FooBar_To_The_Console(IConsoleWrapper console)
        {
            throw new NotImplementedException();
        }

        protected override void WriteLine_FooBar_To_The_Console(IConsoleWrapper console)
        {
            throw new NotImplementedException();
        }

        protected override void Write_Foo_In_Blue_To_The_Console(IConsoleWrapper console)
        {
            throw new NotImplementedException();
        }

        protected override object Read_Line_From_Console_And_Return_Value(IConsoleWrapper console)
        {
            throw new NotImplementedException();
        }
    }
}
