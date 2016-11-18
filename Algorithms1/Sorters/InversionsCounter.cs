using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms1.Sorters
{
    public class InversionsCounter<T>
    {
        private readonly IComparer<T> _comparer;

        public InversionsCounter(): this(Comparer<T>.Default)
        {
        }

        public InversionsCounter(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public ulong CountInversions(T[] array)
        {
            if (array.Length == 0)
                return 0;

            T[] input = new T[array.Length],
                auxiliary = new T[input.Length];
            array.CopyTo(input, 0);
            input.CopyTo(auxiliary, 0);
            return SortAndCountInversions(new ArrayRange<T>(input, 0, input.Length), new ArrayRange<T>(auxiliary, 0, auxiliary.Length));
        }

        private ulong SortAndCountInversions(ArrayRange<T> input, ArrayRange<T> auxiliary)
        {
            Debug.Assert(input.Length == auxiliary.Length, "input.Length == auxiliary.Length");

            if (input.Length == 1)
                return 0;

            ArrayRange<T> leftRange = new ArrayRange<T>(auxiliary, 0, auxiliary.Length / 2),
                          rightRange = new ArrayRange<T>(auxiliary, auxiliary.Length / 2, auxiliary.Length - auxiliary.Length / 2),
                          auxiliaryLeftRange = new ArrayRange<T>(input, 0, input.Length / 2),
                          auxiliaryRightRange = new ArrayRange<T>(input, input.Length / 2, input.Length - input.Length / 2);

            return SortAndCountInversions(leftRange, auxiliaryLeftRange) +
                   SortAndCountInversions(rightRange, auxiliaryRightRange) +
                   MergeAndCountSplitInversions(input, leftRange, rightRange);
        }

        private ulong MergeAndCountSplitInversions(ArrayRange<T> output, ArrayRange<T> leftRange, ArrayRange<T> rightRange)
        {
            Debug.Assert(!output.UsesSameArrayAs(leftRange), "!output.UsesSameArrayAs(leftRange)");
            Debug.Assert(!output.UsesSameArrayAs(rightRange), "!output.UsesSameArrayAs(rightRange)");
            Debug.Assert(output.Length == leftRange.Length + rightRange.Length, "output.Length == leftRange.Length + rightRange.Length");

            ulong inversions = 0;
            int leftIndex = 0, rightIndex = 0;
            for (int i = 0; i < output.Length; i++)
            {
                if (leftIndex >= leftRange.Length)
                    output[i] = rightRange[rightIndex++];
                else if (rightIndex >= rightRange.Length)
                    output[i] = leftRange[leftIndex++];
                else if (_comparer.Compare(leftRange[leftIndex], rightRange[rightIndex]) <= 0)
                    output[i] = leftRange[leftIndex++];
                else
                {
                    output[i] = rightRange[rightIndex++];
                    inversions += (ulong) (leftRange.Length - leftIndex);
                }
            }
            
            return inversions;
        }
    }
}