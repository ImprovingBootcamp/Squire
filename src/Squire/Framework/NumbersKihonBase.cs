using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Squire.Framework
{
    [TestClass]
    public abstract class NumbersKihonBase : BaseKihon
    {
        [TestMethod]
        public void Return_The_Maximum_Value_Of_Int32_Test()
        {
            // Arrange
            

            // Act
            int result = Return_The_Maximum_Value_Of_Int32();

            // Assert
            Assert.AreEqual(Int32.MaxValue, result);
        }

        [TestMethod]
        public void Return_The_Minimum_Value_Of_Int32_Test()
        {
            // Arrange
            

            // Act
            int result = Return_The_Minimum_Value_Of_Int32();

            // Assert
            Assert.AreEqual(int.MinValue, result);
        }

        [TestMethod]
        public void Return_The_Remainder_Of_a_Divided_By_b()
        {
            // Arrange
            int a = 251;
            int b = 25;

            // Act
            int remainder = Return_The_Remainder_Of_a_Divided_By_b(a, b);

            // Assert
            Assert.AreEqual(a % b, remainder);
        }

        [TestMethod]
        public void Return_The_Maximum_Value_Of_Double_Test()
        {
            // Arrange
            

            // Act
            double actual = Return_The_Maximum_Value_Of_Double();

            // Assert
            Assert.AreEqual(double.MaxValue, actual);
        }

        [TestMethod]
        public void Return_The_Minimum_Value_Of_Double_Test()
        {
            // Arrange
            

            // Act
            double actual = Return_The_Minimum_Value_Of_Double();

            // Assert
            Assert.AreEqual(double.MinValue, actual);
        }

        [TestMethod]
        public void Return_True_If_a_Is_Not_A_Number_Test1()
        {
            // Arrange
            double a = 1.24;

            // Act
            var result = Return_True_If_a_Is_Not_A_Number(a);

            // Assert
            Assert.AreEqual(double.IsNaN(a), result);
        }

        [TestMethod]
        public void Return_True_If_a_Is_Not_A_Number_Test2()
        {
            // Arrange
            double a = double.NegativeInfinity;

            // Act
            var result = Return_True_If_a_Is_Not_A_Number(a);

            // Assert
            Assert.AreEqual(double.IsNaN(a), result);
        }

        [TestMethod]
        public void Return_True_If_a_Is_Not_A_Number_Test3()
        {
            // Arrange
            double a = double.NaN;

            // Act
            var result = Return_True_If_a_Is_Not_A_Number(a);

            // Assert
            Assert.AreEqual(double.IsNaN(a), result);
        }

        [TestMethod]
        public void Return_True_If_a_Is_An_Infinity_Test1()
        {
            // Arrange
            double a = 1.24;

            // Act
            var actual = Return_True_If_a_Is_An_Infinity(a);

            // Assert
            Assert.AreEqual(double.IsInfinity(a), actual);
        }

        [TestMethod]
        public void Return_True_If_a_Is_An_Infinity_Test2()
        {
            // Arrange
            double a = double.NegativeInfinity;

            // Act
            var actual = Return_True_If_a_Is_An_Infinity(a);

            // Assert
            Assert.AreEqual(double.IsInfinity(a), actual);
        }

        [TestMethod]
        public void Return_True_If_a_Is_An_Infinity_Test3()
        {
            // Arrange
            double a = double.PositiveInfinity;

            // Act
            var actual = Return_True_If_a_Is_An_Infinity(a);

            // Assert
            Assert.AreEqual(double.IsInfinity(a), actual);
        }

        protected abstract int Return_The_Maximum_Value_Of_Int32();
        protected abstract int Return_The_Minimum_Value_Of_Int32();
        protected abstract int Return_The_Remainder_Of_a_Divided_By_b(int a, int b);
        protected abstract double Return_The_Maximum_Value_Of_Double();
        protected abstract double Return_The_Minimum_Value_Of_Double();
        protected abstract bool Return_True_If_a_Is_Not_A_Number(double a);
        protected abstract bool Return_True_If_a_Is_An_Infinity(double a);
    }
}
