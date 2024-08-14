using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace TestWireMock
{
    public class Tests
    {
        private WireMockServer _mockServer;
        private static HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _mockServer = WireMockServer.Start();
            _client = new HttpClient();
        }

        [Test]
        public async Task MockHttpApi_Foo_CaseStatusOk()
        {
            // Arrange WireMock.Net serverの設定
            const string expected = @"{ ""msg"": ""Hello world!"" }";
            _mockServer
                .Given(Request.Create().WithPath("/foo").UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(HttpStatusCode.OK)
                        .WithHeader("Content-Type", "application/json")
                        .WithBody(expected));

            var port = _mockServer.Ports;
            // Act HTTPサーバーのURLにアクセスして、HTTP応答を取得する
            var response = await _client.GetAsync($"{_mockServer.Urls[0]}/foo");
            var result = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TearDown]
        public void ShutdownServer()
        {
            _mockServer.Stop();
        }
    }
}