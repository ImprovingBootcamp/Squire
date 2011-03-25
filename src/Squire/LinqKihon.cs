using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Squire.Framework;

namespace Squire
{
    [TestClass]
    public class LinqKihon : LinqKihonStructure
    {
        public override IEnumerable<int> Select_a_single_property_from_an_object()
        {
            return _list.Select(x => x.Something);
        }
    }
}