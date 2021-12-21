using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    static class Test
    {
        public static IEnumerable<T> BubbleSort1<T>(this IEnumerable<T> data)
        {
            var toReturn = data.ToList();
            T temp;
            for (int i = 0; i < toReturn.Count; i++)
            {
                for (int j = i + 1; j < toReturn.Count; j++)
                {
                    if (((IComparable)toReturn[i]).CompareTo(toReturn[j]) >= 0)
                    {
                        temp = toReturn[i];
                        toReturn[i] = toReturn[j];
                        toReturn[j] = temp;
                    }
                }
            }

            return toReturn;
        }
    }
}
