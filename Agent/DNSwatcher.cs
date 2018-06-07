using MongoDB.Bson;
using ScreenShotDemo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Agent
{
    /// <summary>
    /// Interaction logic for DNSWatcher.cs
    /// </summary>
    class DNSwatcher
    {
        public List<string> blackList { get; set; }

        /// <summary>
        /// Empty constructor of class DNSwatcher
        /// </summary>
        public DNSwatcher(){}

        /// <summary>
        /// Getting actual dns table.
        /// </summary>
        /// <returns>String contains whole DNS table.</returns>
        private string Getdnstable()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
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

        /// <summary>
        /// Clearing DNS table.
        /// </summary>
        private void FlushDns()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C ipconfig /flushdns";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        /// <summary>
        /// Compare web keywords (web sites) black list in database with DNS table.
        /// </summary>
        /// <returns>List of unwanted sites.</returns>
        public List<Tuple<string, ObjectId, ObjectId, ObjectId>> CheckDnsTableWithBlackList()
        {
            FlushDns();
            List<Tuple<string, ObjectId, ObjectId, ObjectId>> newAlerts =new List<Tuple<string, ObjectId, ObjectId, ObjectId>>();
            var dns = Getdnstable();
            List<Alerts> verificationList = new List<Alerts>();
            try
            {
                DbManager manager = new DbManager();
                verificationList = manager.GetWorkstationAlertList();
                List<string> temp = new List<string>();
                if (blackList != null)
                {
                    foreach (string keyword in blackList)
                    {
                        foreach (var alert in verificationList)
                        {
                            temp.Add(alert.AlertName);
                        }
                        var match = CheckIfContain(temp, keyword);
                        if (!match)
                        {
                            if (dns.Contains(keyword))
                            {
                                ScreenCapture sc = new ScreenCapture();
                                Image img1 = sc.CaptureScreen();
                                var id1 = manager.SendImage(img1, "Image1");
                                ScreenCapture sc2 = new ScreenCapture();
                                Image img2 = sc.CaptureScreen();
                                var id2 = manager.SendImage(img2, "Image2");
                                ScreenCapture sc3 = new ScreenCapture();
                                Image img3 = sc.CaptureScreen();
                                var id3 = manager.SendImage(img3, "Image3");
                                Tuple<string, ObjectId, ObjectId, ObjectId> alert =
                                    new Tuple<string, ObjectId, ObjectId, ObjectId>("W tablicy DNS wykryto słowo kluczowe " + keyword, id1, id2, id3);
                                newAlerts.Add(alert);
                            }
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
            foreach (var app in appList)
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
