using System.Collections.Generic;
using System.Diagnostics;

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

        public DNSwatcher(List<string> blackList)
        {
            FlushDns();
            this.blackList = blackList;
        }

        public List<string> CheckDnsTableWithBlackList()
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

    }
}
