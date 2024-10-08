﻿using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

namespace BenchMark
{
    [HtmlExporter]//Htmlエクスポート
    public class WebApiClient
    {
        private static readonly HttpClient Client = new HttpClient();
        private static string _jsonString;
        private static StringContent _data;
        
        [GlobalSetup]//初回セットアップ
        public void GlobalSetUp()
        {
            _jsonString = JsonConvert.SerializeObject("TestMessage");
            _data = new StringContent(_jsonString, Encoding.UTF8, mediaType: "application/json");
        }
        
        [Benchmark]//計測対象のメソッドに指定
        public async Task GetAsync()
        {
            var response = await Client.GetAsync("http://localhost:19691/api/values");
            response.EnsureSuccessStatusCode();
        }

        [Benchmark]
        public async Task PutAsync()
        {
            var response = await Client.PutAsync("http://localhost:19691/api/values/5", _data);
            response.EnsureSuccessStatusCode();
        }
        
        [Benchmark]
        public async Task PostAsync()
        {
            var response = await Client.PostAsync("http://localhost:19691/api/values", _data);
            response.EnsureSuccessStatusCode();
        }
        
        [Benchmark]
        public async Task DeleteAsync()
        {
            var response = await Client.DeleteAsync("http://localhost:19691/api/values/5");
            response.EnsureSuccessStatusCode();
        }
    }
}