using System;
using Newtonsoft.Json
namespace NewtonJson
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    public class JsonConvertSample
    {
        /// <summary>
        /// JsonConverterを用いたシリアル化 <see href="https://www.newtonsoft.com/json/help/html/SerializingJSON.htm">HERE</see>
        /// </summary>
        public void Serializing()
        {
            
        }
        
    }

    public class Product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
        public string[] Sizes { get; set; }
    }
}