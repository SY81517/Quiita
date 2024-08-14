using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTarget
{
    public class Foo
    {
        public bool Hoge(int a, int b)
        {
            if (a >= 0)
            {
                if (b >= 0) return true;
                Console.WriteLine("PASS1");
                return false;
            }
            Console.WriteLine("PASS2");
            return false;
        }
    }
}
