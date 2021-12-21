#define countForLab
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
namespace Collections
{
    public static class Sorting
    {
        //public static IEnumerable<T> BubbleSort<T>(this IEnumerable<T> data)
        //{
        //    Stopwatch stopwatch = new Stopwatch();//текущая версия работает в 8 раз дольше чем типизированная сортировка пузырьком
        //    var toReturn = data.ToList();
        //    T temp;
        //    for (int i = 0; i < toReturn.Count; i++)
        //    {
        //        for (int j = i + 1; j < toReturn.Count; j++)
        //        {
        //            if (((IComparable)toReturn[i]).CompareTo(toReturn[j]) >= 0)
        //            {
        //                temp = toReturn[i];
        //                toReturn[i] = toReturn[j];
        //                toReturn[j] = temp;
        //            }
        //        }
        //    }

        //    return toReturn;
        //}

        //public static IEnumerable<T> selectionSort<T>(IEnumerable<T> values)
        //{
        //    var toReturn = values.ToList();
        //    for (int i = 0; i <toReturn.Count; ++i)
        //    {
        //        auto j = std::min_element(i, values.end());
        //        swap(*i, *j);
        //    }
        //}
        //private static T MinElement<T>(List<T> data,int startPos)
        //{
        //    T toReturn=data[startPos];
        //    for (int i = startPos+1; i < data.Count; i++)
        //    {
        //        if(((IComparable)toReturn).CompareTo(data[startPos])>1)
        //    }
        //}
#if countForLab
static int M=0,C=0;//только одно-поток
#endif
        static void Swap<T>(this List<T> array, int pos1, int pos2)
        {
            var temp = array[pos1];
            array[pos1] = array[pos2];
            array[pos2] = temp;
        }

        //сортировка пузырьком
        public static IEnumerable<T> BubbleSort<T>(this IEnumerable<T> array)
        {
            var toReturn = array.ToList();
            var len = array.Count();
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (((IComparable)toReturn[i]).CompareTo(toReturn[j + 1]) > 0)
                    {
                        toReturn.Swap(i, j + 1);
                    }
                }
            }

            return toReturn;
        }

        public static IEnumerable<T> InsertionSort<T>(this IEnumerable<T> array)
        {
            var toReturn = array.ToList();
            for (var i = 1; i < toReturn.Count; i++)
            {
                var key = toReturn[i];
                var j = i;
                while ((j > 1) && ((IComparable)toReturn[j - 1]).CompareTo(key) > 0)
                {
                    toReturn.Swap(j - 1, j);
                    j--;
                }

                toReturn[j] = key;
            }

            return toReturn;
        }



        //метод возвращающий индекс опорного элемента
        static int Partition<T>(List<T> array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
#if countForLab
                C++;
#endif
                if /*(array[i] < array[maxIndex])*/(((IComparable)array[i]).CompareTo(array[maxIndex]) < 0)
                {
                    pivot++;
#if countForLab
                    M++;
#endif
                    array.Swap(pivot, i);
                }
            }

            pivot++;
#if countForLab
            M++;
#endif
            array.Swap(pivot, maxIndex);
            return pivot;
        }

        //быстрая сортировка
        static IEnumerable<T> QuickSort<T>(IEnumerable<T> array, int minIndex, int maxIndex)
        {
            var toReturn = array.ToList();
            if (minIndex >= maxIndex)
            {
                return toReturn;
            }

            var pivotIndex = Partition(toReturn, minIndex, maxIndex);
            QuickSort(toReturn, minIndex, pivotIndex - 1);
            QuickSort(toReturn, pivotIndex + 1, maxIndex);

            return toReturn;
        }

        public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> array)
        {
            return QuickSort(array, 0, array.Count() - 1);
        }
    }
}
