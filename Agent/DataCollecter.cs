using Prowadzacy_App;
using System.Collections.Generic;
using System.Threading;

namespace Agent
{
    //Class for getting datas and sending it to database
    class DataCollecter
    {
        public void Run()
        {
            DbManager manager = new DbManager();

            DNSwatcher.DNSwatcher dnsWatcher = new DNSwatcher.DNSwatcher(null);
            AplicationWatcher.AplicationWatcher aplicationWatcher = new AplicationWatcher.AplicationWatcher(null);
            
            while (true)
            {
                //Collecting and sending here
                manager.RefreshWorkstations();
                foreach (BlackList l in manager.ShowBlackListCollection())
                {
                    dnsWatcher = new DNSwatcher.DNSwatcher(l.Alerts);
                    aplicationWatcher = new AplicationWatcher.AplicationWatcher(l.Apps);
                }

                //Collecting messanges about dns
                var dnsWatcherMessanges = dnsWatcher.CheckDnsTableWithBlackList();
                if (dnsWatcherMessanges != null) PostMan.SendMessanges(dnsWatcherMessanges);


                //Collecting messanges about apps
                var appWatcherMessanges = aplicationWatcher.CheckAplicationListWithBlackList();
                if (appWatcherMessanges != null) PostMan.SendMessanges(appWatcherMessanges);

                if (manager.CheckIfExsists(StationInformation.WorkstationName, StationInformation.Username))
                {
                    manager.UpdateOne("StudentFirstAndLastName", StationInformation.Username, StationInformation.WorkstationName);
                }
                else
                {
                    manager.WorkstaionsMakeNew(StationInformation.WorkstationName, 
                        StationInformation.StudentFirstAndLastName,
                        StationInformation.HostName, 
                        StationInformation.IpAdress, 
                        StationInformation.Username, dnsWatcherMessanges, dnsWatcherMessanges);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
