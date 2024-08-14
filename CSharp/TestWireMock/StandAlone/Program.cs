using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireMock.Exceptions;
using WireMock.Server;

namespace StandAlone
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var server = WireMockServer.Start(80);

            }
            catch (WireMockException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
