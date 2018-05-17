using System.Collections.Generic;
using System.Threading;

namespace Agent
{
    //Class for getting datas and sending it to database
    class DataCollecter
    {
        DbManager manager = new DbManager();
        DNSwatcher dnsWatcher = new DNSwatcher();
        AplicationWatcher aplicationWatcher = new AplicationWatcher();
        public void Run()
        {
            while (true)
            {
                System.Console.WriteLine("watcher");
                foreach(BlackList l in manager.ShowBlackListCollection() )
                {
                    dnsWatcher.blackList = l.Websites;
                    aplicationWatcher.blackList = l.Apps;
                }
                 // do odkomentowania, troche dziwny sposob na dostarczenie nowych danych

                //tymczasowe, aby sprawdzic czy dziala.
                /*List<string> bl = new List<string>();
                bl.Add("Kalkulator ‎- Kalkulator");
                bl.Add("put.poznan.pl");
                dnsWatcher.blackList = bl;
                aplicationWatcher.blackList = bl;
                */

                //Collecting messanges about dns
                var dnsWatcherMessanges = dnsWatcher.CheckDnsTableWithBlackList();
                if (dnsWatcherMessanges != null) PostMan.SendMessanges(dnsWatcherMessanges, "Alerts");

                //Collecting messages about apps
                var appWatcherMessanges = aplicationWatcher.CheckAplicationListWithBlackList();
                if (appWatcherMessanges != null) PostMan.SendMessanges(appWatcherMessanges, "Alerts");

                //Collecting all running processes
                var applist = aplicationWatcher.GetRunningAplications();
                if (applist != null) PostMan.SendProcessList(applist);

                Thread.Sleep(100);
            }
        }
    }
}
