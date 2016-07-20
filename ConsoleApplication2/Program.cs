using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new KeyValuePair<int,string>(5, " ");
            var y = new KeyValuePair<int, string>(5, "zxc");

            var a = x.GetHashCode();
            var b = y.GetHashCode();
            
        }
    }
}
