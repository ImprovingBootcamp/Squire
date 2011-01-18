using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Squire.Framework
{
    [TestClass]
    public abstract class StringKihonStructure : BaseKihon
    {
        [TestMethod]
        public void Combine_Two_Strings()
        {
            // Arrange
            string a = "foo";
            string b = "bar";

            // Act
            string actual = Combine_Two_Strings(a, b);

            // Assert
            Assert.AreEqual(a + b, actual);
        }

        [TestMethod]
        public void Combine_Parts_Of_A_Name()
        {
            // Arrange
            string firstName = "Timothy";
            string middleName = "John";
            string lastName = "Rayburn";

            // Act
            string actual = Combine_Parts_Of_A_Name(firstName,middleName,lastName);

            // Assert
            Assert.AreEqual(string.Format("{0} {1} {2}",firstName,middleName,lastName), actual);
        }

        [TestMethod]
        public void Split_A_String_Into_An_Array()
        {
            // Arrange
            char divider = '|';
            string input = "this|is|a|test";

            // Act
            string[] actual = Split_A_String_Into_An_Array(input, divider);

            // Assert
            Assert.AreEqual(input.Split(divider), actual);
        }

        [TestMethod]
        public void Join_An_Array_Into_A_String()
        {
            // Arrange
            string divider = " ";
            string[] input = new[] { "Timothy", "John", "Rayburn" };

            // Act
            string actual = Join_An_Array_Into_A_String(input,divider);

            // Assert
            Assert.AreEqual(string.Join(divider,input), actual);
        }

        [TestMethod]
        public void Determine_The_Length_Of_A_String()
        {
            // Arrange
            string data = "This is a really long string with random data in it";
            
            // Act
            int actual = Determine_The_Length_Of_A_String(data);

            // Assert
            Assert.AreEqual(data.Length, actual);
        }

        [TestMethod]
        public void Remove_All_Leading_Whitespace()
        {
            // Arrange
            string data = "         data with whitespace pre-pended";

            // Act
            string actual = Remove_All_Leading_Whitespace(data);

            // Assert
            Assert.AreEqual(data.TrimStart(), actual);
        }

        [TestMethod]
        public void Remove_All_Trailing_Whitespace()
        {
            // Arrange
            string data = "This is a test           ";
            
            // Act
            string actual = Remove_All_Trailing_Whitespace(data);

            // Assert
            Assert.AreEqual(data.TrimEnd(), actual);
        }

        [TestMethod]
        public void Convert_To_Uppercase()
        {
            // Arrange
            string data = "this is a Simple sTrInG";

            // Act
            string actual = Convert_To_Uppercase(data);

            // Assert
            Assert.AreEqual(data.ToUpper(), actual);
        }

        [TestMethod]
        public void Convert_To_Lowercase()
        {
            // Arrange
            string data = "THIS IS A SHOUTING PERSON!";
            
            // Act
            string actual = Convert_To_Lowercase(data);

            // Assert
            Assert.AreEqual(data.ToLower(), actual);
        }

        [TestMethod]
        public void Determine_The_Position_Of_a_In_b()
        {
            // Arrange
            string a = "summer";
            string b = "Now is the winter of our discontent, made glorious summer by the son of York.";

            // Act
            int actual = Determine_The_Position_Of_a_In_b(a, b);

            // Assert
            Assert.AreEqual(b.IndexOf(a), actual);
        }

        [TestMethod]
        public void Return_True_If_a_Contains_b()
        {
            // Arrange
            string a = "This is a simple xyzzy exam";
            string b = "xyzzy";
            
            // Act
            bool actual = Return_True_If_a_Contains_b(a, b);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Return_True_If_a_Starts_With_b()
        {
            // Arrange
            string a = "Fantastic Legendary Musciain";
            string b = "Fantastic Legen";

            // Act
            bool actual = Return_True_If_a_Starts_With_b(a, b);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Return_True_Is_a_Ends_With_b()
        {
            // Arrange
            string a = "This is a test";
            string b = "s a test";
            
            // Act
            bool actual = Return_True_Is_a_Ends_With_b(a,b);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Return_The_Fourth_Through_Seventh_Characters_Of_Input()
        {
            // Arrange
            string input = "1234567890";

            // Act
            string actual = Return_The_Fourth_Through_Seventh_Characters_Of_Input(input);

            // Assert
            Assert.AreEqual(input.Substring(3,4), actual);
        }

        protected abstract string Convert_To_Uppercase(string data);
        protected abstract string Convert_To_Lowercase(string data);
        protected abstract string Combine_Parts_Of_A_Name(string firstName, string middleName, string lastName);
        protected abstract string Combine_Two_Strings(string a, string b);
        protected abstract int Determine_The_Length_Of_A_String(string data);
        protected abstract string Remove_All_Leading_Whitespace(string data);
        protected abstract string Remove_All_Trailing_Whitespace(string data);
        protected abstract string[] Split_A_String_Into_An_Array(string input, char divider);
        protected abstract string Join_An_Array_Into_A_String(string[] input, string divider);
        protected abstract bool Return_True_If_a_Contains_b(string a, string b);
        protected abstract int Determine_The_Position_Of_a_In_b(string a, string b);
        protected abstract bool Return_True_If_a_Starts_With_b(string a, string b);
        protected abstract bool Return_True_Is_a_Ends_With_b(string a, string b);
        protected abstract string Return_The_Fourth_Through_Seventh_Characters_Of_Input(string input);
    }
}
