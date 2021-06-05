using System.Threading.Tasks;
using BenchmarkDotNet.Running;
namespace BenchMark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<WebApiClient>();
            //CheckOperation().GetAwaiter().GetResult();
        }

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