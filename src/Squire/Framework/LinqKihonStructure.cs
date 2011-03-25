using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Squire.Framework
{
    [TestClass]
    public abstract class LinqKihonStructure : BaseKihon
    {
        internal List<Product> _list = new List<Product>
                                           {
                                               new Product {Something = 1}
                                           };

        [TestMethod]
        public void Select_a_property_from_a_list_of_objects_test()
        {
            //arrange

            //act
            var item = Select_a_property_from_a_list_of_objects();

            //assert
            Assert.AreEqual(_list.First() ,item.First());
        }

        public abstract IEnumerable<int> Select_a_property_from_a_list_of_objects();
    }

    internal class Product
    {
        public int Something { get; set; }
    }
}