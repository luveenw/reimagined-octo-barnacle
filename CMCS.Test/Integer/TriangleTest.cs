using CMCS.Integer;
using CMCS.Integer.Exception;
using NUnit.Framework;

namespace CMCS.Test.Integer
{
    public class TriangleTest : Triangle
    {
        [Test]
        public void InvalidTriangleValidateTest()
        {
            var ex = Assert.Throws<InvalidTriangleException>(() => Triangle.Validate(5, 3, 1));
            Assert.AreEqual(ex.Message, System.String.Format(InvalidTriangleException.NotATriangleMessageFormat, 2, 3, 1));
        }

        [Test]
        public void NegativeSideValidateTest()
        {
            var ex = Assert.Throws<InvalidTriangleException>(() => Triangle.Validate(2, 3, -4));
            Assert.AreEqual(ex.Message, System.String.Format(InvalidTriangleException.NegativeSideMessageFormat, -4));
        }

        [Test]
        public void ValidInputTest()
        {
            Assert.AreEqual(16.248, Triangle.CalculateArea(5, 7, 10));
        }
    }
}