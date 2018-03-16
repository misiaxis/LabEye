using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSwatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            DNSwatcher dnsWatcher=new DNSwatcher(true);
            dnsWatcher.debug();
            Console.ReadLine();
        }
    }
}
