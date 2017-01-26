using CMCS.Integer;
using NUnit.Framework;

namespace CMCS.Test.Integer
{
    public class MostCommonTest
    {
        [Test]
        public void ValidInputTest()
        {
            Assert.AreEqual(
                new int[] {5, 4},
                MostCommon.FindMostCommonIn(new[] {5, 4, 3, 2, 4, 5, 1, 6, 1, 2, 5, 4}));
        }

        [Test]
        public void OneOccurrenceInput()
        {
            Assert.AreEqual(
                new int[] {5},
                MostCommon.FindMostCommonIn(new[] {5}));
        }

        [Test]
        public void EmptyInputTest()
        {
            Assert.AreEqual(
                new int[] {},
                MostCommon.FindMostCommonIn(new int[] {}));
        }
    }
}