``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.867 (2004/?/20H1)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.402
  [Host]     : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  DefaultJob : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT


```
|                          Method |     Mean |    Error |   StdDev |    Gen 0 |    Gen 1 |   Gen 2 |  Allocated |
|-------------------------------- |---------:|---------:|---------:|---------:|---------:|--------:|-----------:|
| ConcatStringsUsingStringBuilder | 865.3 μs | 15.59 μs | 19.15 μs | 299.8047 | 197.2656 | 99.6094 | 1484.26 KB |
|    ConcatStringUsingGenericList | 669.0 μs | 13.17 μs | 12.32 μs | 157.2266 |  78.1250 |       - |  937.21 KB |
