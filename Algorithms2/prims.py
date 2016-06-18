from sys import argv
from io import open
from collections import deque, defaultdict
from heapq import heappush, heappop

class Edge:
    def __init__(self, source, dest, cost):
        self.source, self.dest = source, dest
        self.cost = cost

class Node:
    def __init__(self): self.edges = deque()

def calc_prims_mst_cost(graph):
    cost = 0

    start = next(graph.itervalues())
    queue = [(0, start)]
    tree_nodes = set()
    while queue:
        source_cost, source = heappop(queue)
        if source in tree_nodes: continue
        tree_nodes.add(source)
        cost += source_cost

        for edge in source.edges:
            dest = edge.dest
            heappush(queue, (edge.cost, dest))

    return cost

graph = defaultdict(lambda: Node())
with open(argv[1], 'r') as lines:

    n, e = map(int, next(lines).split())
    for i in xrange(e):

        n1, n2, cost = map(int, next(lines).split())
        node1, node2 = graph[n1], graph[n2]
        edge = Edge(node1, node2, cost)

        node1.edges.append(Edge(node1, node2, cost))
        node2.edges.append(Edge(node2, node1, cost))

cost = calc_prims_mst_cost(graph)
print cost