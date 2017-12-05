# AdventOfCode2017FSharp
My solutions for the advent of code 2017 in FSharp

# Day1

See source in Day01.fsx

## Part I
Naive solution would be to iterate through list and compare the value with the next one. There is an exception when you come to the end of the list is to load first element.
For that we use Seq.pairwise which already provides pair sequence generation. Example on (1, 2, 3, 4) will generate ((1, 2), (2, 3), (3, 4)). With that in mind the problme is almost solved. Only the exception is not handled. I've decided that if I put a copy of the first element at the end I would get what I need. So on example I would have sequence (1, 2, 3, 4, 1) which will generate additional pair ((1, 2), (2, 3), (3, 4), (4, 1)). I achieve that by calling Seq.append. 

The rest of the solution is to do the logic. For that I have method digitize int -> int -> int which returns 0 if the input parameters are not the same and value if the values are the same.

Such solution provides a minimal memory requirements (first value and a pair to digitize it).

## Part II
In part two the solution is very easy but is memory more needy. The sequence must be cut to half and zip the sequences to pairs. Example on (1, 2, 3, 4) will generate ((1, 3), (2, 4)). Because the task is to be circular the missing pairs are ((3, 1), (4, 2)) which are the exactly reversed of the first two. So instead of doing special logic for this we just duplicate result from the first pairs.