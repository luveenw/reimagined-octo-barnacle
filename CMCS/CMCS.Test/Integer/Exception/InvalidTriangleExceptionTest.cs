using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using CMCS.Integer.Exception;
using NUnit.Framework;

namespace CMCS.Test.Integer.Exception
{
    // Tests for InvalidTriangleException.
    // Inspired by https://blogs.msdn.microsoft.com/agileer/2013/05/17/the-correct-way-to-code-a-custom-exception-class/
    public class InvalidTriangleExceptionTest
    {
        private const int NegativeSide = -1;
        private const int A = 1;
        private const int B = 3;
        private const int C = 5;

        private static readonly InvalidTriangleException NegativeSideSut = new InvalidTriangleException(NegativeSide);
        private static readonly InvalidTriangleException NotATriangleSut = new InvalidTriangleException(A, B, C);

        [Test]
        public void NegativeSideConstructorTest()
        {
            Assert.IsNull(NegativeSideSut.InnerException);
            Assert.AreEqual(
                System.String.Format(InvalidTriangleException.NegativeSideMessageFormat, NegativeSide),
                NegativeSideSut.Message);
        }

        [Test]
        public void NotATriangleConstructorTest()
        {
            Assert.IsNull(NotATriangleSut.InnerException);
            Assert.AreEqual(
                System.String.Format(InvalidTriangleException.NotATriangleMessageFormat, A, B, C),
                NotATriangleSut.Message);
        }

        [Test]
        public void NegativeSideSerializationDeserializationTest()
        {
            RunSerDesTestOn(NegativeSideSut);
        }

        [Test]
        public void NotATriangleSerializationDeserializationTest()
        {
            RunSerDesTestOn(NotATriangleSut);
        }

        [Test]
        public void NegativeSideGetObjectDataForNullInfoTest()
        {
            RunGetObjectDataForNullInfoTestOn(NegativeSideSut);
        }

        [Test]
        public void NotATriangleGetObjectDataForNullInfoTest()
        {
            RunGetObjectDataForNullInfoTestOn(NotATriangleSut);
        }

        private static void RunSerDesTestOn(InvalidTriangleException ite)
        {
            var buffer = new byte[4096];
            var stream = new MemoryStream(buffer);
            var stream2 = new MemoryStream(buffer);
            var formatter = new BinaryFormatter();

            formatter.Serialize(stream, ite);
            var deserializedException = (InvalidTriangleException)formatter.Deserialize(stream2);

            Assert.AreEqual(ite.Message, deserializedException.Message);
        }

        private static void RunGetObjectDataForNullInfoTestOn(InvalidTriangleException ite)
        {
            // ReSharper disable AssignNullToNotNullAttribute
            Assert.Throws<ArgumentNullException>(() => ite.GetObjectData(null, new StreamingContext()));
            // ReSharper restore AssignNullToNotNullAttribute
        }
    }
}