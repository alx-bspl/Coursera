using System.Linq;
using Algorithms1.Graphs;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms1.Tests.Graphs
{
    [TestClass]
    public class VerticesExtensions_Tests
    {
        [TestMethod]
        public void CreateReversed_Should_Reverse_Rhomb_Graph()
        {
            var graph = Enumerable.Range(0, 4)
                                  .Select(n => new Vertex<int>(n))
                                  .Cast<Vertex>()
                                  .ToArray();
            //
            //  0
            // / \
            //1   2
            // \ /
            //  3
            //
            graph[0].Connect(graph[1]);
            graph[0].Connect(graph[2]);
            graph[1].Connect(graph[3]);
            graph[2].Connect(graph[3]);

            graph.Reverse();

            graph[0].Successors.ToArray().Should().BeEmpty();
            graph[1].Successors.ToArray().Should().Equal(graph[0]);
            graph[2].Successors.ToArray().Should().Equal(graph[0]);
            graph[3].Successors.ToArray().Should().Equal(graph[1], graph[2]);
        }
    }
}