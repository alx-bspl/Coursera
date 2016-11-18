using Algorithms1.Sorters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms1.Tests
{
    [TestClass]
    public class FirstAsPivotQuickSorter_Tests : QuickSorter_Tests
    {
        protected override QuickSorter<int> Sorter => new FirstAsPivotQuickSorter<int>();

        [Ignore]
        public override void Sorter_Sort_should_sort_large_reversed_array()
        {
            base.Sorter_Sort_should_sort_large_reversed_array();
        }
    }
}