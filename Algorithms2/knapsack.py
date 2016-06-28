from sys import argv, setrecursionlimit
from io import open
from collections import namedtuple

# remove
from time import time
# remove

Item = namedtuple('Item', 'value weight')

def read(file_name):
    items = []
    with open(file_name, 'r') as lines:
        W, n = map(int, next(lines).split())
        for i in range(n):
            value, weight = map(int, next(lines).split())
            items.append(Item(value = value, weight = weight))
    return items, W

def knapsack(items, W):
    items.sort(key = lambda item: (item.weight, -item.value))
    
    max_w = 0

    def dp(i = 0, w = W, memo = [{} for x in range(len(items))]):
        if i == len(items): return 0

        item = items[i]
        if item.weight > w: return 0
        if item.weight == w: return item.value

        if w in memo[i]: return memo[i][w]

        with_i = item.value + dp(i + 1, w - item.weight)
        without_i = dp(i + 1, w)

        value = max(with_i, without_i)

        # remove
        nonlocal max_w
        if w > max_w:
            max_w = w
            print (max_w)
        # remove

        memo[i][w] = value
        return value

    return dp()

# remove
start = time()
# remove

items, W = read(argv[1])
setrecursionlimit(len(items) + 100)
max_val = knapsack(items, W)
print()
print(max_val)

# remove
print(time() - start)
# remove