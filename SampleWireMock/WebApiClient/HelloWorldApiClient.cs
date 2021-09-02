using System;
using System.Net.Http;

namespace WebApiClient
{
    public class HelloWorldApiClient
    {
        static readonly HttpClient Client = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:59320/api")
        };
        
       public string GetMessage()
        {
            var response = Client.GetAsync("helloWorld").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
    }
}