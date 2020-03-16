using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if VALUE_IS_DOUBLE
	using ValueType = System.Double;
#else
#if VALUE_IS_SHORT
	using ValueType = System.Int16;
#else
#if VALUE_IS_LONG
	using ValueType = System.Int64;
#else
using ValueType = System.Int32;
#endif
#endif
#endif

namespace SortTest
{
    class StudSort
    {
        public static int Partition(ValueType[] data, int left, int right)
        {
            int pivot = left - 1;
            for (int i = left; i < right; i++)
            {
                if (data[i] < data[right])
                {
                    pivot++;
                    ValueType temp = data[pivot];
                    data[pivot] = data[i];
                    data[i] = temp;
                }
            }
            pivot++;
            ValueType temp1 = data[pivot];
            data[pivot] = data[right];
            data[right] = temp1;
            return pivot;
        }

        public static ValueType[] QuickSort(ValueType[] data, int left, int right)
        {
            if (left >= right)
            {
                return data;
            }

            int pivotIndex = Partition(data, left, right);
            QuickSort(data, left, pivotIndex - 1);
            QuickSort(data, pivotIndex + 1, right);

            return data;
        }

        public static ValueType[] Sort(ValueType[] data) // DON'T CHANGE this line!!!
        {
            return QuickSort(data, 0, data.Length - 1);
        }
    }
}
