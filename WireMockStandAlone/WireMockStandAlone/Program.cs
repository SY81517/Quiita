using System;
using System.Net;
using WireMock.Exceptions;
using WireMock.Logging;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace WireMockStandAlone
{
    class Program
    {
        static void Main( string[] args )
        {
            // WireMockServerは、IDisposableを継承している。リソース解放の構文としてusingを使用できるが、try-finallyで記述する。
            // 理由は、終了処理に非同期処理が含まれているためである。STOP()は非同期処理の完了を待つが、Dispose()は完了を待たない。
            WireMockServer server = null;
            try
            {
                var port = 8080;
                server = WireMockServer.Start(
                    new WireMockServerSettings()
                    {
                        Port = port,
                        Logger = new WireMockConsoleLogger()
                    });
                Console.WriteLine($"{nameof(WireMockServer)} Running at {nameof(port)} : {port}");
                const string expected = @"{ ""msg"": ""Hello world!"" }";
                server 
                    .Given(Request.Create().WithPath("/foo").UsingGet())
                    .RespondWith(
                        Response.Create()
                            .WithStatusCode(HttpStatusCode.OK)
                            .WithHeader("Content-Type", "application/json")
                            .WithBody(expected)
                            .WithDelay(TimeSpan.FromSeconds(1)));

                Console.WriteLine("Press any key to stop...");
                Console.ReadKey(true);
            }
            catch (WireMockException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                server?.Stop();
            }
        }
    }
}
