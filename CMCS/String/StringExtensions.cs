namespace CMCS.String
{
    // Extends the string type by adding an IsNullOrEmpty method that behaves
    // identically to the standard .NET variant, but does not delegate to it in order
    // to do so.
    public static class StringExtensions
    {
        /// <summary>
        /// Determines if the specified string parameter is <code>null</code> or empty.
        /// </summary>
        /// <param name="str">The string to examine.</param>
        /// <returns><code>true</code> if <paramref name="str" /> is <code>null</code> or empty; <code>false</code> otherwise.</returns>
        public static bool IsNullOrEmpty(this string str)
        {
             return (str == null || str.Length == 0);
        }
    }
}