using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algorithms1.Graphs
{
    public sealed class KosarajusAlgorithm
    {
        private Dictionary<Vertex, uint> ComputeFinishingTimes(Vertex[] graph)
        {
            graph.Reverse();

            var finishingTimes = new Dictionary<Vertex, uint>(graph.Length);
            var time = 0U;

            var dfs = new DFS(graph, null);
            foreach (var vertex in graph)
            {
                if (finishingTimes.ContainsKey(vertex))
                    continue;

                foreach (var finishVertex in dfs.Explore(vertex, finishingTimes).Reverse())
                    finishingTimes[finishVertex] = time++;
            }

            graph.Reverse();

            return finishingTimes;
        }

        public IEnumerable<Vertex[]> ComputeStrongConnectedComponents(Vertex[] graph)
        {
            var exploringState = new HashSet<Vertex>();
            var finishingTimes = ComputeFinishingTimes(graph);
            var dfs = new DFS(graph, null);
            foreach (var vertex in finishingTimes
                .OrderByDescending(pair => pair.Value)
                .Select(pair => pair.Key))
            {
                var component = dfs.Explore(vertex, exploringState).ToArray();
                if (component.Length != 0)
                    yield return component;
            }
        }
    }
}