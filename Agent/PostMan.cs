using System;
using System.Collections.Generic;

namespace Agent
{

    //Class handling sending and eventually receiving data between agent and database
    class PostMan
    {
        static public void SendMessanges(List<string> messanges, string listName)
        {
            var SendFrom = StationInformation.StudentFirstAndLastName;

            DbManager manager = new DbManager();
            var collection = manager.ShowWorkstationsCollection();
            List<Alerts> messanges2 = new List<Alerts>();
            foreach (var l in collection)
            {
                messanges2.AddRange(l.Alerts);
            }
            foreach (var msg in messanges)
            {
                Alerts alert = new Alerts()
                {
                    AddDate = "wer",//DateTime.Now,
                    StudentFirstAndLastName = SendFrom,
                    AlertName = msg,
                    Link1 = "toDO",
                    Link2 = "toDo",
                    Link3 = "toDo"
                };

                messanges2.Add(alert);
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
