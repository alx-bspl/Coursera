using System.Collections.Generic;

namespace Algorithms1.Sorters
{
    public class LastAsPivotQuickSorter<T> : QuickSorter<T>
    {
        public LastAsPivotQuickSorter(IComparer<T> comparer) : base(comparer)
        {
        }

        public LastAsPivotQuickSorter()
        {
        }

        internal override int ChoosePivotIndex(ArrayRange<T> range)
        {
            return range.Length - 1;
        }
    }
}