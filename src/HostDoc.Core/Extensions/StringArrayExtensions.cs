namespace HostDoc.Core.Extensions
{
    public static class StringArrayExtensions
    {
        /// <summary>Concatenates all the elements of a string array beginning from a specified index, using the specified separator between each element.</summary>
        /// <param name="startIndex">The index to start from.</param>
        /// <param name="separator">The string to use as a separator. separator is included in the returned string only if value has more than one element.</param>
        /// <returns>A string that consists of the elements in the array delimited by the <paramref name="separator">separator</paramref> string. If index is greater than array length, the method returns null.</returns>
        public static string JoinFrom(this string[] strArray, int startIndex, string separator)
        {
            if (strArray.Length <= startIndex) 
                return null;
            
            string[] otherParts = new string[strArray.Length - startIndex];
            for (int i = startIndex; i < strArray.Length; i++)
            {
                otherParts[i - startIndex] = strArray[i];
            }

            return string.Join(separator, otherParts);
        }
    }
}