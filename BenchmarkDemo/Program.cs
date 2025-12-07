using BenchmarkDemo;
using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<MyBenchmarks>();
    }
}

/*
*Step 1: Run the Application
Run the application using the dotnet run command:

dotnet run -c Release
Note: Always run benchmarks in the Release configuration to get accurate results. The Debug configuration may include optimizations and debug symbols that can distort performance measurements.

*Step 2: View the Results
Once the benchmark completes, BenchmarkDotNet will display a detailed table of results in your console. It typically includes metrics such as:

    Mean: Average execution time

    Error: Standard error of the measurements

    StdDev: Standard deviation

    Allocated: Memory allocated during the benchmark

Additional Tips
    Use Attributes: BenchmarkDotNet supports many attributes like [Params] for parameterized benchmarks and [MemoryDiagnoser] to include memory usage in the results.

    Analyze Overhead: Always be mindful of unnecessary overhead in your benchmarks. Keep methods focused and minimal.

    Export Results: BenchmarkDotNet supports exporting results to various formats like CSV, JSON, and Markdown for further analysis.

Conclusion
BenchmarkDotNet is a powerful and easy-to-use tool for measuring and optimizing .NET application performance. By following this guide, you can quickly set up and start benchmarking your code. Over time, BenchmarkDotNet will help you identify performance bottlenecks and make informed decisions about optimizing your application.  
 
 
 */