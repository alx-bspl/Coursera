using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms1.Graphs
{
    public struct DFS: IEnumerable<Vertex>
    {
        private readonly Vertex[] _vertices;

        private readonly Vertex _startVertex;

        private readonly HashSet<Vertex> _state;

        private readonly Stack<Vertex> _stack;

        private DFS(Vertex[] vertices,
            Vertex startVertex,
            HashSet<Vertex> state,
            Stack<Vertex> stack)
        {
            _vertices = vertices;
            _startVertex = startVertex;
            _state = state;
            _stack = stack;
        }

        public DFS(Vertex[] vertices,
            Vertex startVertex): this(vertices, startVertex, new HashSet<Vertex>(vertices), new Stack<Vertex>(vertices.Length))
        {
            _state.Clear();
        }

        internal IEnumerable<Vertex> Explore(Vertex vertex, HashSet<Vertex> state)
        {
            _stack.Push(vertex);
            while (_stack.Count != 0)
            {
                vertex = _stack.Pop();
                if (state.Contains(vertex))
                    continue;

                state.Add(vertex);
                yield return vertex;

                foreach (var successor in vertex.Successors)
                {
                    _stack.Push(successor);
                }
            }
        }

        internal IEnumerable<Vertex> Explore<TValue>(Vertex vertex, Dictionary<Vertex, TValue> state)
        {
            _stack.Push(vertex);
            while (_stack.Count != 0)
            {
                vertex = _stack.Pop();
                if (state.ContainsKey(vertex))
                    continue;

                state.Add(vertex, default(TValue));
                yield return vertex;

                foreach (var successor in vertex.Successors)
                {
                    _stack.Push(successor);
                }
            }
        }

        public IEnumerator<Vertex> GetEnumerator()
        {
            return _vertices.Length == 0
                       ? Enumerable.Empty<Vertex>().GetEnumerator()
                       : Explore(_startVertex, _state).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}