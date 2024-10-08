﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleWebApiClient
{
    class Program
    {

        static async Task Main( string[] args )
        {
            var valueApi = new WebApiClient();
            await valueApi.GetAsync();
            await valueApi.PutAsync();
            await valueApi.PostAsync();
            await valueApi.DeleteAsync();
        }
    }

    /// <summary>
    /// Web APIクライアント
    /// </summary>
    public class WebApiClient
    {
        /// <summary>
        /// HTTPクライアント
        /// </summary>
        /// <remarks>
        /// IDisposableを継承しているが、usingで囲わないこと
        /// 要求ごとにインスタンス化すると、ソケットが枯渇する懸念があるため、避けたほうが良い。
        /// 参考
        ///  下記の[HttpClientを作成して初期化する]を参照
        ///  https://docs.microsoft.com/ja-jp/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
        ///  InfoQでも言及されている
        ///  https://www.infoq.com/jp/news/2016/09/HttpClient/
        /// </remarks>
        private static HttpClient Client = new HttpClient();

        /// <summary>
        /// GETメソッドをコールする
        /// </summary>
        /// <returns></returns>
        public async Task GetAsync()
        {
            try
            {
                //HTTP　GET要求を送信する
                Console.WriteLine("Call GET api/values");
                var resource = await Client.GetAsync("http://localhost:19691/api/values");
                //ステータス異常の時に例外をスルーする
                resource.EnsureSuccessStatusCode();
                //HTTP応答を取得して表示する
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
                //HTTP　PUT要求を送信する
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
                //HTTP　POST要求を送信する
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
