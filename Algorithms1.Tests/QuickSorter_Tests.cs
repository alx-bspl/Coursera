using Algorithms1.Sorters;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms1.Tests
{
    [TestClass]
    public abstract class QuickSorter_Tests: Sorter_Tests<QuickSorter<int>>
    {
        [TestMethod]
        public void FirstAsPivotQuickSorter_Sort_Should_Sort_Unsorted_Array()
        {
            var array = new[] {3, 8, 2, 5, 1, 4, 7, 6};
            var unsortedArray = new int[array.Length];
            array.CopyTo(unsortedArray, 0);

            Sorter.Sort(array);

            array.Should().BeEquivalentTo(unsortedArray);
            array.Should().BeInAscendingOrder();
        }
    }
}