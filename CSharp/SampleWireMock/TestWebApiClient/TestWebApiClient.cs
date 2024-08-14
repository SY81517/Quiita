using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace TestWebApiClient
{
    [TestFixture]
    public class Tests
    {
        private  WireMockServer _mockServer;
        [SetUp]
        public void StartMockServer()
        {
            _mockServer = WireMockServer.Start();
        }
        [Test]
        public async Task TestHelloWorld()
        {
            const string expected = @"{ ""msg"": ""Hello world!"" }";
            _mockServer
                .Given(Request.Create().WithPath("/foo").UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBody(expected));
            var url = $"{_mockServer.Urls[0]}/foo";
            //use a HttpClient which connects to the URL where WireMock.Net is running)
            var response = await new HttpClient().GetAsync(url);
            Assert.AreEqual(expected, response);
        }

        [TearDown]
        public void ShutdownServer()
        {
            _mockServer.Stop();
        }
    }
}