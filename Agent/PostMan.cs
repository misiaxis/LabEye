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
        static public void SendMessanges(List<string> messages, string listName)
        {
            try
            {
                DbManager manager = new DbManager();
                var collection = manager.ShowWorkstationsCollection();
                List<Alerts> messagesToInsert = new List<Alerts>();
                foreach (var l in collection)
                {
                    messagesToInsert.AddRange(l.Alerts);
                }
                foreach (var msg in messages)
                {
                    Alerts alert = new Alerts()
                    {
                        AddDate = DateTime.Now.ToString(),
                        StudentFirstAndLastName = StationInformation.StudentFirstAndLastName,
                        AlertName = msg,
                        Link1 = "toDO",
                        Link2 = "toDo",
                        Link3 = "toDo"
                    };
                    messagesToInsert.Add(alert);
                }
                manager.UpdateOneList(listName, messagesToInsert, StationInformation.WorkstationName);
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
                manager.UpdateOneList("Apps", processList, StationInformation.WorkstationName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd z połączaniem z bazą danych. Treść błedu: /n /n" + ex);
            }
        }
    }
}
