using System.Collections.Generic;
using System.Linq;

namespace Algorithms1.Sorters
{
    public class MedianOfThreeAsPivotQuickSorter<T> : QuickSorter<T>
    {
        public MedianOfThreeAsPivotQuickSorter(IComparer<T> comparer) : base(comparer)
        {
        }

        public MedianOfThreeAsPivotQuickSorter()
        {
        }

        internal override int ChoosePivotIndex(ArrayRange<T> range)
        {
            int middleIndex = (range.Length - 1)/2, lastIndex = range.Length - 1;
            T first = range[0], middle = range[middleIndex], last = range.Last();

            if (Comparer.Compare(first, last) > 0)
            {
                if (Comparer.Compare(last, middle) > 0)
                    return lastIndex;
                if (Comparer.Compare(first, middle) > 0)
                    return middleIndex;
                return 0;
            }

            if (Comparer.Compare(first, middle) > 0)
                return 0;
            if (Comparer.Compare(last, middle) > 0)
                return middleIndex;
            return lastIndex;
        }
    }
}