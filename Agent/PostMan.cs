using System;
using System.Collections.Generic;

namespace Agent
{

    //Class handling sending and eventually receiving data between agent and database
    class PostMan
    {
        static public void SendMessanges(List<string> messanges, string listName)
        {
            var SendFrom = StationInformation.WorkstationName; //WorkstationName ustawiłem dla testów ~Olo
            DbManager manager = new DbManager();
            var collection = manager.ShowWorkstationsCollection();
            List<string> messanges2 = new List<string>();
            foreach (var l in collection)
            {
                messanges2.AddRange(l.Alerts);
                messanges2.AddRange(messanges);
            }
            manager.UpdateOneList(listName, messanges2, SendFrom);
        }
        static public void SendProcessList(List<string> processList)
        {
            var SendFrom = StationInformation.WorkstationName;
            DbManager manager = new DbManager();
            manager.UpdateOneList("Apps", processList, SendFrom);
        }
        static public void RefreshBlackList()
        {
            throw new NotImplementedException();
        }
    }
}
