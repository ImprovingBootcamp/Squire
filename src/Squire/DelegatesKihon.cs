using Microsoft.VisualStudio.TestTools.UnitTesting;
using Squire.Framework;
using System;
using System.Linq.Expressions;

namespace Squire
{
    [TestClass]
    public class DelegatesKihon : DelegatesKihonBase
    {
        public override Action Return_An_Action_That_Calls_Hit_On_a(ITarget a)
        {
            throw new NotImplementedException();
        }

        public override Action<ITarget> Return_An_Action_That_Calls_Hit_On_Its_Parameter()
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<bool>> Return_An_Expression_That_Is_a_or_b(bool a, bool b)
        {
            throw new NotImplementedException();
        }
    }
}
