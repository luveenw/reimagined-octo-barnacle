using NUnit.Framework;
using CMCS.String;

namespace CMCS.Test.String
{
    // Unit tests for StringExtensions.
    public class StringExtensionsTest
    {
        [Test]
        public void NonNullOrEmptyInputTest()
        {
            Assert.IsFalse(" ".IsNullOrEmpty());
            Assert.IsFalse("a".IsNullOrEmpty());
            Assert.IsFalse("null".IsNullOrEmpty());
        }

        [Test]
        public void NullOrEmptyInputTest()
        {
            Assert.IsTrue(StringExtensions.IsNullOrEmpty(null));
            Assert.IsTrue(string.Empty.IsNullOrEmpty());
        }
    }
}