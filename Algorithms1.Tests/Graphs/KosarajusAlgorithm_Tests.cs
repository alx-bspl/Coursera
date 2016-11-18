using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms1.Graphs;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms1.Tests.Graphs
{
    [TestClass]
    public class DirectedGraphTest
    {
        private Vertex<TData> GetOrAddVertex<TData>(Dictionary<TData, Vertex<TData>> dataDictionary, TData data)
        {
            Vertex<TData> vertex;
            if (dataDictionary.ContainsKey(data))
            {
                vertex = dataDictionary[data];
            }
            else
            {
                vertex = new Vertex<TData>(data);
                dataDictionary.Add(data, vertex);
            }
            return vertex;
        }

        protected Vertex<int>[] ParseGraph(string graph)
        {
            var dataDictionary = new Dictionary<int, Vertex<int>>();

            using (var reader = new StringReader(graph))
            {
                string verticesString;
                while ((verticesString = reader.ReadLine()) != null)
                {
                    var vertices = verticesString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (vertices.Length != 2)
                        throw new FormatException("Graph string is invalid.");


                    var vertex1 = GetOrAddVertex(dataDictionary, int.Parse(vertices[0]));
                    var vertex2 = GetOrAddVertex(dataDictionary, int.Parse(vertices[1]));
                    vertex1.Connect(vertex2);
                }
            }

            return dataDictionary.Select(pair => pair.Value).ToArray();
        }
    }

    [TestClass]
    public class KosarajusAlgorithm_Tests: DirectedGraphTest
    {
        [TestMethod]
        public void ComputeStrongConnectedComponents_Should_Compute_Components_For_Graph1()
        {
            var graph = ParseGraph(
                string.Join("\n", 
                "1 4",
                "2 8",
                "3 6",
                "4 7",
                "5 2",
                "6 9",
                "7 1",
                "8 5",
                "8 6",
                "9 7",
                "9 3"));

            var components = new KosarajusAlgorithm().ComputeStrongConnectedComponents(graph).ToArray();

            components.Select(component => component.Length).OrderByDescending(i => i).Should().Equal(3, 3, 3);
        }

        [TestMethod]
        public void ComputeStrongConnectedComponents_Should_Compute_Components_For_Graph2()
        {
            var graph = ParseGraph(
                string.Join("\n",
                    "1 2",
                    "2 6",
                    "2 3",
                    "2 4",
                    "3 1",
                    "3 4",
                    "4 5",
                    "5 4",
                    "6 5",
                    "6 7",
                    "7 6",
                    "7 8",
                    "8 5",
                    "8 7"));

            var components = new KosarajusAlgorithm().ComputeStrongConnectedComponents(graph).ToArray();

            components.Select(component => component.Length).OrderByDescending(i => i).Should().Equal(3, 3, 2);
        }

        [TestMethod]
        public void ComputeStrongConnectedComponents_Should_Compute_Components_For_Graph3()
        {
            var graph = ParseGraph(
                string.Join("\n",
                    "1 2",
                    "2 3",
                    "3 1",
                    "3 4",
                    "5 4",
                    "6 4",
                    "8 6",
                    "6 7",
                    "7 8"));

            var components = new KosarajusAlgorithm().ComputeStrongConnectedComponents(graph).ToArray();

            components.Select(component => component.Length).OrderByDescending(i => i).Should().Equal(3, 3, 1, 1);
        }

        [TestMethod]
        public void ComputeStrongConnectedComponents_Should_Compute_Components_For_Graph4()
        {
            var graph = ParseGraph(
                string.Join("\n",
                    "1 2",
                    "2 3",
                    "3 1",
                    "3 4",
                    "5 4",
                    "6 4",
                    "8 6",
                    "6 7",
                    "7 8",
                    "4 3",
                    "4 6"));

            var components = new KosarajusAlgorithm().ComputeStrongConnectedComponents(graph).ToArray();

            components.Select(component => component.Length).OrderByDescending(i => i).Should().Equal(7, 1);
        }

        [TestMethod]
        public void ComputeStrongConnectedComponents_Should_Compute_Components_For_Graph5()
        {
            var graph = ParseGraph(
                string.Join("\n",
                    "1 2",
                    "2 3",
                    "2 4",
                    "2 5",
                    "3 6",
                    "4 5",
                    "4 7",
                    "5 2",
                    "5 6",
                    "5 7",
                    "6 3",
                    "6 8",
                    "7 8",
                    "7 10",
                    "8 7",
                    "9 7",
                    "10 9",
                    "10 11",
                    "11 12",
                    "12 10"));

            var components = new KosarajusAlgorithm().ComputeStrongConnectedComponents(graph).ToArray();

            components.Select(component => component.Length).OrderByDescending(i => i).Should().Equal(6, 3, 2, 1);
        }

        [TestMethod]
        public void ComputeStrongConnectedComponents_Should_Compute_Components_For_Graph6()
        {
            var graph = ParseGraph(
                string.Join("\n",
                    "1 2",
                    "2 1",
                    "3 4",
                    "4 3",
                    "4 1"));

            var components = new KosarajusAlgorithm().ComputeStrongConnectedComponents(graph).ToArray();

            components.Select(component => component.Length).OrderByDescending(i => i).Should().Equal(2, 2);
        }

        [TestMethod]
        public void ComputeStrongConnectedComponents_Should_Compute_Components_For_Graph7()
        {
            var graph = ParseGraph(
                string.Join("\n",
                    "1 2",
                    "2 4",
                    "4 5",
                    "5 3",
                    "3 4",
                    "3 1"));

            var components = new KosarajusAlgorithm().ComputeStrongConnectedComponents(graph).ToArray();

            components.Select(component => component.Length).OrderByDescending(i => i).Should().Equal(5);
        }

        [TestMethod]
        public void ComputeStrongConnectedComponents_Should_Compute_Components_For_Graph8()
        {
            var graph = ParseGraph(
                string.Join("\n",
                    "1 2",
                    "3 4"));

            var components = new KosarajusAlgorithm().ComputeStrongConnectedComponents(graph).ToArray();

            components.Select(component => component.Length).OrderByDescending(i => i).Should().Equal(1, 1, 1, 1);
        }

        [TestMethod]
        public void ComputeStrongConnectedComponents_Should_Compute_Components_For_Graph9()
        {
            var graph = ParseGraph(
                string.Join("\n",
                    "1 2",
                    "3 2"));

            var components = new KosarajusAlgorithm().ComputeStrongConnectedComponents(graph).ToArray();

            components.Select(component => component.Length).OrderByDescending(i => i).Should().Equal(1, 1, 1);
        }
    }
}