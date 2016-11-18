using System.IO;
using System.Linq;
using Algorithms1.Sorters;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms1.Tests
{
    [TestClass]
    public class InversionsCounter_Tests
    {
        [TestMethod]
        public void InversionsCounter_CountInversions_should_count_inversion_for_large_reversed_array()
        {
            var array = Enumerable.Range(0, 100000).Reverse().ToArray();
            var inversionsCounter = new InversionsCounter<int>();

            var inversions = inversionsCounter.CountInversions(array);

            inversions.Should().Be((ulong)array.Length * ((ulong)array.Length - 1) / 2);
        }

        [TestMethod]
        public void InversionsCounter_CountInversions_should_count_inversion_for_unsorted_array()
        {
            var array = new[] { 5, 4, 6, 3, 7, 2, 8, 1, 9 };
            var inversionsCounter = new InversionsCounter<int>();

            var inversions = inversionsCounter.CountInversions(array);

            inversions.Should().Be(16);
        }

        [TestMethod]
        public void InversionsCounter_CountInversions_should_count_inversion_for_unsorted_array_with_three_elements()
        {
            var array = new[] { 5, 4, 6};
            var inversionsCounter = new InversionsCounter<int>();

            var inversions = inversionsCounter.CountInversions(array);

            inversions.Should().Be(1);
        }

        [TestMethod]
        public void InversionsCounter_CountInversions_should_count_inversion_for_array_with_equal_elements()
        {
            var array = new []{1, 2, 3, 3, 2, 1};
            var inversionsCounter = new InversionsCounter<int>();

            var inversions = inversionsCounter.CountInversions(array);

            inversions.Should().Be(6);
        }

        [TestMethod]
        public void InversionsCounter_CountInversions_should_count_inversion_for_array_of_equal_elements()
        {
            var array = Enumerable.Repeat(0, 3).ToArray();
            var inversionsCounter = new InversionsCounter<int>();

            var inversions = inversionsCounter.CountInversions(array);

            inversions.Should().Be(0);
        }

        [TestMethod]
        public void InversionsCounter_CountInversions_should_count_inversion_for_two_elements_array_without_inversions()
        {
            var array = new [] { 1, 2 };
            var inversionsCounter = new InversionsCounter<int>();

            var inversions = inversionsCounter.CountInversions(array);

            inversions.Should().Be(0);
        }

        [TestMethod]
        public void InversionsCounter_CountInversions_should_count_inversion_for_two_elements_array_with_one_inversion()
        {
            var array = new [] {2, 1};
            var inversionsCounter = new InversionsCounter<int>();

            var inversions = inversionsCounter.CountInversions(array);

            inversions.Should().Be(1);
        }

        [TestMethod]
        public void InversionsCounter_CountInversions_should_count_inversion_for_four_elements_array_with_one_inversion()
        {
            var array = new []{1, 2, 4, 3};
            var inversionsCounter = new InversionsCounter<int>();

            var inversions = inversionsCounter.CountInversions(array);

            inversions.Should().Be(1);
        }

        [TestMethod]
        public void InversionsCounter_CountInversions_should_count_inversion_for_reversed_array()
        {
            var array = Enumerable.Range(0, 8).Reverse().ToArray();
            var inversionsCounter = new InversionsCounter<int>();

            var inversions = inversionsCounter.CountInversions(array);

            inversions.Should().Be((ulong) (array.Length*(array.Length - 1)/2));
        }
    }
}