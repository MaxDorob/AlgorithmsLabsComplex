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
     
#if countForLab
        public static int M = 0, C = 0;//только одно-поток
#endif
        static void Swap<T>(this List<T> array, int pos1, int pos2)
        {
#if countForLab
            M++;
#endif
            var temp = array[pos1];
            array[pos1] = array[pos2];
            array[pos2] = temp;
        }
        #region Пузырьком

        //сортировка пузырьком
        public static IEnumerable<T> BubbleSort<T>(this IEnumerable<T> array)
        {
#if countForLab
            M = 0; C = 0;//только одно-поток
#endif
            var toReturn = array.ToList();
            var len = array.Count();
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
#if countForLab
                    C++;
#endif
                    if (((IComparable)toReturn[i]).CompareTo(toReturn[j + 1]) > 0)
                    {
                        toReturn.Swap(i, j + 1);
                    }
                }
            }

            return toReturn;
        }
        #endregion
        #region Метод вставки

        public static IEnumerable<T> InsertionSort<T>(this IEnumerable<T> array)
        {
#if countForLab
            M = 0; C = 0;//только одно-поток
#endif
            var toReturn = array.ToList();
            for (var i = 1; i < toReturn.Count; i++)
            {
                var key = toReturn[i];
                var j = i;
#if countForLab
                C++;
#endif
                while ((j > 1) && ((IComparable)toReturn[j - 1]).CompareTo(key) > 0)
                {
                    toReturn.Swap(j - 1, j);
                    j--;
                }

                toReturn[j] = key;
            }

            return toReturn;
        }

        #endregion


        #region Быстрая сортировка
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

                    array.Swap(pivot, i);
                }
            }

            pivot++;
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
#if countForLab
            M = 0; C = 0;//только одно-поток
#endif
            return QuickSort(array, 0, array.Count() - 1);
        }


        #endregion

        #region Метод селекции
        static void Merge<T>(List<T> array, int lowIndex, int middleIndex, int highIndex)
        {

            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new T[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
#if countForLab
                C++;
#endif
                if (((IComparable)array[left]).CompareTo(array[right]) < 0)
                {
#if countForLab
                    M++;
#endif
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
#if countForLab
                    M++;
#endif
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
#if countForLab
                M++;
#endif
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
#if countForLab
                M++;
#endif
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
#if countForLab
                M++;
#endif
                array[lowIndex + i] = tempArray[i];
            }
        }

        //сортировка слиянием
        static IEnumerable<T> MergeSort<T>(List<T> array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        public static IEnumerable<T> MergeSort<T>(this IEnumerable<T> array)
        {
#if countForLab
            M = 0; C = 0;//только одно-поток
#endif
            return MergeSort(array.ToList(), 0, array.Count() - 1);
        }

        #endregion

    }
}
