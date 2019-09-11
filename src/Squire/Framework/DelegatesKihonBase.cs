using System;
using Squire.Framework;
using System.Collections.Generic;
using Moq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Squire
{

    [TestClass]
    public abstract class DelegatesKihonBase
    {
        [TestMethod]
        public void _Return_An_Action_That_Calls_Hit_On_Its_Parameter()
        {
            // Arrange
            var a = new Mock<ITarget>();
            a.Setup(e => e.Hit()).Verifiable();

            // Act
            var result = Return_An_Action_That_Calls_Hit_On_Its_Parameter();
            result.Invoke(a.Object);

            // Assert
            a.Verify();
        }

        [TestMethod]
        public void Return_An_Action_That_Calls_Hit_On_a()
        {
            // Arrange
            var a = new Mock<ITarget>();
            a.Setup(e => e.Hit()).Verifiable();

            // Act
            var result = Return_An_Action_That_Calls_Hit_On_a(a.Object);
            result.Invoke();

            // Assert
            a.Verify();
        }

        [TestMethod]
        public void Return_An_Expression_That_Is_a_or_b()
        {
            // Arrange
            var aValues = new[] { true, false };
            var bValues = new[] { false, true };
            
            // Act
            foreach (bool aValue in aValues)
            {
                foreach (bool bValue in bValues)
                {
                    var result = Return_An_Expression_That_Is_a_or_b(aValue, bValue);
                    var body = result.Body;

                    if (typeof(BinaryExpression).IsInstanceOfType(body) == false)
                        Assert.Fail("Not a binary expression");
                    else
                    {
                        var binaryExp = result.Body as BinaryExpression;
                        var left = binaryExp.Left;
                        if (typeof(MemberExpression).IsInstanceOfType(left) == false)
                            Assert.Fail("Left is not a parameter expression : " + left.GetType().BaseType.Name);
                        else
                        {
                            var right = binaryExp.Right;
                            if (typeof(MemberExpression).IsInstanceOfType(right) == false)
                                Assert.Fail("Right is not a parameter expression : " + right.GetType().BaseType.Name);
                        }
                    }

                    var boolResult = result.Compile().Invoke();
                    Assert.AreEqual(boolResult, aValue || bValue);
                }
            }
            // Assert
            
        }

        public abstract Action Return_An_Action_That_Calls_Hit_On_a(ITarget a);
        public abstract Action<ITarget> Return_An_Action_That_Calls_Hit_On_Its_Parameter();
        public abstract Expression<Func<bool>> Return_An_Expression_That_Is_a_or_b(bool a, bool b);
    }
}
