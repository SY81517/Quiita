using System;
using System.Text.RegularExpressions;

namespace TestRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            // String.Replace
            Console.WriteLine("吾輩は猫である。吾輩は猫でもある".Replace("猫","子犬"));
            // Regex.Replace
            Console.WriteLine(Regex.Replace("吾輩は猫である。吾輩は猫でもある","猫","子犬"));
            // 一致した部分文字列全体を表す
            Console.WriteLine(Regex.Replace("吾輩は猫である。吾輩は子犬でもある。",".+?。","「$&」"));
            // 一致したグループ全体を表す
            Console.WriteLine(Regex.Replace("www.foo.comとftp.foo.comは置換し、mail.foo.comは置換しない",
                @"(www|ftp)\.foo\.","$1.bar"));

            var arg = 3;
            var str = "test {arg}";
            str = str.Replace("{arg}", arg.ToString());
            Console.WriteLine(str);
        }
    }
}