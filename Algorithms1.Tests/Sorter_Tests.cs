using System.Linq;
using Algorithms1.Sorters;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms1.Tests
{
    [TestClass]
    public abstract class Sorter_Tests<TSorter>
        where TSorter : ISorter<int>
    {
        protected abstract TSorter Sorter { get; }

        [TestMethod]
        public virtual void Sorter_Sort_should_sort_array_with_one_element()
        {
            var array = new[] {1};
            var unsortedArray = new int[array.Length];
            array.CopyTo(unsortedArray, 0);
            
            Sorter.Sort(array);

            array.Should().BeEquivalentTo(unsortedArray);
            array.Should().BeInAscendingOrder();
        }

        [TestMethod]
        public virtual void Sorter_Sort_should_sort_sorted_array_with_two_different_elements()
        {
            var array = new[] {1, 2};
            var unsortedArray = new int[array.Length];
            array.CopyTo(unsortedArray, 0);
            
            Sorter.Sort(array);

            array.Should().BeEquivalentTo(unsortedArray);
            array.Should().BeInAscendingOrder();
        }

        [TestMethod]
        public virtual void Sorter_Sort_should_sort_unsorted_array_with_two_different_elements()
        {
            var array = new[] {2, 1};
            var unsortedArray = new int[array.Length];
            array.CopyTo(unsortedArray, 0);
            
            Sorter.Sort(array);

            array.Should().BeEquivalentTo(unsortedArray);
            array.Should().BeInAscendingOrder();
        }

        [TestMethod]
        public virtual void Sorter_Sort_should_sort_array_with_two_equal_elements()
        {
            var array = new[] {1, 1};
            var unsortedArray = new int[array.Length];
            array.CopyTo(unsortedArray, 0);

            Sorter.Sort(array);

            array.Should().BeEquivalentTo(unsortedArray);
            array.Should().BeInAscendingOrder();
        }

        [TestMethod]
        public virtual void Sorter_Sort_should_sort_array_that_have_equal_elements()
        {
            var array = new[] {1, 2, 3, 3, 2, 1, 6, 5};
            var unsortedArray = new int[array.Length];
            array.CopyTo(unsortedArray, 0);
            
            Sorter.Sort(array);

            array.Should().BeEquivalentTo(unsortedArray);
            array.Should().BeInAscendingOrder();
        }

        [TestMethod]
        public virtual void Sorter_Sort_should_sort_unsorted_array_with_three_different_elements()
        {
            var array = new[] {2, 3, 1};
            var unsortedArray = new int[array.Length];
            array.CopyTo(unsortedArray, 0);
            
            Sorter.Sort(array);

            array.Should().BeEquivalentTo(unsortedArray);
            array.Should().BeInAscendingOrder();
        }

        [TestMethod]
        public virtual void Sorter_Sort_should_sort_unsorted_array_with_two_sorted_parts()
        {
            var array = new[] {3, 4, 1, 2};
            var unsortedArray = new int[array.Length];
            array.CopyTo(unsortedArray, 0);
            
            Sorter.Sort(array);

            array.Should().BeEquivalentTo(unsortedArray);
            array.Should().BeInAscendingOrder();
        }

        [TestMethod]
        public virtual void Sorter_Sort_should_sort_unsorted_array_with_two_unsorted_parts()
        {
            var array = new[] {2, 1, 4, 3};
            var unsortedArray = new int[array.Length];
            array.CopyTo(unsortedArray, 0);

            Sorter.Sort(array);

            array.Should().BeEquivalentTo(unsortedArray);
            array.Should().BeInAscendingOrder();
        }

        [TestMethod]
        public virtual void Sorter_Sort_should_sort_unsorted_array()
        {
            var array = new[] {1, 3, 5, 6, 4, 2};
            var unsortedArray = new int[array.Length];
            array.CopyTo(unsortedArray, 0);
            
            Sorter.Sort(array);

            array.Should().BeEquivalentTo(unsortedArray);
            array.Should().BeInAscendingOrder();
        }

        [TestMethod]
        public virtual void Sorter_Sort_should_sort_reversed_array()
        {
            var array = Enumerable.Range(0, 8).Reverse().ToArray();
            var unsortedArray = new int[array.Length];
            array.CopyTo(unsortedArray, 0);
            
            Sorter.Sort(array);

            array.Should().BeEquivalentTo(unsortedArray);
            array.Should().BeInAscendingOrder();
        }

        [TestMethod]
        public virtual void Sorter_Sort_should_sort_large_reversed_array()
        {
            const int size = 100000;
            var array = Enumerable.Range(0, size).Reverse().ToArray();
            
            Sorter.Sort(array);

            array.Should().Match(sortedArray => sortedArray.SequenceEqual(Enumerable.Range(0, size)));
        }
    }
}