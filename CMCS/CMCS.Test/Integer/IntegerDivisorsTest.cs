using System.Collections.Generic;
using CMCS.Integer;
using NUnit.Framework;

namespace CMCS.Test.Integer
{
    // Unit tests for IntegerDivisors.
    public class IntegerDivisorsTest
    {
        // Subject under test
        private static readonly IntegerDivisors Sut = new IntegerDivisors();

        [Test]
        public void NegativeInputTest()
        {
            Assert.IsEmpty(Sut.DivisorsOf(-3));
        }

        [Test]
        public void ZeroInputTest()
        {
            Assert.IsEmpty(Sut.DivisorsOf(0));
        }

        [Test]
        public void ValidInputTest()
        {
            Assert.IsTrue(new HashSet<int>(Sut.DivisorsOf(1)).SetEquals(new HashSet<int> {1}));
            Assert.IsTrue(new HashSet<int>(Sut.DivisorsOf(60)).SetEquals(new HashSet<int> {1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 30, 60}));
            Assert.IsTrue(new HashSet<int>(Sut.DivisorsOf(42)).SetEquals(new HashSet<int> {1, 2, 3, 6, 7, 14, 21, 42}));
            Assert.IsTrue(new HashSet<int>(Sut.DivisorsOf(379)).SetEquals( new HashSet<int> {1, 379}));
            Assert.IsTrue(new HashSet<int>(Sut.DivisorsOf(377)).SetEquals( new HashSet<int> {1, 13, 29, 377}));
        }
    }
}