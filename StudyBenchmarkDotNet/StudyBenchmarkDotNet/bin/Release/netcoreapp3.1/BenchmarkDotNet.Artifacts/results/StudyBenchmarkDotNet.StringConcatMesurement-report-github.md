``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.867 (2004/?/20H1)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.402
  [Host]   : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  ShortRun : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|            Method |           Mean |          Error |        StdDev |            Min |            Max |
|------------------ |---------------:|---------------:|--------------:|---------------:|---------------:|
| WithStringBuilder |       827.2 μs |       649.5 μs |      35.60 μs |       791.3 μs |       862.5 μs |
|    WithStringType | 5,169,725.8 μs | 4,322,696.1 μs | 236,941.56 μs | 5,016,563.8 μs | 5,442,641.6 μs |
