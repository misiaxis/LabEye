using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Agent
{
    class AplicationWatcher
    {
        public List<string> blackList { get; set; }
        public List<string> verificationList { get; set; } //filters black list
        DbManager manager = new DbManager();
        public AplicationWatcher(){}

        public List<string> GetRunningAplications()
        {
            List<string> AplicationList = new List<string>();
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle))
                    AplicationList.Add(p.MainWindowTitle);
            }
            return AplicationList;
        }

        public List<string> CheckAplicationListWithBlackList()
        {
            List<string> ret = new List<string>();
            var appsList = GetRunningAplications();
            manager.RefreshWorkstations();
            verificationList = manager.GetWorkstationAlertList();

            if (blackList != null)
                foreach (string keyword in blackList)
                {
                    var match = verificationList
                        .FirstOrDefault(stringToCheck => stringToCheck.Contains(keyword));
                    if (match != null) { }

                    else
                    {
                        if (appsList.Contains(keyword)) ret.Add("Wykryto aplikację proces ze słowem kluczowym " + keyword);
                    }
                }
            if (ret.Count > 0) return ret;
            return null;
        }

    }
}
