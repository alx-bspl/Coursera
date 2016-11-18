using Algorithms1.Sorters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms1.Tests
{
    [TestClass]
    public class MergeSorter_Tests : Sorter_Tests<MergeSorter<int>>
    {
        protected override MergeSorter<int> Sorter => new MergeSorter<int>();
    }
}
