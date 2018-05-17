using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Agent
{
    class AplicationWatcher
    {
        public List<string> blackList { get; set; }
        public List<Alerts> verificationList { get; set; } //filters black list
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
                        if (CheckIfContain(appsList,keyword)) ret.Add("Wykryto aplikację proces ze słowem kluczowym " + keyword);
                    }
                }
            if (ret.Count > 0) return ret;
            return null;
        }

        private Boolean CheckIfContain(List<string> applist, string keyword)
        {
            Regex reg = new Regex(keyword.ToLower());
            foreach(var app in applist)
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
