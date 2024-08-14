using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace WebClient
{
    class Program
    {
        static void Main( string[] args )
        {
            var client = new WebApiClient();
            Console.WriteLine("=== GetProduct id=1 ===");
            client.GetProduct(id:1);
            Console.WriteLine();
            Console.WriteLine("=== GetAllProduct ===");
            client.GetAllProducts();
            Console.WriteLine();
            Console.WriteLine("=== PutProduct ===");
            var product = new Product()
            {
                Id = 4,
                Name = "Tomato",
                Category = "Vegetable",
                Price = 1.01M
            };
            client.PutProduct(product);

            Console.WriteLine("=== GetAllProduct ===");
            client.GetAllProducts();
        }
    }

    public class WebApiClient
    {
        static readonly HttpClient Client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:59320/api/")
        };

        /// <summary>
        /// 製品情報をすべて取得する
        /// </summary>
        public void GetAllProducts()
        {
            var response = Client.GetAsync("products").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.WriteLine(responseBody);
        }

        /// <summary>
        /// 指定IDの製品情報を取得する
        /// </summary>
        /// <param name="id">識別子</param>
        public void GetProduct(int id)
        {
            var response = Client.GetAsync($"products/{id}").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.WriteLine(responseBody);
        }

        /// <summary>
        /// 製品情報の更新
        /// </summary>
        /// <param name="product">更新する製品の情報</param>
        public void PutProduct(Product product)
        {
            var jsonString = JsonConvert.SerializeObject(product);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = Client.PutAsync("products",content).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
        }
    }

    /// <summary>
    /// 製品
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 価格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// カテゴリー
        /// </summary>
        public string Category { get; set; }
    }

}
