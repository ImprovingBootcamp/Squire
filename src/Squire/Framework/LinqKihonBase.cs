using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Squire.Framework
{
    [TestClass]
    public abstract class LinqKihonBase : BaseKihon
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
        public void Filter_the_products_where_something_is_equal_to_2_from_list_test()
        {
            //arrange
            var product = new Product() { Something = 2 };
            var list = new List<Product>()
                           {
                               product,
                               new Product(){Something = 1}
                           };



            //act
            var item = Filter_the_products_where_something_is_equal_to_2_from_list(list);

            //assert
            Assert.AreEqual(1, item.Count());
        }

        [TestMethod]
        public void Order_the_list_by_the_something_property_test()
        {
            //arrange
            var product = new Product() { Something = 2 };
            var list = new List<Product>()
                           {
                               product,
                               new Product(){Something = 1}
                           };



            //act
            IEnumerable<Product> item = Order_the_list_by_the_something_property(list);

            //assert
            Assert.AreEqual(list[0], item.FirstOrDefault());
            Assert.AreEqual(list[1], item.LastOrDefault());
        }


        [TestMethod]
        public void Order_the_list_by_the_something_property_descending_test()
        {
            //arrange
            var product = new Product() { Something = 2 };
            var list = new List<Product>()
                           {
                               product,
                               new Product(){Something = 1}
                           };



            //act
            IEnumerable<Product> item = Order_the_list_by_the_something_property_descending(list);

            //assert
            Assert.AreEqual(list[1], item.FirstOrDefault());
            Assert.AreEqual(list[0], item.LastOrDefault());
        }

        protected abstract IEnumerable<Product> Order_the_list_by_the_something_property_descending(List<Product> list);
        protected abstract IEnumerable<Product> Order_the_list_by_the_something_property(List<Product> list);
        protected abstract IEnumerable<Product> Filter_the_products_where_something_is_equal_to_2_from_list(List<Product> list);
        protected abstract IEnumerable<int> Select_the_Something_property_from_list(List<Product> list);
    }

    public class Product
    {
        public int Something { get; set; }
    }
}