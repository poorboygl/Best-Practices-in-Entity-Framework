using BenchmarkDotNet.Attributes;

namespace BenchmarkDemo;

public class MyBenchmarks
{
    private List<int> numbers;

    [GlobalSetup]
    public void Setup()
    {
        numbers = Enumerable.Range(1, 1000).ToList();
    }

    [Benchmark]
    public int SumWithLinq()
    {
        return numbers.Sum();
    }

    [Benchmark]
    public int SumWithForLoop()
    {
        int sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
}

/*
What Is BenchmarkDotNet?
BenchmarkDotNet is an open-source benchmarking library for .NET that allows developers to write simple benchmarking methods to measure performance metrics like execution time, memory usage, and throughput. The library is widely used in the .NET community due to its accuracy and ease of use.   

[GlobalSetup]: This attribute is used to set up any data or state needed for the benchmarks.

[Benchmark]: Methods marked with this attribute will be benchmarked.
 */