using System;
using NUnit.Framework;
using Squire.Framework;
using System.Collections.Generic;
using Rhino.Mocks;
using System.Linq.Expressions;

namespace Squire
{
    [TestFixture]
    public class DelegatesKihon : DelegatesKihonBase
    {
        public override Action Return_An_Action_That_Calls_Hit_On_a(ITarget a)
        {
            return () => a.Hit();
        }

        public override Action<ITarget> Return_An_Action_That_Calls_Hit_On_Its_Parameter()
        {
            return a => a.Hit();
        }

        public override Expression<Func<bool>> Return_An_Expression_That_Is_a_or_b(bool a, bool b)
        {
            return () => a || b;
        }
    }

    [TestFixture]
    public abstract class DelegatesKihonBase
    {
        [Test]
        public void _Return_An_Action_That_Calls_Hit_On_Its_Parameter()
        {
            // Arrange
            var a = MockRepository.GenerateMock<ITarget>();

            // Act
            var result = Return_An_Action_That_Calls_Hit_On_Its_Parameter();
            result.Invoke(a);

            // Assert
            a.AssertWasCalled(e => e.Hit(), mo => mo.Repeat.Once());
        }

        [Test]
        public void Return_An_Action_That_Calls_Hit_On_a()
        {
            // Arrange
            var a = MockRepository.GenerateMock<ITarget>();

            // Act
            var result = Return_An_Action_That_Calls_Hit_On_a(a);
            result.Invoke();

            // Assert
            a.AssertWasCalled(m => m.Hit(), mo => mo.Repeat.Once());
        }

        [Test]
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
