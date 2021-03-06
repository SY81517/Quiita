using System.Threading.Tasks;
using BenchmarkDotNet.Running;
namespace BenchMark
{
    class Program
    {
        static void Main(string[] args)
        {
            //CheckOperation().GetAwaiter().GetResult();
            
            //計測を開始する
            BenchmarkRunner.Run<WebApiClient>();
        }

        /// <summary>
        /// ベンチマーク測定前の動作確認用
        /// </summary>
        static async Task CheckOperation()
        {
            var client = new WebApiClient();
            client.GlobalSetUp();
            await client.GetAsync();
            await client.PutAsync();
            await client.PostAsync();
            await client.DeleteAsync();
        }
    }
}