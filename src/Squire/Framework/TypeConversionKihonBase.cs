namespace Squire.Framework
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public abstract class TypeConversionKihonBase : BaseKihon
    {
        [TestMethod]
        public void Convert_String_To_Int()
        {
            // Arrange

            // Act

            // Assert
        }

        protected abstract int Convert_String_To_Int(int data);

    }
}