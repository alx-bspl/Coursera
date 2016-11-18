using System.Collections.Generic;
using System.Linq;

namespace Algorithms1.Graphs
{
    public static class VerticesExtensions
    {
        public static void Reverse(this Vertex[] vertices)
        {
            var edges = new List<Edge>();

            foreach (var vertex in vertices.AsParallel())
            {
                edges.AddRange(vertex.Edges.Select(edge => new Edge(edge.Vertex2, edge.Vertex1)));
                vertex.Edges.Clear();
                vertex.Successors.Clear();
            }

            foreach (var edge in edges)
            {
                edge.Vertex1.Connect(edge.Vertex2);
            }
        }
    }
}