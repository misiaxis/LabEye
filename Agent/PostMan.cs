using System;
using System.Collections.Generic;

namespace Agent
{

    //Class handling sending and eventually receiving data between agent and database
    class PostMan
    {
        static public void SendMessanges(List<string> messanges)
        {
            var SendFrom = StationInformation.HostName;
            DbManager manager = new DbManager();
            manager.UpdateOneList("Alerts", messanges, SendFrom);
        }
        static public void SendProcessList(List<string> processList)
        {
            var SendFrom = StationInformation.HostName;
            DbManager manager = new DbManager();
            manager.UpdateOneList("Apps", processList, SendFrom);
        }
        static public void RefreshBlackList()
        {
            throw new NotImplementedException();
        }
    }
}
