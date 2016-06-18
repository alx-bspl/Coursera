from sys import argv
from io import open
from collections import namedtuple

Job = namedtuple('Job', 'weight length')

def shedule_by_difference(jobs):
    return sorted(jobs, key = lambda job: (job.weight - job.length, job.weight), reverse = True)

def shedule_by_ratio(jobs):
    return sorted(jobs, key = lambda job: (float(job.weight) / job.length), reverse = True)

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
        jobs.append(Job(*map(int, next(lines).split())))

by_diff = shedule_by_difference(jobs)
by_ratio = shedule_by_ratio(jobs)
print ('By difference:\t{0}\nBy ratio:\t{1}'.format(objective(by_diff), objective(by_ratio)))
