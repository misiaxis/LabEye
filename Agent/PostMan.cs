using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Agent
{

    //Class handling sending and eventually receiving data between agent and database
    class PostMan
    {
        /// <summary>
        /// Sending alert list (update) in database.
        /// </summary>
        /// <param name="messages">List of strings, contains alert names.</param>
        /// <param name="listName">Name of parameter in documents (Workstations, DBEntity) where to update. </param>
        static public void SendMessanges(List<Tuple<string, ObjectId, ObjectId, ObjectId>> messages, string listName)
        {
            try
            {
                DbManager manager = new DbManager();
                var collection = manager.ShowWorkstationsCollection();
                if (manager.CheckIfExsists(StationInformation.WorkstationName))
                {
                    List<Alerts> messagesToInsert = new List<Alerts>();
                    foreach (var l in collection)
                    {
                        if (l.WorkstationName == StationInformation.WorkstationName)
                            messagesToInsert.AddRange(l.Alerts);
                    }
                    foreach (var msg in messages)
                    {
                        Alerts alert = new Alerts()
                        {
                            AddDate = DateTime.Now.ToString(),
                            StudentFirstAndLastName = StationInformation.StudentFirstAndLastName,
                            AlertName = msg.Item1,
                            Link1 = msg.Item2,
                            Link2 = msg.Item3,
                            Link3 = msg.Item4
                        };
                        messagesToInsert.Add(alert);
                    }
                    manager.UpdateOneList(listName, messagesToInsert, StationInformation.WorkstationName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Wystąpił błąd z połączaniem z bazą danych. Treść błedu: /n /n" + ex);
            }

        }

        /// <summary>
        /// Sending process list (update) in database.
        /// </summary>
        /// <param name="processList">List of strings, contains processes names.</param>
        static public void SendProcessList(List<string> processList)
        {
            try
            {
                DbManager manager = new DbManager();
                if (manager.CheckIfExsists(StationInformation.WorkstationName))
                    manager.UpdateOneList("Apps", processList, StationInformation.WorkstationName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd z połączaniem z bazą danych. Treść błedu: /n /n" + ex);
            }
        }
    }
}
