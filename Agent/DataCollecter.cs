using System.Collections.Generic;
using System.Threading;

namespace Agent
{
    /// <summary>
    /// Interaction logic for DataCollector.cs
    /// </summary>
    class DataCollector
    {
        DbManager manager = new DbManager();
        DNSwatcher dnsWatcher = new DNSwatcher();
        ApplicationWatcher appWatcher = new ApplicationWatcher();

        /// <summary>
        /// Thread for checking processes and DNS.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                foreach(BlackList l in manager.ShowBlackListCollection() )
                {
                    dnsWatcher.blackList = l.Websites;
                    appWatcher.blackList = l.Apps;
                }

                //Collecting messanges about dns
                var dnsWatcherMessanges = dnsWatcher.CheckDnsTableWithBlackList();
                if (dnsWatcherMessanges != null) PostMan.SendMessanges(dnsWatcherMessanges, "Alerts");

                //Collecting messages about apps
                var appWatcherMessanges = appWatcher.CheckApplicationListWithBlackList();
                if (appWatcherMessanges != null) PostMan.SendMessanges(appWatcherMessanges, "Alerts");

                //Collecting all running processes
                var applist = appWatcher.GetRunningApplications();
                if (applist != null) PostMan.SendProcessList(applist);

                Thread.Sleep(100);
            }
        }
    }
}
