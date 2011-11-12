using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Squire.Framework;

namespace Squire
{
    //[TestFixture]
    public class LinqKihon : LinqKihonBase
    {
        protected override IEnumerable<int> Select_the_Something_property_from_list(List<Product> list)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Product> Order_the_list_by_the_something_property_descending(List<Product> list)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Product> Order_the_list_by_the_something_property(List<Product> list)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Product> Filter_the_products_where_something_is_equal_to_2_from_list(List<Product> list)
        {
            throw new NotImplementedException();
        }
    }
}