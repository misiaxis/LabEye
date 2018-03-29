using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Agent
{
    //StationInformation is class created for storing information like for example: Fist and Last name of logged student, IP addres, Host Name etc

    class StationInformation
    {
        static public string StudentFirstAndLastName = "";
        static public string WorkstationName = "";
        static public string HostName = Dns.GetHostName();
        static public string IpAdress = Dns.GetHostAddresses(HostName)[1].ToString();

        static public string Username = Environment.UserName;
        
        //static public string Username = "michal.prusimski@student.put.poznan.pl"; debug option

        static public IPAddress DataBaseAddress = null;
        static public string ConfigurationFilePath = "Workstation.cfg";
        static public string AdminPassword = "0000";
        static public bool isLocked = true; //is locked by admin
    }
}
