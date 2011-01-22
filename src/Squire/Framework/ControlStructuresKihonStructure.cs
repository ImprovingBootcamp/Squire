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

        protected abstract void Call_Hit_On_a_If_val_Is_True_Else_Call_Hit_On_b(bool val, ITarget a, ITarget b);
        protected abstract void Call_Hit_On_a_Once_For_Each_Member_Of_list(ITarget a, List<System.String> list);

    }
}
