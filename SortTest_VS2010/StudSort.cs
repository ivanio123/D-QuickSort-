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
        static int Partition(ValueType[] data, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (data[i] < data[maxIndex])
                {
                    pivot++;
                    ValueType temp = data[pivot];
                    data[pivot] = data[i];
                    data[i] = temp;
                }
            }

            pivot++;
            ValueType temp1 = data[pivot];
            data[pivot] = data[maxIndex];
            data[maxIndex] = temp1;
            return pivot;
        }

        static ValueType[] Sort(ValueType[] data, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return data;
            }

            int pivotIndex = Partition(data, minIndex, maxIndex);
            Sort(data, minIndex, pivotIndex - 1);
            Sort(data, pivotIndex + 1, maxIndex);

            return data;
        }

        public static ValueType[] Sort(ValueType[] data) // DON'T CHANGE this line!!!
        {
            return Sort(data, 0, data.Length - 1);
        }
    }
}
