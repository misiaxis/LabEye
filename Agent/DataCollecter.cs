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
            List<string> appBlackList = new List<string>(); //In final verision should be from database

            DNSwatcher.DNSwatcher dnsWatcher=new DNSwatcher.DNSwatcher(dnsBlackList);

            AplicationWatcher.AplicationWatcher aplicationWatcher = new AplicationWatcher.AplicationWatcher(appBlackList);

            while (true)
            {
                //Collecting and sending here

                //Collecting messanges about dns
                var dnsWatcherMessanges = dnsWatcher.CheckDnsTableWithBlackList();
                if (dnsWatcherMessanges != null) PostMan.SendMessanges(dnsWatcherMessanges);


                //Collectiong messanges aboud apps
                var appWatcherMessanges = aplicationWatcher.CheckAplicationListWithBlackList();
                if (appWatcherMessanges != null) PostMan.SendMessanges(appWatcherMessanges);

                Thread.Sleep(1000);
            }
        }
    }
}
