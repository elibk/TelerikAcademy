////
namespace H0102ExtensionMethods
{
    using System;
    using System.Text;

    public static class StringBuiderExtentions
    {
        public static StringBuilder Substring(this StringBuilder strBuild, int startIndex, int length)
        {
            StringBuilder substring = new StringBuilder();

            for (int i = 0; i < length; i++, startIndex++)
            {
                substring.Append(strBuild[startIndex]);
            }

            return substring;
        }

        public static StringBuilder Substring(this StringBuilder strBuild, int startIndex)
        {
            StringBuilder substring = new StringBuilder();
            for (int i = startIndex; i < strBuild.Length; i++, startIndex++)
            {
                substring.Append(strBuild[startIndex]);
            }

            return substring;
        }
    }
}
