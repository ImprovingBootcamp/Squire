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
        public override IEnumerable<int> Select_the_Something_property_from_list(List<Product> list)
        {
            return list.Select(x => x.Something);
        }
    }
}