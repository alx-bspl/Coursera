using System;
using System.Linq;
using Algorithms1.Graphs;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms1.Tests.Graphs
{
    [TestClass]
    public class DFS_Tests
    {
        [TestMethod]
        public void DFS_Should_Traverse_Single_Node_Graph()
        {
            var graph = Enumerable.Range(0, 1)
                                               .Select(n => new Vertex<int>(n))
                                               .ToArray();
            var dfs = new DFS(graph, graph.First());
            dfs.ToArray().Should().Equal(graph[0]);
        }

        [TestMethod]
        public void DFS_Should_Traverse_Reversed_Two_Node_Tree()
        {
            var graph = Enumerable.Range(0, 2)
                                  .Select(n => new Vertex<int>(n))
                                  .ToArray();
            graph[0].Connect(graph[1]);
            graph[1].Connect(graph[0]);

            var dfs = new DFS(graph, graph[0]);
            dfs.ToArray().Should().Equal(graph[0], graph[1]);
        }

        [TestMethod, Ignore]
        public void DFS_Should_Traverse_Rhomb_Graph()
        {
            var graph = Enumerable.Range(0, 4)
                                               .Select(n => new Vertex<int>(n))
                                               .ToArray();
            graph[0].Connect(graph[1]);
            graph[0].Connect(graph[2]);
            graph[1].Connect(graph[3]);
            graph[2].Connect(graph[3]);

            var dfs = new DFS(graph, graph.First()).ToArray();

            Array.IndexOf(dfs, graph[0]).Should().BeLessThan(Array.IndexOf(dfs, graph[1]), "vertex 0 should go before vertex 1");
            Array.IndexOf(dfs, graph[0]).Should().BeLessThan(Array.IndexOf(dfs, graph[2]), "vertex 0 should go before vertex 2");
            Array.IndexOf(dfs, graph[1]).Should().BeLessThan(Array.IndexOf(dfs, graph[3]), "vertex 1 should go before vertex 3");
            Array.IndexOf(dfs, graph[2]).Should().BeLessThan(Array.IndexOf(dfs, graph[3]), "vertex 2 should go before vertex 3");
        }
    }
}
