using System.Threading.Tasks;

namespace HttpClientConsole
{
    class Program
    {
        static async  Task Main( string[] args )
        {
            var valueApi = new WebApiClient();
            await valueApi.GetAsync();
            //await valueApi.PutAsync();
            //await valueApi.PostAsync();
            //await valueApi.DeleteAsync();
        }
    }
}
