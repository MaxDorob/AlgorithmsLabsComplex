using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Collections
{
    internal static class Utils
    {
        public const int StandLength = 8;
        public static string ToLength (this string str, int length)
        {
            if (str.Length > length)
                return str.Substring(0, length);
            StringBuilder builder = new StringBuilder(str,length);
            builder.Append(' ', length - str.Length);
            return builder.ToString();
        }
        public static string ConcatWithBlock(this string str1, string str2)
        {
            var str1Arr= str1.Split('\n');
            var str2Arr = str2.Split('\n');
            string[] newStrArr = new string[Math.Max(str1Arr.Length,str2Arr.Length)];
            for (int i = 0; i < Math.Max(str1Arr.Length, str2Arr.Length); i++)
            {
                if (i < str1Arr.Length && i < str2Arr.Length)
                {
                    newStrArr[i] = str1Arr[i] + str2Arr[i];
                }
                else if (i < str1Arr.Length)
                {
                    newStrArr[i] = str1Arr[i];
                }
                else
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(' ', str1Arr.Max(x => x.Length));
                    builder.Append(str2Arr);
                    newStrArr[i] = builder.ToString();
                }
            }
            return String.Join('\n', newStrArr);
        }
    }
}
