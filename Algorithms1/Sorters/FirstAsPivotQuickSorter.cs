using System.Collections.Generic;

namespace Algorithms1.Sorters
{
    public class FirstAsPivotQuickSorter<T> : QuickSorter<T>
    {
        public FirstAsPivotQuickSorter(IComparer<T> comparer) : base(comparer)
        {
        }

        public FirstAsPivotQuickSorter()
        {
        }

        internal override int ChoosePivotIndex(ArrayRange<T> range)
        {
            return 0;
        }
    }
}