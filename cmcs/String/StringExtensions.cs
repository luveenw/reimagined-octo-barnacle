using System;

namespace Cmcs.String
{
    // Extends the string type by adding an IsNullOrEmpty method that behaves
    // identically to the standard .NET variant, but does not delegate to it in order
    // to do so.
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string str)
        {
            Console.WriteLine(str + " null or empty...");
            return (str == null || str.Length == 0);
        }
    }
}