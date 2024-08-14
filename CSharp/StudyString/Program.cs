using System;

namespace StudyString
{
    internal class Program
    {
        public static void Main()
        {
            var plusResult = PlusOperator("Yamamoto");
            var formatResult= StringFormat("Yamamoto");
            var  interpolated = Interpolated("Yamamoto");
        }
        /// <summary>
        /// 演算子結合
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static string PlusOperator(string arg)
        {
            return "Hello" + arg + "World";
        }
        /// <summary>
        /// StringFormat
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static string StringFormat(string arg)
        {
            return string.Format("Hello{0}World",arg);
        }
        /// <summary>
        /// 文字列補間
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static string Interpolated(string arg)
        {
          return  $"Hello{arg}World";
        }
    }
}