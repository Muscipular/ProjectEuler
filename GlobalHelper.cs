using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemEuler
{
    static class GlobalHelper
    {
        public static void QuickSort<T>(this T[] array) where T : IComparable<T>
        {
            QuickSort(array, 0, array.Length - 1);
        }

        public static void QuickSort<T>(T[] array, int start, int end) where T : IComparable<T>
        {
            if (start >= end)
            {
                return;
            }
            T s = array[start];
            T e = array[end];
            int mI = (start + end) >> 1;
            T m = array[mI];
            if (s != null && s.CompareTo(m) > 0)
            {
                m = s;
            }
            if (m == null || m.CompareTo(e) > 0)
            {
                m = e;
            }
            int i = start, j = end;
            while (i < j)
            {
                T tmp;
                while (i < j && (array[i] == null || array[i].CompareTo(m) <= 0)) i++;
                if (i != j)
                {
                    tmp = array[j];
                    array[j] = array[i];
                    array[i] = array[j];
                }
                while (j > i && (array[j] != null && array[j].CompareTo(m) >= 0)) j--;
                if(i!=j){
                tmp = array[j];
                array[j] = array[i];
                array[i] = array[j];
            }}
            QuickSort(array, start, i - 1);
            QuickSort(array, j + 1, end);
        }
    }
}
