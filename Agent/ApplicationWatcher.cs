using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Agent
{
    /// <summary>
    /// Interaction logic for ApplicationWatcher.cs
    /// </summary>
    class ApplicationWatcher
    {
        public List<string> blackList { get; set; }

        /// <summary>
        /// Empty constructor of class ApplicationWatcher
        /// </summary>
        public ApplicationWatcher(){}

        /// <summary>
        /// Checking running processes by its window title and name.
        /// </summary>
        /// <returns>List of running processes</returns>
        public List<string> GetRunningApplications()
        {
            List<string> processList = new List<string>();
            try
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process p in processes)
                {
                    if (!String.IsNullOrEmpty(p.MainWindowTitle))
                        processList.Add(p.MainWindowTitle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd z pobieraniem procesów. Treść błędu: /n /n" + ex);
            }
            return processList;
        }

        /// <summary>
        /// Compare application (processes) black list in database with list of running processes.
        /// </summary>
        /// <returns>List of unwanted processes.</returns>
        public List<string> CheckApplicationListWithBlackList()
        {
            List<string> newAlerts = new List<string>();
            List<Alerts> currentAlertList;
            var appsList = GetRunningApplications();

            try
            {
                DbManager manager = new DbManager();
                currentAlertList = manager.GetWorkstationAlertList();
                List<string> temp = new List<string>();
                if(blackList != null)
                {
                    foreach (string keyword in blackList)
                    {
                        foreach (var alert in currentAlertList)
                        {
                            temp.Add(alert.AlertName);
                        }
                        var match = CheckIfContain(temp, keyword);
                        if (!match)
                        {
                            if (CheckIfContain(appsList, keyword))
                                newAlerts.Add("Wykryto aplikację proces ze słowem kluczowym " + keyword);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd z połączeniem do bazy danych. Treść błędu: /n /n" + ex);
            }
            if (newAlerts.Count > 0) return newAlerts;
            return null;
        }

        /// <summary>
        /// Checking if string "keyword" occurs in any string in param appList
        /// </summary>
        /// <param name="appList">List of processes names</param>
        /// <param name="keyWord">Key to search if exists inside list</param>
        /// <returns>True if keyWord occur in applist, else False</returns>
        private Boolean CheckIfContain(List<string> appList, string keyWord)
        {
            Regex reg = new Regex(keyWord.ToLower());
            foreach(var app in appList)
            {
                if (reg.IsMatch(app.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
