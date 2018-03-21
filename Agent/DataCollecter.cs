using System.Collections.Generic;
using System.Threading;

namespace Agent
{
    //Class for getting datas and sending it to database
    class DataCollecter
    {
        public void Run()
        {
            List<string> dnsBlackList=new List<string>(); //In final verision should be from database

            DNSwatcher.DNSwatcher dnsWatcher=new DNSwatcher.DNSwatcher(dnsBlackList);

            while (true)
            {
                //Collecting and sending here

                var dnsWatcherMessanges = dnsWatcher.Checkblacklist();
                if (dnsWatcherMessanges != null) PostMan.SendMessanges(dnsWatcherMessanges);

                Thread.Sleep(1000);
            }
        }
    }
}
