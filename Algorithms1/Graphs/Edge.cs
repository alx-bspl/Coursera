using System.Runtime.InteropServices;
using Algorithms1.Attributes;

namespace Algorithms1.Graphs
{
    [Immutable]
    public sealed class Edge
    {
        public Edge(Vertex vertex1, Vertex vertex2)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }

        public Vertex Vertex1 { get; }

        public Vertex Vertex2 { get; }
    }
}
