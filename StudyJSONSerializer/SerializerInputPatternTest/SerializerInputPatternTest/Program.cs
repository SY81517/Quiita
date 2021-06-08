using System;
using Newtonsoft.Json;

namespace SerializerInputPatternTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            InputNull_Serializer();
            InputEmpty_Serializer();
        }

        public static void InputNull_Serializer()
        {
            //"null"文字列
            var jsonString = JsonConvert.SerializeObject(null);
            Console.WriteLine(jsonString);
            // object is null
            var objDeserializeObject = JsonConvert.DeserializeObject<Product>(jsonString);
            if (objDeserializeObject is null)
            {
                //通る
                Console.WriteLine("objDeserializeObject is Null");
            }
        }
        
        
        public static void InputEmpty_Serializer()
        {
            //空文字列""にエスケープ""が付き、
            var jsonString = JsonConvert.SerializeObject(string.Empty);
            Console.WriteLine(jsonString);
            //空文字列 => nullに変換される
            var objDeserializeObject = JsonConvert.DeserializeObject<Product>(jsonString);
            if (objDeserializeObject is null)
            {
                //通る
                Console.WriteLine("objDeserializeObject is Null");
            }
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
    }
}