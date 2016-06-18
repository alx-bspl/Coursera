from sys import argv
from io import open
from collections import namedtuple

Job = namedtuple('Job', 'weight length')

def shedule(jobs):
    return sorted(jobs, key = lambda job: (job.weight - job.length, job.weight), reverse = True)

def objective(schedule):
    res, c = 0, 0
    for job in schedule:
        c += job.length
        res += c * job.weight
    return res

jobs = []
with open(argv[1], 'r') as lines:
    n = int(next(lines))
    for i in xrange(n):
        vals = map(int, next(lines).split())
        jobs.append(Job(weight = vals[0], length = vals[1]))

scheduled = shedule(jobs)
res = objective(scheduled)
print (res)
