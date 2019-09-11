using System;

using Moq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Squire.Framework
{
    public interface ITarget
    {
        void Hit();
        bool IsValid { get; }
    }

    [TestClass]
    public abstract class ControlStructuresKihonBase : BaseKihon
    {
        [TestMethod]
        public void Call_Hit_On_a_If_val_Is_True_Else_Call_Hit_On_b_V1()
        {
            // Arrange
            var a = new Mock<ITarget>();
            var b = new Mock<ITarget>(MockBehavior.Strict);
            bool val = true;
            a.Setup(e => e.Hit()).Verifiable();

            // Act
            Call_Hit_On_a_If_val_Is_True_Else_Call_Hit_On_b(val, a.Object, b.Object);

            // Assert
            a.Verify();
            b.Verify();
        }

        [TestMethod]
        public void Call_Hit_On_a_If_val_Is_True_Else_Call_Hit_On_b_V2()
        {
            // Arrange
            var a = new Mock<ITarget>(MockBehavior.Strict);
            var b = new Mock<ITarget>();
            bool val = false;
            b.Setup(e => e.Hit()).Verifiable();

            // Act
            Call_Hit_On_a_If_val_Is_True_Else_Call_Hit_On_b(val, a.Object, b.Object);

            // Assert
            a.Verify();
            b.Verify();
        }

        [TestMethod]
        public void Call_Hit_On_a_Once_For_Each_Member_Of_list()
        {
            // Arrange
            var a = new Mock<ITarget>();
            var list = new List<string>() { "a", "b", "c", "d" };
            a.Setup(e => e.Hit()).Verifiable();
            a.Setup(e => e.Hit()).Verifiable();
            a.Setup(e => e.Hit()).Verifiable();
            a.Setup(e => e.Hit()).Verifiable();

            // Act
            Call_Hit_On_a_Once_For_Each_Member_Of_list(a.Object, list);

            // Assert
            a.Verify();
        }

        [TestMethod]
        public void Call_Hit_On_a_While_a_IsValid_Is_True()
        {
            // Arrange
            var a = new Mock<ITarget>();
            a.Setup(m => m.IsValid).Returns(true).Verifiable();
            a.Setup(m => m.IsValid).Returns(true).Verifiable();
            a.Setup(m => m.IsValid).Returns(true).Verifiable();
            a.Setup(m => m.IsValid).Returns(true).Verifiable();
            a.Setup(m => m.IsValid).Returns(false).Verifiable();

            // Act
            Call_Hit_On_a_While_a_IsValid_Is_True(a.Object);

            // Assert
            a.Verify();
        }

        [TestMethod]
        public void n_Times_Call_Hit_On_a()
        {
            // Arrange
            var a = new Mock<ITarget>();
            var n = 132;
            var count = 0;
            a.Setup(e => e.Hit()).Callback(() => count++);

            // Act
            n_Times_Call_Hit_On_a(n, a.Object);

            // Assert
            Assert.AreEqual(n, count);
        }

        [TestMethod]
        public void Call_Hit_On_a_Once_And_Continue_Until_IsValid_Is_False()
        {
            // Arrange
            var a = new Mock<ITarget>();
            a.Setup(m => m.IsValid).Returns(true).Verifiable();
            a.Setup(m => m.IsValid).Returns(true).Verifiable();
            a.Setup(m => m.IsValid).Returns(true).Verifiable();
            a.Setup(m => m.IsValid).Returns(true).Verifiable();
            a.Setup(m => m.IsValid).Returns(false).Verifiable();

            // Act
            Call_Hit_On_a_Once_And_Loop_Until_IsValid_Is_False(a.Object);

            // Assert
            a.Verify();
        }

        protected abstract void Call_Hit_On_a_If_val_Is_True_Else_Call_Hit_On_b(bool val, ITarget a, ITarget b);
        protected abstract void Call_Hit_On_a_Once_For_Each_Member_Of_list(ITarget a, List<System.String> list);
        protected abstract void Call_Hit_On_a_While_a_IsValid_Is_True(ITarget a);
        protected abstract void n_Times_Call_Hit_On_a(int n, ITarget a);
        protected abstract void Call_Hit_On_a_Once_And_Loop_Until_IsValid_Is_False(ITarget a);

    }
}
