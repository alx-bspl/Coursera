class UnionFind(object):
    def __init__(self, items):
        self.blocks = {item: self._block(item) for item in items}
        
    def _block(self, item):
        block = [item, None, 0]
        block[1] = block
        return block

    def _find(self, item):
        block = self.blocks[item]
        while block[1] != block:
            block = block[1]
        return block

    def find(self, item):
        return self._find(item)[0]

    def union(self, item1, item2):
        leader1, leader2 = self._find(item1), self._find(item2)
        rank1, rank2 = leader1[2], leader2[2]

        if leader1 == leader2: return False

        if rank1 > rank2:
            leader2[1] = leader1
        else:
            leader1[1] = leader2
            if rank1 == rank2: leader2[2] += 1

        return True
