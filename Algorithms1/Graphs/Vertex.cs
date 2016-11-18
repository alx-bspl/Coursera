using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Algorithms1.Graphs
{
    public abstract class Vertex: ICloneable
    {
        public List<Edge> Edges { get; } = new List<Edge>();

        public List<Vertex> Successors { get; } = new List<Vertex>();

        protected Vertex()
        {
            
        }

        public void Connect(Vertex vertex)
        {
            Edges.Add(new Edge(this, vertex));
            Successors.Add(vertex);
        }

        public abstract Vertex Clone();

        object ICloneable.Clone()
        {
            return Clone();
        }
    }

    public class Vertex<TData>: Vertex
    {
        public TData Data { get; }

        public Vertex(TData data)
        {
            Data = data;
        }

        public static implicit operator Vertex<TData>(TData data)
        {
            return new Vertex<TData>(data);
        }

        public override string ToString()
        {
            return string.Format("<{0}>", Data.ToString());
        }

        public override Vertex Clone()
        {
            return new Vertex<TData>(Data);
        }
    }
}