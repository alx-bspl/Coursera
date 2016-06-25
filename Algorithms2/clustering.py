from sys import argv
from io import open
from collections import deque, defaultdict
from structures import UnionFind, UnionFindPC

class DistDict(dict):
    def __getitem__(self, k):
        p1, p2 = k
        get = super(DistDict, self).get
        val = get((p1,p2)) or get((p2,p1))
        if val == None: raise KeyError()
        return val

def read(file_name):
    graph = defaultdict(lambda: [])
    with open(file_name, 'r') as lines:

        n, k = map(int, next(lines).split())

        for i in range(n * (n - 1) // 2):
            node1, node2, cost = map(int, next(lines).split())

            graph[node1].append((node1, node2, cost))
            graph[node2].append((node2, node1, cost))

    return graph, k

def clusterize(graph, k):
    distances = deque(sorted((edge 
                              for edges in graph.values()
                              for edge in edges
                              if id(edge[0]) < id(edge[1])),
                             key = lambda edge: edge[2]))

    uf, counter = UnionFind(graph.keys()), len(graph)
    while counter != k:
        node1, node2, dist = distances.popleft()
        if uf.union(node1, node2):
            counter -= 1

    return uf, [(node1, node2, cost) for node1, node2, cost in distances if uf.find(node1) != uf.find(node2)]

graph, k = read(argv[1])
uf, distances = clusterize(graph, k)
print (distances[0][2])
