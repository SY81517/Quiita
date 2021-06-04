using System;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BenchMark
{
    public class WebApiClient
    {
        private static HttpClient Client = new HttpClient();

        public WebApiClient()
        {
            Client.BaseAddress = new Uri("http://localhost:19691/");
        }

        /// <summary>
        /// GETメソッドをコールする
        /// </summary>
        /// <returns></returns>
        public async Task GetAsync()
        {
            try
            {
                Console.WriteLine("Call GET api/values");
                var resource = await Client.GetAsync("api/values");
                resource.EnsureSuccessStatusCode();
                var responseBody = await resource.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("End");
        }


    }
}
