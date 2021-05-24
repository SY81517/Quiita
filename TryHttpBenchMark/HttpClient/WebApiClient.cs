using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientConsole
{
    /// <summary>
    /// Web APIクライアント
    /// </summary>
    public class WebApiClient
    {
        /// <summary>
        /// HTTPクライアント
        /// </summary>
        private static HttpClient Client = new HttpClient();

        /// <summary>
        /// コンストラクタ
        /// </summary>
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

        /// <summary>
        /// PUTメソッドをコールする
        /// </summary>
        /// <returns></returns>
        public async Task PutAsync()
        {
            try
            {
                Console.WriteLine("Call PUT api/values/5");
                var testInput = "TestMessage";
                var jsonString = JsonConvert.SerializeObject(testInput);
                var data = new StringContent(jsonString, Encoding.UTF8, mediaType: "application/json");
                var response = await Client.PutAsync("http://localhost:19691/api/values/5", data);
                response.EnsureSuccessStatusCode();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("End");
        }

        /// <summary>
        /// POSTメソッドをコールする
        /// </summary>
        /// <returns></returns>
        public async Task PostAsync()
        {
            try
            {
                Console.WriteLine("Call POST api/values");
                var testInput = "PostMessage";
                var jsonString = JsonConvert.SerializeObject(testInput);
                var data = new StringContent(jsonString, Encoding.UTF8, mediaType: "application/json");
                var response = await Client.PostAsync("http://localhost:19691/api/values", data);
                response.EnsureSuccessStatusCode();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("End");
        }
        /// <summary>
        /// DELETEメソッドをコールする
        /// </summary>
        /// <returns></returns>
        public async Task DeleteAsync()
        {
            try
            {
                //HTTP　DELETE要求を送信する
                Console.WriteLine("Call DELETE api/values/5");
                var response = await Client.DeleteAsync("http://localhost:19691/api/values/5");
                response.EnsureSuccessStatusCode();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("End");
        }
    }
}
