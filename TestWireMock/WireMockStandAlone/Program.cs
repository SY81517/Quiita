using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireMock.Net.StandAlone;

namespace WireMockStandAlone
{
    class Program
    {
        static void Main( string[] args )
        {
            
            StandAloneApp.Start(args);
            Console.WriteLine("Press any key to stop the server");
            Console.ReadKey();
        }
    }
}
