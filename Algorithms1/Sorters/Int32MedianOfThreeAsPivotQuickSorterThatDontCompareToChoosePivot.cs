using System.Collections.Generic;
using System.Linq;

namespace Algorithms1.Sorters
{
    public class Int32MedianOfThreeAsPivotQuickSorterThatDontCompareToChoosePivot : MedianOfThreeAsPivotQuickSorter<int>
    {
        public Int32MedianOfThreeAsPivotQuickSorterThatDontCompareToChoosePivot(IComparer<int> comparer) : base(comparer)
        {
        }

        public Int32MedianOfThreeAsPivotQuickSorterThatDontCompareToChoosePivot()
        {
        }

        internal override int ChoosePivotIndex(ArrayRange<int> range)
        {
            int middleIndex = (range.Length - 1) / 2, lastIndex = range.Length - 1;
            int first = range[0], middle = range[middleIndex], last = range.Last();

            if (first > last)
            {
                if (last > middle)
                    return lastIndex;
                if (first > middle)
                    return middleIndex;
                return 0;
            }

            if (first > middle)
                return 0;
            if (last > middle)
                return middleIndex;
            return lastIndex;
        }
    }
}