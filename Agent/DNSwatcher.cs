using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DNSwatcher
{
    class DNSwatcher
    {
        private List<string> blackList=new List<string>();

        public List<string> GetblackList()
        {
            return blackList;
        }

        public void Addtoblacklist(string keyword)
        {
            if (blackList.Contains(keyword)==false) blackList.Add(keyword);
        }

        public void Removefromblacklist(string keyword)
        {
            if (blackList.Contains(keyword)) blackList.Remove(keyword);
        }

        public void Removeallfromblacklist()
        {
            blackList.Clear();
        }

        private string Getdnstable()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

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
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

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

        public DNSwatcher(List<string> blackList)
        {
            FlushDns();
            this.blackList = blackList;
        }

        public DNSwatcher(bool commonblacklist)
        {
            FlushDns();
            if (commonblacklist == true)
            {
                blackList.Add("facebook");
                blackList.Add("wikipedia");
                blackList.Add("stackoverflow");
                blackList.Add("codeproject");
            }
        }

        private List<string> Checkblacklist()
        {
            List<string> ret=new List<string>();
            var dns = Getdnstable();
            foreach (string keyword in blackList)
            {
                if (dns.Contains(keyword)) ret.Add("W tablicy DNS wykryto słowo kluczowe: "+keyword);
            }
            if (ret.Count > 0) return ret;
            return null;
        }

        public void debug()
        {
            while (true)
            {
                if (Checkblacklist() != null)
                    foreach (var VARIABLE in Checkblacklist())
                    {
                        Console.WriteLine(VARIABLE);
                    }
                Thread.Sleep(1000);
            }
        }
    }
}
