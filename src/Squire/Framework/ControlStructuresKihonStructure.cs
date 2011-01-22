using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;

namespace Squire.Framework
{
    public interface ITarget
    {
        void Hit();
        bool IsValid { get; }
    }

    [TestClass]
    public abstract class ControlStructuresKihonStructure : BaseKihon
    {
        [TestMethod]
        public void Call_Hit_On_a_If_val_Is_True_Else_Call_Hit_On_b_V1()
        {
            // Arrange
            var a = MockRepository.GenerateMock<ITarget>();
            var b = MockRepository.GenerateMock<ITarget>();
            bool val = true;

            // Act
            Call_Hit_On_a_If_val_Is_True_Else_Call_Hit_On_b(val, a, b);

            // Assert
            a.AssertWasCalled(t => t.Hit());
            b.AssertWasNotCalled(t => t.Hit());
        }

        [TestMethod]
        public void Call_Hit_On_a_If_val_Is_True_Else_Call_Hit_On_b_V2()
        {
            // Arrange
            var a = MockRepository.GenerateMock<ITarget>();
            var b = MockRepository.GenerateMock<ITarget>();
            bool val = false;

            // Act
            Call_Hit_On_a_If_val_Is_True_Else_Call_Hit_On_b(val, a, b);

            // Assert
            a.AssertWasNotCalled(t => t.Hit());
            b.AssertWasCalled(t => t.Hit());
        }

        [TestMethod]
        public void Call_Hit_On_a_Once_For_Each_Member_Of_list()
        {
            // Arrange
            var a = MockRepository.GenerateMock<ITarget>();
            var list = new List<string>() { "a", "b", "c", "d" };

            // Act
            Call_Hit_On_a_Once_For_Each_Member_Of_list(a, list);

            // Assert
            a.AssertWasCalled(m => m.Hit(), mo => mo.Repeat.Times(4));
        }

        [TestMethod]
        public void Call_Hit_On_a_While_a_IsValid_Is_True()
        {
            // Arrange
            var a = MockRepository.GenerateMock<ITarget>();
            a.Stub(m => m.IsValid).Return(true).Repeat.Times(4);
            a.Stub(m => m.IsValid).Return(false).Repeat.Times(1);

            // Act
            Call_Hit_On_a_While_a_IsValid_Is_True(a);
            
            // Assert
            a.AssertWasCalled(m => m.Hit(), mo => mo.Repeat.Times(4));
        }

        [TestMethod]
        public void n_Times_Call_Hit_On_a()
        {
            // Arrange
            var a = MockRepository.GenerateMock<ITarget>();
            var n = 132;

            // Act
            n_Times_Call_Hit_On_a(n, a);

            // Assert
            a.AssertWasCalled(m => m.Hit(), mo => mo.Repeat.Times(n));
        }

        [TestMethod]
        public void Call_Hit_On_a_Once_And_Continue_Until_IsValid_Is_False()
        {
            // Arrange
            var a = MockRepository.GenerateMock<ITarget>();
            a.Stub(m => m.IsValid).Return(true).Repeat.Times(4);
            a.Stub(m => m.IsValid).Return(false).Repeat.Times(1);

            // Act
            Call_Hit_On_a_Once_And_Loop_Until_IsValid_Is_False(a);

            // Assert
            a.AssertWasCalled(m => m.Hit(), mo => mo.Repeat.Times(5));
        }

        protected abstract void Call_Hit_On_a_If_val_Is_True_Else_Call_Hit_On_b(bool val, ITarget a, ITarget b);
        protected abstract void Call_Hit_On_a_Once_For_Each_Member_Of_list(ITarget a, List<System.String> list);
        protected abstract void Call_Hit_On_a_While_a_IsValid_Is_True(ITarget a);
        protected abstract void n_Times_Call_Hit_On_a(int n, ITarget a);
        protected abstract void Call_Hit_On_a_Once_And_Loop_Until_IsValid_Is_False(ITarget a);

    }
}
