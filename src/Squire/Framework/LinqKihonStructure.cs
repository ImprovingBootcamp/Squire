using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Squire.Framework
{
    [TestClass]
    public abstract class LinqKihonStructure : BaseKihon
    {
        [TestMethod]
        public void Select_the_Something_property_from_list_test()
        {
            //arrange
            var product = new Product() {Something = 1};
            var list = new List<Product>()
                           {
                               product
                           };



            //act
            var item = Select_the_Something_property_from_list(list);

            //assert
            Assert.AreEqual(product.Something ,item.SingleOrDefault());
        }

        [TestMethod]
        public void Select_the_products_where_something_is_equal_to_2_from_list_test()
        {
            //arrange
            var product = new Product() { Something = 2 };
            var list = new List<Product>()
                           {
                               product,
                               new Product(){Something = 1}
                           };



            //act
            var item = Select_the_products_where_something_is_equal_to_2_from_list(list);

            //assert
            Assert.AreEqual(1, item.Count());
        }

        protected abstract IEnumerable<Product> Select_the_products_where_something_is_equal_to_2_from_list(List<Product> list);
        protected abstract IEnumerable<int> Select_the_Something_property_from_list(List<Product> list);
    }

    public class Product
    {
        public int Something { get; set; }
    }
}