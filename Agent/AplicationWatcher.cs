using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationWatcher
{
    class AplicationWatcher
    {
        private List<string> blackList = new List<string>();

        public List<string> GetblackList()
        {
            return blackList;
        }

        public void Addtoblacklist(string keyword)
        {
            if (blackList.Contains(keyword) == false) blackList.Add(keyword);
        }

        public void Removefromblacklist(string keyword)
        {
            if (blackList.Contains(keyword)) blackList.Remove(keyword);
        }

        public void Removeallfromblacklist()
        {
            blackList.Clear();
        }

        public AplicationWatcher(List<string> blackList)
        {
            this.blackList = blackList;
        }

        private List<string> GetRunningAplications()
        {
            List<string> AplicationList = new List<string>();
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                AplicationList.Add(p.MainWindowTitle);
                AplicationList.Add(p.ProcessName);
            }
            return AplicationList;
        }

        public List<string> CheckAplicationListWithBlackList()
        {
            List<string> ret = new List<string>();
            var appsList = GetRunningAplications();
            foreach (string keyword in blackList)
            {
                if (appsList.Contains(keyword)) ret.Add("Wykryto aplikację proces ze słowem kluczowym " + keyword);
            }
            if (ret.Count > 0) return ret;
            return null;
        }

    }
}
