from sys import argv
from io import open
from structures import UnionFind, UnionFindPC
from collections import deque

def read(file_name):
    nodes = set()
    with open(file_name, 'r') as lines:
        n, b = map(int, next(lines).split())
        for i in range(n):
            line = next(lines).replace(' ', '')
            node = int(line, base = 2)
            nodes.add(node)
    return nodes, b

def change_bits2(number, blen):
    yield number # change 0 bits

    for i in range(0, blen): # change 1 bit
        yield number ^ (1 << i)

    for i1 in range(1, blen): # change 2 bits
        for i2 in range(0, i1):
            yield number ^ (1 << i1) ^ (1 << i2)

def count_clusters2(nodes, blen):
    uf = UnionFindPC(nodes)
    counter = len(nodes)
    current, total = 0, len(nodes)
    for node in nodes:
        for similar in change_bits2(node, blen):
            if similar in nodes:
                if uf.union(node, similar):
                    counter -= 1

        current += 1
        print ('{0} / {1}'.format(current, total))

    return counter

nodes, blen = read(argv[1])
print (count_clusters2(nodes, blen))
