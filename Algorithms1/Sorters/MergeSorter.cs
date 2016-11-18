using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms1.Sorters
{
    public interface ISorter<in T>
    {
        IComparer<T> Comparer { get; } 

        void Sort(T[] array);
    }

    public sealed class MergeSorter<T>: ISorter<T>
    {
	    public IComparer<T> Comparer { get; }

		public MergeSorter(IComparer<T> comparer)
		{
			Comparer = comparer;
		}

		public MergeSorter(): this(Comparer<T>.Default)
		{
		}

		public void Sort(T[] array)
		{
		    if (array.Length == 0)
				return;

		    var auxiliary = new T[array.Length];
            array.CopyTo(auxiliary, 0);
            Sort(new ArrayRange<T>(array, 0, array.Length), new ArrayRange<T>(auxiliary, 0, auxiliary.Length));
		}

	    private void Sort(ArrayRange<T> input, ArrayRange<T> auxiliary)
		{
            Debug.Assert(input.Length == auxiliary.Length, "input.Length == auxiliary.Length");

		    if (input.Length <= 1)
		        return;

		    ArrayRange<T> leftRange = new ArrayRange<T>(auxiliary, 0, auxiliary.Length/2),
		                  rightRange = new ArrayRange<T>(auxiliary, auxiliary.Length/2, auxiliary.Length - auxiliary.Length/2),
		                  auxiliaryLeftRange = new ArrayRange<T>(input, 0, input.Length/2),
		                  auxiliaryRightRange = new ArrayRange<T>(input, input.Length/2, input.Length - input.Length/2);

            Sort(leftRange, auxiliaryLeftRange);
		    Sort(rightRange, auxiliaryRightRange);
			Merge(input, leftRange, rightRange);
		}

	    private void Merge(ArrayRange<T> output, ArrayRange<T> leftRange, ArrayRange<T> rightRange)
	    {
	        Debug.Assert(!output.UsesSameArrayAs(leftRange), "!output.UsesSameArrayAs(leftRange)");
	        Debug.Assert(!output.UsesSameArrayAs(rightRange), "!output.UsesSameArrayAs(rightRange)");
	        Debug.Assert(output.Length == leftRange.Length + rightRange.Length, "output.Length == leftRange.Length + rightRange.Length");

	        int leftIndex = 0, rightIndex = 0;
	        for (int i = 0; i < output.Length; i++)
	        {
	            if (leftIndex >= leftRange.Length)
	                output[i] = rightRange[rightIndex++];
	            else if (rightIndex >= rightRange.Length)
	                output[i] = leftRange[leftIndex++];
	            else if (Comparer.Compare(leftRange[leftIndex], rightRange[rightIndex]) <= 0)
	                output[i] = leftRange[leftIndex++];
	            else
	                output[i] = rightRange[rightIndex++];
	        }
	    }
	}
}
