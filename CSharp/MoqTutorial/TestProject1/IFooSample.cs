using System;
namespace MoqTutorial
{
    /// <summary>
    /// 評価対象クラスのインターフェース
    /// 参考
    /// https://github.com/Moq/moq4/wiki/Quickstart
    /// </summary>
    public interface IFooSample
    { 
        bool DoSomething(string value);
    }
    /// <summary>
    /// 評価対象クラス
    /// </summary>
    public class FooSample : IFooSample
    {
        private readonly IFooSample _ifooSampleObject;
        /// <summary>
        /// コンストラクタ・インジェクション
        /// </summary>
        /// <param name="iObject"></param>
        public FooSample(IFooSample iObject)
        {
            _ifooSampleObject = iObject;
        }
        public bool DoSomething(string value)
        {
            var result = _ifooSampleObject.DoSomething(value);
            //結果に応じた処理を記載する
            if (result)
            {
                Console.WriteLine("成功時の処理を書く");
            }
            else
            {
                Console.WriteLine("成功時の処理を書く");
            }
            return result;
        }
    }
}