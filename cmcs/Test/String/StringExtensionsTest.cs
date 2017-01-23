using NUnit.Framework;

namespace Cmcs.Test.String
{
    public class StringExtensionsTest
    {
        [Test]
        public void NonNullOrEmptyInputTest()
        {
            Assert.IsFalse(string.IsNullOrEmpty(" "));
            Assert.IsFalse(string.IsNullOrEmpty("a"));
            Assert.IsFalse(string.IsNullOrEmpty("null"));
        }

        [Test]
        public void NullOrEmptyInputTest()
        {
            Assert.IsTrue(string.IsNullOrEmpty(null));
            Assert.IsTrue(string.IsNullOrEmpty(string.Empty));
        }
    }
}