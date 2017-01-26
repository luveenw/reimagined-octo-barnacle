using System;
using System.Runtime.Serialization;

namespace CMCS.Integer.Exception
{
    // Exception class to report on invalid triangle specifications.
    [Serializable]
    public class InvalidTriangleException : ArgumentException
    {
        public static readonly string NegativeSideMessageFormat = "Cannot specify negative value %d as a side in a triangle";
        public static readonly string NotATriangleMessageFormat = "%d, %d, and %d do not form a triangle";

        public InvalidTriangleException(int negativeSide)
            : base(System.String.Format(NegativeSideMessageFormat, negativeSide))
        {
        }

        public InvalidTriangleException(int a, int b, int c)
            : base(System.String.Format(NotATriangleMessageFormat, a, b, c))
        {
        }

        protected InvalidTriangleException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}