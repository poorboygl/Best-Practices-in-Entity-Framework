```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7309/25H2/2025Update/HudsonValley2)
Intel Core i9-9900K CPU 3.60GHz (Coffee Lake), 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.306
  [Host]     : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v3


```
| Method         | Mean      | Error    | StdDev   |
|--------------- |----------:|---------:|---------:|
| SumWithLinq    |  67.01 ns | 0.260 ns | 0.230 ns |
| SumWithForLoop | 408.47 ns | 0.385 ns | 0.322 ns |
