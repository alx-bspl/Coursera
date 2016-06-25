from structures import UnionFind
from collections import deque

class UnionFindPC(UnionFind):
    def __init__(self, items):
        return super().__init__(items)

    def _find(self, item):
        block = self.blocks[item]
        path = deque()
        while block[1] != block:
            path.append(block)
            block = block[1]
        for bl in path: bl[1] = block
        return block
