using System.Text.RegularExpressions;

namespace HostDoc.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>Removes all white-space characters from the current <see cref="T:System.String"></see> object (including inbetween white-spaces).</summary>
        /// <returns>The string that remains after all white-space characters are removed from the start, middle and end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        public static string TrimAll(this string str)
        {
            var regex = new Regex(@"\s+");
            var newStr = regex.Replace(str, " ");
            return newStr.Trim();
        }
    }
}