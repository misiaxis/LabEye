using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Agent
{
    class DNSwatcher
    {
        public List<string> blackList { get; set; }
        DbManager manager = new DbManager();
        public List<Alerts> verificationList { get; set; } //filters black list

        public DNSwatcher(){}
        private string Getdnstable()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //OK tu jest trochę niebezpiecznie, ryzyko podmiany ipconfig na inny program i zablokowanie tej funkcjonalności
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C ipconfig /displaydns";

            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            var msg = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return msg;
        }

        private void FlushDns()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //OK tu jest trochę niebezpiecznie, ryzyko podmiany ipconfig na inny program i zablokowanie tej funkcjonalności
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C ipconfig /flushdns";

            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }


        public List<string> CheckDnsTableWithBlackList()
        {
            FlushDns();
            List<string> ret=new List<string>();
            var dns = Getdnstable();
            manager.RefreshWorkstations();
            verificationList = manager.GetWorkstationAlertList();
            if (blackList != null)
                foreach (string keyword in blackList)
                {
                    //var match = verificationList
                       // .FirstOrDefault(stringToCheck => stringToCheck.Contains(keyword));
                    if (match != null) { }

                    else
                    {
                        if (dns.Contains(keyword)) ret.Add("W tablicy DNS wykryto słowo kluczowe: " + keyword);
                    }
                }
            if (ret.Count > 0) return ret;
            return null;
        }

    }
}
