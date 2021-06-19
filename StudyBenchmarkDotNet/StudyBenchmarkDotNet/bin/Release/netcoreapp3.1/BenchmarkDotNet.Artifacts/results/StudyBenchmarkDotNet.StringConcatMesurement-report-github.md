``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300
  [Host]   : .NET Core 3.1.15 (CoreCLR 4.700.21.21202, CoreFX 4.700.21.21402), X64 RyuJIT
  ShortRun : .NET Core 3.1.15 (CoreCLR 4.700.21.21202, CoreFX 4.700.21.21402), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|            Method |           Mean |            Error |          StdDev |            Min |            Max |         Gen 0 |         Gen 1 |         Gen 2 |      Allocated |
|------------------ |---------------:|-----------------:|----------------:|---------------:|---------------:|--------------:|--------------:|--------------:|---------------:|
| WithStringBuilder |       832.3 μs |         19.89 μs |         1.09 μs |       831.2 μs |       833.3 μs |      125.0000 |      124.0234 |      124.0234 |      784.04 KB |
|    WithStringType | 7,617,142.9 μs | 24,224,317.12 μs | 1,327,816.56 μs | 6,459,032.1 μs | 9,066,360.0 μs | 11063000.0000 | 10494000.0000 | 10494000.0000 | 39067405.77 KB |
