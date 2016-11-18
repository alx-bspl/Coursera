using Algorithms1.Sorters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms1.Tests
{
    [TestClass]
    public class MedianOfThreeAsPivotQuickSorter_Tests: Sorter_Tests<MedianOfThreeAsPivotQuickSorter<int>>
    {
        protected override MedianOfThreeAsPivotQuickSorter<int> Sorter => new MedianOfThreeAsPivotQuickSorter<int>();

        [Ignore]
        public override void Sorter_Sort_should_sort_large_reversed_array()
        {
            base.Sorter_Sort_should_sort_large_reversed_array();
        }
    }
}